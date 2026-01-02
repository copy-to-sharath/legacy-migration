namespace Migration.Catalog.Application.Models;

public sealed record ProductDto(int Id, string Name, int CategoryId, int ManufacturerId);
