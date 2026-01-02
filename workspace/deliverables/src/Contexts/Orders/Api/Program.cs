var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<Migration.Orders.Application.Contracts.IOrderRepository, Migration.Orders.Infrastructure.InMemoryOrderRepository>();
builder.Services.AddSingleton<Migration.Orders.Application.Contracts.IOrderQueryService, Migration.Orders.Infrastructure.InMemoryOrderQueryService>();
var app = builder.Build();
app.MapControllers();
app.Run();
