var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<Migration.Catalog.Application.Contracts.ICatalogQueryService, Migration.Catalog.Infrastructure.InMemoryCatalogQueryService>();
var app = builder.Build();
app.MapControllers();
app.Run();
