using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using CSharpCompilationUnit = Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax;
using VbCompilationUnit = Microsoft.CodeAnalysis.VisualBasic.Syntax.CompilationUnitSyntax;
using CSharpExpressionSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.ExpressionSyntax;
using VbExpressionSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax;
using CSharpQueryExpressionSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.QueryExpressionSyntax;
using CSharpInvocationExpressionSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax;
using CSharpLiteralExpressionSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.LiteralExpressionSyntax;
using CSharpSyntaxKind = Microsoft.CodeAnalysis.CSharp.SyntaxKind;
using CSharpIdentifierNameSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.IdentifierNameSyntax;
using CSharpMemberAccessExpressionSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.MemberAccessExpressionSyntax;
using VbQueryExpressionSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.QueryExpressionSyntax;
using VbInvocationExpressionSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.InvocationExpressionSyntax;
using VbLiteralExpressionSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.LiteralExpressionSyntax;
using VbSyntaxKind = Microsoft.CodeAnalysis.VisualBasic.SyntaxKind;
using VbIdentifierNameSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.IdentifierNameSyntax;
using VbMemberAccessExpressionSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.MemberAccessExpressionSyntax;
using VbTypeBlockSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.TypeBlockSyntax;
using VbMethodStatementSyntax = Microsoft.CodeAnalysis.VisualBasic.Syntax.MethodStatementSyntax;

static class Program
{
    private static readonly HashSet<string> LinqMethods = new(StringComparer.OrdinalIgnoreCase)
    {
        "Select",
        "Where",
        "Join",
        "GroupBy",
        "OrderBy",
        "OrderByDescending",
        "ThenBy",
        "ThenByDescending",
        "SelectMany",
        "Any",
        "All",
        "First",
        "FirstOrDefault",
        "Single",
        "SingleOrDefault",
        "Count",
        "Sum",
        "Average",
        "Min",
        "Max",
        "Distinct",
        "Take",
        "Skip",
        "ToList"
    };

    private static readonly HashSet<string> OrmIdentifiers = new(StringComparer.OrdinalIgnoreCase)
    {
        "DbContext",
        "DbSet",
        "EntityFramework",
        "NHibernate",
        "ISession",
        "Dapper",
        "SqlMapper",
        "LinqToSql",
        "DataContext"
    };

    private static readonly HashSet<string> OrmMethods = new(StringComparer.OrdinalIgnoreCase)
    {
        "ExecuteSqlCommand",
        "ExecuteSqlRaw",
        "ExecuteSqlInterpolated",
        "FromSqlRaw",
        "FromSqlInterpolated",
        "SqlQuery",
        "Query",
        "Execute",
        "ExecuteAsync"
    };

