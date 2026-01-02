namespace Migration.Customer.Domain.Entities;

public sealed record Customer(int Id, string Email, string FirstName, string LastName);
