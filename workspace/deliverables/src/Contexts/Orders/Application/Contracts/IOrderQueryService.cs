using System.Collections.Generic;
using Migration.Orders.Application.Models;

namespace Migration.Orders.Application.Contracts;

public interface IOrderQueryService
{
    IReadOnlyList<OrderDto> GetOrders();
    OrderDto? GetOrder(int id);
    IReadOnlyList<OrderItemDto> GetOrderItems(int orderId);
}
