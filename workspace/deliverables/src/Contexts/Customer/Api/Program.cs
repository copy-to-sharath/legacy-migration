var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<Migration.Customer.Application.Contracts.ICustomerRepository, Migration.Customer.Infrastructure.InMemoryCustomerRepository>();
builder.Services.AddSingleton<Migration.Customer.Application.Contracts.ICustomerQueryService, Migration.Customer.Infrastructure.InMemoryCustomerQueryService>();
var app = builder.Build();
app.MapControllers();
app.Run();
