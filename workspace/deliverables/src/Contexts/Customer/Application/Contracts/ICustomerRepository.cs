using System.Collections.Generic;
using Migration.Customer.Domain.Entities;

namespace Migration.Customer.Application.Contracts;

public interface ICustomerRepository
{
    IReadOnlyList<Customer> GetCustomers();
    Customer? GetCustomer(int id);
}
