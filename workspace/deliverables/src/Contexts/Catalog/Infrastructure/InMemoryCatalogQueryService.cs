using System.Collections.Generic;
using System.Linq;
using Migration.Catalog.Application.Contracts;
using Migration.Catalog.Application.Models;

namespace Migration.Catalog.Infrastructure;

public sealed class InMemoryCatalogQueryService : ICatalogQueryService
{
    private static readonly List<CategoryDto> Categories =
    [
        new CategoryDto(1, "Electronics", "Devices and accessories"),
        new CategoryDto(2, "Apparel", "Clothing and accessories"),
    ];

    private static readonly List<ManufacturerDto> Manufacturers =
    [
        new ManufacturerDto(1, "Acme"),
        new ManufacturerDto(2, "Contoso"),
    ];

    private static readonly List<ProductDto> Products =
    [
        new ProductDto(100, "Acme Phone", 1, 1),
        new ProductDto(101, "Contoso Jacket", 2, 2),
    ];

    public IReadOnlyList<CategoryDto> GetCategories() => Categories;

    public CategoryDto? GetCategory(int id) => Categories.FirstOrDefault(c => c.Id == id);

    public IReadOnlyList<ManufacturerDto> GetManufacturers() => Manufacturers;

    public ManufacturerDto? GetManufacturer(int id) => Manufacturers.FirstOrDefault(m => m.Id == id);

    public ProductDto? GetProduct(int id) => Products.FirstOrDefault(p => p.Id == id);
}
