namespace Migration.Customer.Application.Models;

public sealed record CustomerDto(int Id, string Email, string FirstName, string LastName);
