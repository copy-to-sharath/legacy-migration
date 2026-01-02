using Microsoft.AspNetCore.Mvc;
using Migration.Orders.Application.Contracts;
using Migration.Orders.Application.Models;

namespace Migration.Orders.Api.Controllers;

[ApiController]
[Route("api/orders")]
public sealed class OrdersQueryController : ControllerBase
{
    private readonly IOrderQueryService _orders;

    public OrdersQueryController(IOrderQueryService orders)
    {
        _orders = orders;
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CustomerOrders.ascx:1
    [HttpGet]
    public ActionResult<IReadOnlyList<OrderDto>> GetOrders()
    {
        return Ok(_orders.GetOrders());
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Modules\CustomerOrders.ascx:1
    [HttpGet("{id:int}")]
    public ActionResult<OrderDto> GetOrder(int id)
    {
        var order = _orders.GetOrder(id);
        if (order is null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx:1
    [HttpGet("{id:int}/items")]
    public ActionResult<IReadOnlyList<OrderItemDto>> GetItems(int id)
    {
        return Ok(_orders.GetOrderItems(id));
    }
}
