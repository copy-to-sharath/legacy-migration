namespace Migration.Orders.Domain.Entities;

public sealed record OrderItem(int OrderId, int ProductId, int Quantity);
