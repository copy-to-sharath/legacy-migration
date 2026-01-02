// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Localization.Api.Controllers;

[ApiController]
[Route("api/localization")]
public sealed class LocalizationController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CountryAdd.aspx:1
    [HttpGet("localization/countryadd")]
    public IActionResult Countryadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CountryAdd.aspx", Context = "Localization" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CountryDetails.aspx:1
    [HttpGet("localization/countrydetails")]
    public IActionResult Countrydetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CountryDetails.aspx", Context = "Localization" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyAdd.aspx:1
    [HttpGet("localization/currencyadd")]
    public IActionResult Currencyadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CurrencyAdd.aspx", Context = "Localization" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyDetails.aspx:1
    [HttpGet("localization/currencydetails")]
    public IActionResult Currencydetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CurrencyDetails.aspx", Context = "Localization" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageAdd.aspx:1
    [HttpGet("localization/languageadd")]
    public IActionResult Languageadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LanguageAdd.aspx", Context = "Localization" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageDetails.aspx:1
    [HttpGet("localization/languagedetails")]
    public IActionResult Languagedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LanguageDetails.aspx", Context = "Localization" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Languages.aspx:1
    [HttpGet("localization/languages")]
    public IActionResult Languages()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Languages.aspx", Context = "Localization" });
    }

}