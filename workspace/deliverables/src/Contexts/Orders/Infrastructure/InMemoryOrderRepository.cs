using System.Collections.Generic;
using System.Linq;
using Migration.Orders.Application.Contracts;
using Migration.Orders.Domain.Entities;

namespace Migration.Orders.Infrastructure;

public sealed class InMemoryOrderRepository : IOrderRepository
{
    private static readonly List<Order> Orders =
    [
        new Order(5001, 1001, "Pending"),
        new Order(5002, 1002, "Paid"),
    ];

    private static readonly List<OrderItem> Items =
    [
        new OrderItem(5001, 100, 2),
        new OrderItem(5002, 101, 1),
    ];

    public IReadOnlyList<Order> GetOrders() => Orders;

    public Order? GetOrder(int id) => Orders.FirstOrDefault(o => o.Id == id);

    public IReadOnlyList<OrderItem> GetOrderItems(int orderId) => Items.Where(i => i.OrderId == orderId).ToList();
}
