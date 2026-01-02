using System.Collections.Generic;
using System.Linq;
using Migration.Customer.Application.Contracts;
using Migration.Customer.Domain.Entities;

namespace Migration.Customer.Infrastructure;

public sealed class InMemoryCustomerRepository : ICustomerRepository
{
    private static readonly List<Customer> Customers =
    [
        new Customer(1001, "alice@example.test", "Alice", "Sample"),
        new Customer(1002, "bob@example.test", "Bob", "Sample"),
    ];

    public IReadOnlyList<Customer> GetCustomers() => Customers;

    public Customer? GetCustomer(int id) => Customers.FirstOrDefault(c => c.Id == id);
}
