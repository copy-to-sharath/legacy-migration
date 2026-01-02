namespace Migration.Catalog.Domain.Entities;

public sealed record Product(int Id, string Name, int CategoryId, int ManufacturerId);
