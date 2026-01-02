using System.Collections.Generic;
using Migration.Orders.Domain.Entities;

namespace Migration.Orders.Application.Contracts;

public interface IOrderRepository
{
    IReadOnlyList<Order> GetOrders();
    Order? GetOrder(int id);
    IReadOnlyList<OrderItem> GetOrderItems(int orderId);
}
