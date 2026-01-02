using System.Collections.Generic;
using System.Linq;
using Migration.Customer.Application.Contracts;
using Migration.Customer.Application.Models;

namespace Migration.Customer.Infrastructure;

public sealed class InMemoryCustomerQueryService : ICustomerQueryService
{
    private readonly ICustomerRepository _repository;

    public InMemoryCustomerQueryService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<CustomerDto> GetCustomers()
    {
        return _repository.GetCustomers()
            .Select(c => new CustomerDto(c.Id, c.Email, c.FirstName, c.LastName))
            .ToList();
    }

    public CustomerDto? GetCustomer(int id)
    {
        var customer = _repository.GetCustomer(id);
        return customer is null ? null : new CustomerDto(customer.Id, customer.Email, customer.FirstName, customer.LastName);
    }
}