    private static readonly System.Text.RegularExpressions.Regex SqlExecRegex =
        new(@"\bEXEC(?:UTE)?\s+([\[\]\w\.]+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

    private static async Task<int> Main(string[] args)
    {
        var root = GetArg(args, "--root") ?? @"D:\code\migration\code";
        var output = GetArg(args, "--out") ?? @"c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl";
        var missingLog = GetArg(args, "--missing-log") ?? @"c:\Users\shara\code\migration\workspace\state\roslyn_missing.txt";

        Directory.CreateDirectory(Path.GetDirectoryName(output)!);

        MSBuildLocator.RegisterDefaults();
        using var workspace = MSBuildWorkspace.Create();

        var slnPaths = Directory.GetFiles(root, "*.sln", SearchOption.AllDirectories);
        var projectPaths = Directory.GetFiles(root, "*.csproj", SearchOption.AllDirectories)
            .Concat(Directory.GetFiles(root, "*.vbproj", SearchOption.AllDirectories))
            .ToArray();

        var projects = new List<Project>();

        foreach (var sln in slnPaths)
        {
            var solution = await workspace.OpenSolutionAsync(sln);
            projects.AddRange(solution.Projects);
        }

        if (projects.Count == 0)
        {
            foreach (var proj in projectPaths)
            {
                var project = await workspace.OpenProjectAsync(proj);
                projects.Add(project);
            }
        }

        var records = new ConcurrentBag<Dictionary<string, object?>>();
        var seenFiles = new ConcurrentDictionary<string, byte>(StringComparer.OrdinalIgnoreCase);

        foreach (var project in projects)
        {
            foreach (var doc in project.Documents)
            {
                if (doc.SourceCodeKind != SourceCodeKind.Regular)
                    continue;

                var syntaxRoot = await doc.GetSyntaxRootAsync();
                if (syntaxRoot == null)
                    continue;

                var relPath = ToRelativePath(root, doc.FilePath ?? string.Empty);
                var fileId = MakeId("file", relPath);
                seenFiles.TryAdd(relPath, 0);
                AddRoslynMarker(relPath, project.Name, fileId, records);

                if (syntaxRoot is CSharpCompilationUnit csRoot)
                {
                    ExtractCSharp(csRoot, relPath, project.Name, fileId, records);
                }
                else if (syntaxRoot is VbCompilationUnit vbRoot)
                {
                    ExtractVisualBasic(vbRoot, relPath, project.Name, fileId, records);
                }
            }
        }

        var allSourceFiles = Directory.GetFiles(root, "*.cs", SearchOption.AllDirectories)
            .Concat(Directory.GetFiles(root, "*.vb", SearchOption.AllDirectories))
            .ToArray();

        foreach (var path in allSourceFiles)
        {
            var relPath = ToRelativePath(root, path);
            if (seenFiles.ContainsKey(relPath))
                continue;

            var fileId = MakeId("file", relPath);
            var text = await File.ReadAllTextAsync(path);
            var context = GetContextFromPath(relPath);
            AddRoslynMarker(relPath, context, fileId, records);

            if (path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
            {
                var tree = CSharpSyntaxTree.ParseText(text);
                if (tree.GetRoot() is CSharpCompilationUnit csRoot)
                {
                    ExtractCSharp(csRoot, relPath, context, fileId, records);
                }
            }
            else
            {
                var tree = VisualBasicSyntaxTree.ParseText(text);
                if (tree.GetRoot() is VbCompilationUnit vbRoot)
                {
                    ExtractVisualBasic(vbRoot, relPath, context, fileId, records);
                }
            }

            seenFiles.TryAdd(relPath, 0);
        }

        await using var stream = File.Create(output);
        await using var writer = new StreamWriter(stream, new UTF8Encoding(false));
        foreach (var record in records)
        {
            var json = JsonSerializer.Serialize(record);
            await writer.WriteLineAsync(json);
        }

        var missing = allSourceFiles.Select(p => ToRelativePath(root, p))
            .Where(rel => !seenFiles.ContainsKey(rel))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (missing.Length > 0)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(missingLog)!);
            await File.WriteAllLinesAsync(missingLog, missing, new UTF8Encoding(false));
        }

        return 0;
    }

    private static void ExtractCSharp(
        CSharpCompilationUnit root,
        string relPath,
        string context,
        string fileId,
        ConcurrentBag<Dictionary<string, object?>> records)
    {
        var seenLinq = new HashSet<string>();
        var seenOrm = new HashSet<string>();
        var seenProc = new HashSet<string>();

        foreach (var node in root.DescendantNodes())
        {
            var line = GetLine(node);

            if (node is BaseTypeDeclarationSyntax typeDecl)
            {
                var typeName = typeDecl.Identifier.Text;
                var typeKind = typeDecl.Kind().ToString().Replace("Declaration", string.Empty);
                var typeId = MakeId("type", relPath, typeName, line.ToString());
                records.Add(NodeRecord(typeId, typeKind, typeName, context, relPath, line));
                records.Add(EdgeRecord(MakeId("edge", fileId, typeId), "CONTAINS", fileId, typeId, context));
            }
            else if (node is MethodDeclarationSyntax methodDecl)
            {
                var methodName = methodDecl.Identifier.Text;
                var methodId = MakeId("method", relPath, methodName, line.ToString());
                records.Add(NodeRecord(methodId, "Method", methodName, context, relPath, line));
                records.Add(EdgeRecord(MakeId("edge", fileId, methodId), "CONTAINS", fileId, methodId, context));
            }
            else if (node is CSharpQueryExpressionSyntax)
            {
                var linqId = MakeId("linq", relPath, line.ToString());
                if (seenLinq.Add(linqId))
                {
                    records.Add(NodeRecord(linqId, "LinqQuery", "query_expression", context, relPath, line));
                    records.Add(EdgeRecord(MakeId("edge", fileId, linqId), "USES_LINQ", fileId, linqId, context));
                }
            }
            else if (node is CSharpInvocationExpressionSyntax invoke)
            {
                var methodName = GetInvocationNameCSharp(invoke.Expression);
                if (methodName != null && LinqMethods.Contains(methodName))
                {
                    var linqId = MakeId("linq", relPath, methodName, line.ToString());
                    if (seenLinq.Add(linqId))
                    {
                        records.Add(NodeRecord(linqId, "LinqQuery", methodName, context, relPath, line));
                        records.Add(EdgeRecord(MakeId("edge", fileId, linqId), "USES_LINQ", fileId, linqId, context));
                    }
                }

                if (methodName != null && OrmMethods.Contains(methodName))
                {
                    var ormId = MakeId("orm", relPath, methodName, line.ToString());
                    if (seenOrm.Add(ormId))
                    {
                        records.Add(NodeRecord(ormId, "OrmUsage", methodName, context, relPath, line));
                        records.Add(EdgeRecord(MakeId("edge", fileId, ormId), "USES_ORM", fileId, ormId, context));
                    }
                }

                foreach (var literal in invoke.DescendantNodes().OfType<CSharpLiteralExpressionSyntax>())
                {
                    if (literal.IsKind(CSharpSyntaxKind.StringLiteralExpression))
                    {
                        var text = literal.Token.ValueText;
                        foreach (System.Text.RegularExpressions.Match match in SqlExecRegex.Matches(text))
                        {
                            var procName = match.Groups[1].Value;
                            var procId = MakeId("proc", relPath, procName, line.ToString());
                            if (seenProc.Add(procId))
                            {
                                records.Add(NodeRecord(procId, "StoredProcedure", procName, context, relPath, line));
                                records.Add(EdgeRecord(MakeId("edge", fileId, procId), "EXECUTES_PROC", fileId, procId, context));
                            }
                        }
                    }
                }
            }
            else if (node is CSharpIdentifierNameSyntax ident)
            {
                if (OrmIdentifiers.Contains(ident.Identifier.Text))
                {
                    var ormId = MakeId("orm", relPath, ident.Identifier.Text);
                    if (seenOrm.Add(ormId))
                    {
                        records.Add(NodeRecord(ormId, "OrmUsage", ident.Identifier.Text, context, relPath, line));
                        records.Add(EdgeRecord(MakeId("edge", fileId, ormId), "USES_ORM", fileId, ormId, context));
                    }
                }
            }
        }
    }

