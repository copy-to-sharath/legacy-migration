using System.Collections.Generic;
using System.Linq;
using Migration.Orders.Application.Contracts;
using Migration.Orders.Application.Models;

namespace Migration.Orders.Infrastructure;

public sealed class InMemoryOrderQueryService : IOrderQueryService
{
    private readonly IOrderRepository _repository;

    public InMemoryOrderQueryService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<OrderDto> GetOrders()
    {
        return _repository.GetOrders()
            .Select(o => new OrderDto(o.Id, o.CustomerId, o.Status))
            .ToList();
    }

    public OrderDto? GetOrder(int id)
    {
        var order = _repository.GetOrder(id);
        return order is null ? null : new OrderDto(order.Id, order.CustomerId, order.Status);
    }

    public IReadOnlyList<OrderItemDto> GetOrderItems(int orderId)
    {
        return _repository.GetOrderItems(orderId)
            .Select(i => new OrderItemDto(i.OrderId, i.ProductId, i.Quantity))
            .ToList();
    }
}
