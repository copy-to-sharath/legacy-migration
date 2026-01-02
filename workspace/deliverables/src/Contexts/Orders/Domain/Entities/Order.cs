namespace Migration.Orders.Domain.Entities;

public sealed record Order(int Id, int CustomerId, string Status);