    private static void ExtractVisualBasic(
        VbCompilationUnit root,
        string relPath,
        string context,
        string fileId,
        ConcurrentBag<Dictionary<string, object?>> records)
    {
        var seenLinq = new HashSet<string>();
        var seenOrm = new HashSet<string>();
        var seenProc = new HashSet<string>();

        foreach (var node in root.DescendantNodes())
        {
            var line = GetLine(node);

            if (node is VbTypeBlockSyntax typeBlock)
            {
                var typeName = typeBlock.BlockStatement.Identifier.Text;
                var typeKind = typeBlock.BlockStatement.Kind().ToString().Replace("Statement", string.Empty);
                var typeId = MakeId("type", relPath, typeName, line.ToString());
                records.Add(NodeRecord(typeId, typeKind, typeName, context, relPath, line));
                records.Add(EdgeRecord(MakeId("edge", fileId, typeId), "CONTAINS", fileId, typeId, context));
            }
            else if (node is VbMethodStatementSyntax methodStmt)
            {
                var methodName = methodStmt.Identifier.Text;
                var methodId = MakeId("method", relPath, methodName, line.ToString());
                records.Add(NodeRecord(methodId, "Method", methodName, context, relPath, line));
                records.Add(EdgeRecord(MakeId("edge", fileId, methodId), "CONTAINS", fileId, methodId, context));
            }
            else if (node is VbQueryExpressionSyntax)
            {
                var linqId = MakeId("linq", relPath, line.ToString());
                if (seenLinq.Add(linqId))
                {
                    records.Add(NodeRecord(linqId, "LinqQuery", "query_expression", context, relPath, line));
                    records.Add(EdgeRecord(MakeId("edge", fileId, linqId), "USES_LINQ", fileId, linqId, context));
                }
            }
            else if (node is VbInvocationExpressionSyntax invoke)
            {
                var methodName = GetInvocationNameVb(invoke.Expression);
                if (methodName != null && LinqMethods.Contains(methodName))
                {
                    var linqId = MakeId("linq", relPath, methodName, line.ToString());
                    if (seenLinq.Add(linqId))
                    {
                        records.Add(NodeRecord(linqId, "LinqQuery", methodName, context, relPath, line));
                        records.Add(EdgeRecord(MakeId("edge", fileId, linqId), "USES_LINQ", fileId, linqId, context));
                    }
                }

                if (methodName != null && OrmMethods.Contains(methodName))
                {
                    var ormId = MakeId("orm", relPath, methodName, line.ToString());
                    if (seenOrm.Add(ormId))
                    {
                        records.Add(NodeRecord(ormId, "OrmUsage", methodName, context, relPath, line));
                        records.Add(EdgeRecord(MakeId("edge", fileId, ormId), "USES_ORM", fileId, ormId, context));
                    }
                }

                foreach (var literal in invoke.DescendantNodes().OfType<VbLiteralExpressionSyntax>())
                {
                    if (literal.IsKind(VbSyntaxKind.StringLiteralExpression))
                    {
                        var text = literal.Token.ValueText;
                        foreach (System.Text.RegularExpressions.Match match in SqlExecRegex.Matches(text))
                        {
                            var procName = match.Groups[1].Value;
                            var procId = MakeId("proc", relPath, procName, line.ToString());
                            if (seenProc.Add(procId))
                            {
                                records.Add(NodeRecord(procId, "StoredProcedure", procName, context, relPath, line));
                                records.Add(EdgeRecord(MakeId("edge", fileId, procId), "EXECUTES_PROC", fileId, procId, context));
                            }
                        }
                    }
                }
            }
            else if (node is VbIdentifierNameSyntax ident)
            {
                if (OrmIdentifiers.Contains(ident.Identifier.Text))
                {
                    var ormId = MakeId("orm", relPath, ident.Identifier.Text);
                    if (seenOrm.Add(ormId))
                    {
                        records.Add(NodeRecord(ormId, "OrmUsage", ident.Identifier.Text, context, relPath, line));
                        records.Add(EdgeRecord(MakeId("edge", fileId, ormId), "USES_ORM", fileId, ormId, context));
                    }
                }
            }
        }
    }

