using Microsoft.AspNetCore.Mvc;
using Migration.Customer.Application.Contracts;
using Migration.Customer.Application.Models;

namespace Migration.Customer.Api.Controllers;

[ApiController]
[Route("api/customer")]
public sealed class CustomerQueryController : ControllerBase
{
    private readonly ICustomerQueryService _customers;

    public CustomerQueryController(ICustomerQueryService customers)
    {
        _customers = customers;
    }

    // Evidence: nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Customer\Customer.cs:1
    [HttpGet("customers")]
    public ActionResult<IReadOnlyList<CustomerDto>> GetCustomers()
    {
        return Ok(_customers.GetCustomers());
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Modules\CustomerAccountActivation.ascx:1
    [HttpGet("customers/{id:int}")]
    public ActionResult<CustomerDto> GetCustomer(int id)
    {
        var customer = _customers.GetCustomer(id);
        if (customer is null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
}
