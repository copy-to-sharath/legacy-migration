namespace Migration.Orders.Application.Models;

public sealed record OrderItemDto(int OrderId, int ProductId, int Quantity);