    private static Dictionary<string, object?> NodeRecord(
        string id,
        string type,
        string name,
        string context,
        string sourceFile,
        int sourceLine)
    {
        return new Dictionary<string, object?>
        {
            ["recordType"] = "node",
            ["id"] = id,
            ["type"] = type,
            ["name"] = name,
            ["context"] = context,
            ["sourceFile"] = sourceFile,
            ["sourceLine"] = sourceLine
        };
    }

    private static Dictionary<string, object?> EdgeRecord(
        string id,
        string type,
        string sourceId,
        string targetId,
        string context)
    {
        return new Dictionary<string, object?>
        {
            ["recordType"] = "edge",
            ["id"] = id,
            ["type"] = type,
            ["sourceId"] = sourceId,
            ["targetId"] = targetId,
            ["context"] = context
        };
    }

    private static string? GetInvocationNameCSharp(CSharpExpressionSyntax expression)
    {
        return expression switch
        {
            CSharpIdentifierNameSyntax ident => ident.Identifier.Text,
            CSharpMemberAccessExpressionSyntax member => member.Name.Identifier.Text,
            _ => null
        };
    }

    private static string? GetInvocationNameVb(VbExpressionSyntax expression)
    {
        return expression switch
        {
            VbIdentifierNameSyntax ident => ident.Identifier.Text,
            VbMemberAccessExpressionSyntax member => member.Name.Identifier.Text,
            _ => null
        };
    }

    private static int GetLine(SyntaxNode node)
    {
        return node.GetLocation().GetLineSpan().StartLinePosition.Line + 1;
    }

    private static string GetContextFromPath(string relPath)
    {
        var parts = relPath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
        return parts.Length > 0 ? parts[0] : "root";
    }

    private static void AddRoslynMarker(
        string relPath,
        string context,
        string fileId,
        ConcurrentBag<Dictionary<string, object?>> records)
    {
        var markerId = MakeId("roslyn-file", relPath);
        records.Add(NodeRecord(markerId, "RoslynFile", Path.GetFileName(relPath), context, relPath, 1));
        records.Add(EdgeRecord(MakeId("edge", fileId, markerId), "HAS_ROSLYN", fileId, markerId, context));
    }

    private static string MakeId(params string[] parts)
    {
        using var sha1 = SHA1.Create();
        foreach (var part in parts)
        {
            var data = Encoding.UTF8.GetBytes(part);
            sha1.TransformBlock(data, 0, data.Length, null, 0);
            sha1.TransformBlock(new byte[] { (byte)'|' }, 0, 1, null, 0);
        }
        sha1.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        return BitConverter.ToString(sha1.Hash!).Replace("-", "").ToLowerInvariant();
    }

    private static string? GetArg(string[] args, string name)
    {
        var idx = Array.IndexOf(args, name);
        if (idx >= 0 && idx + 1 < args.Length)
            return args[idx + 1];
        return null;
    }

    private static string ToRelativePath(string root, string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return string.Empty;
        return Path.GetRelativePath(root, path);
    }
}
