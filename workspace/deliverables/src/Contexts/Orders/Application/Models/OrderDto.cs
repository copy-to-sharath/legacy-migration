namespace Migration.Orders.Application.Models;

public sealed record OrderDto(int Id, int CustomerId, string Status);
