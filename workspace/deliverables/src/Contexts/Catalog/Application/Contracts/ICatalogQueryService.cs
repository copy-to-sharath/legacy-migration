using System.Collections.Generic;
using Migration.Catalog.Application.Models;

namespace Migration.Catalog.Application.Contracts;

public interface ICatalogQueryService
{
    IReadOnlyList<CategoryDto> GetCategories();
    CategoryDto? GetCategory(int id);
    IReadOnlyList<ManufacturerDto> GetManufacturers();
    ManufacturerDto? GetManufacturer(int id);
    ProductDto? GetProduct(int id);
}
