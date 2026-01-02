using Microsoft.AspNetCore.Mvc;
using Migration.Catalog.Application.Contracts;
using Migration.Catalog.Application.Models;

namespace Migration.Catalog.Api.Controllers;

[ApiController]
[Route("api/catalog")]
public sealed class CatalogQueryController : ControllerBase
{
    private readonly ICatalogQueryService _catalog;

    public CatalogQueryController(ICatalogQueryService catalog)
    {
        _catalog = catalog;
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Category.aspx:1
    // Evidence: nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Categories\Category.cs:1
    [HttpGet("categories")]
    public ActionResult<IReadOnlyList<CategoryDto>> GetCategories()
    {
        return Ok(_catalog.GetCategories());
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Category.aspx:1
    [HttpGet("categories/{id:int}")]
    public ActionResult<CategoryDto> GetCategory(int id)
    {
        var category = _catalog.GetCategory(id);
        if (category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    // Evidence: nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Manufacturers\IManufacturerService.cs:1
    [HttpGet("manufacturers")]
    public ActionResult<IReadOnlyList<ManufacturerDto>> GetManufacturers()
    {
        return Ok(_catalog.GetManufacturers());
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Manufacturer.aspx:1
    [HttpGet("manufacturers/{id:int}")]
    public ActionResult<ManufacturerDto> GetManufacturer(int id)
    {
        var manufacturer = _catalog.GetManufacturer(id);
        if (manufacturer is null)
        {
            return NotFound();
        }
        return Ok(manufacturer);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\BulkEditProducts.ascx:1
    [HttpGet("products/{id:int}")]
    public ActionResult<ProductDto> GetProduct(int id)
    {
        var product = _catalog.GetProduct(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}
