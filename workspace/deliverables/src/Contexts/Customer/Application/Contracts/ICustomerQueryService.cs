using System.Collections.Generic;
using Migration.Customer.Application.Models;

namespace Migration.Customer.Application.Contracts;

public interface ICustomerQueryService
{
    IReadOnlyList<CustomerDto> GetCustomers();
    CustomerDto? GetCustomer(int id);
}
