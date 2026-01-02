// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Security.Api.Controllers;

[ApiController]
[Route("api/security")]
public sealed class SecurityController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ACL.aspx:1
    [HttpGet("security/acl")]
    public IActionResult Acl()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ACL.aspx", Context = "Security" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AccessDenied.aspx:1
    [HttpGet("security/accessdenied")]
    public IActionResult Accessdenied()
    {
        return Ok(new { LegacyEndpoint = "/Administration/AccessDenied.aspx", Context = "Security" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Blacklist.aspx:1
    [HttpGet("security/blacklist")]
    public IActionResult Blacklist()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Blacklist.aspx", Context = "Security" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPAdd.aspx:1
    [HttpGet("security/blacklistipadd")]
    public IActionResult Blacklistipadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlacklistIPAdd.aspx", Context = "Security" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPDetails.aspx:1
    [HttpGet("security/blacklistipdetails")]
    public IActionResult Blacklistipdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlacklistIPDetails.aspx", Context = "Security" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkAdd.aspx:1
    [HttpGet("security/blacklistnetworkadd")]
    public IActionResult Blacklistnetworkadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlacklistNetworkAdd.aspx", Context = "Security" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkDetails.aspx:1
    [HttpGet("security/blacklistnetworkdetails")]
    public IActionResult Blacklistnetworkdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/BlacklistNetworkDetails.aspx", Context = "Security" });
    }

}