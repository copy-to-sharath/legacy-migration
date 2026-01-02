// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;
using Migration.Shipping.Api.Models;

namespace Migration.Shipping.Api.Controllers;

[ApiController]
[Route("api/shipping")]
public sealed class ShippingController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Froogle.ashx:1
    [HttpGet("shipping/froogle")]
    public IActionResult Froogle()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Froogle.ashx",
            Context: "Shipping",
            Method: ".ashx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Froogle.ashx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\GetDownload.ashx:1
    [HttpGet("shipping/getdownload")]
    public IActionResult Getdownload()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/GetDownload.ashx",
            Context: "Shipping",
            Method: ".ashx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\GetDownload.ashx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\GetDownloadAdmin.ashx:1
    [HttpGet("shipping/getdownloadadmin")]
    public IActionResult Getdownloadadmin()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/GetDownloadAdmin.ashx",
            Context: "Shipping",
            Method: ".ashx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\GetDownloadAdmin.ashx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\GetLicense.ashx:1
    [HttpGet("shipping/getlicense")]
    public IActionResult Getlicense()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/GetLicense.ashx",
            Context: "Shipping",
            Method: ".ashx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\GetLicense.ashx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\KeepAlive\Ping.ashx:1
    [HttpGet("shipping/ping")]
    public IActionResult Ping()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/KeepAlive/Ping.ashx",
            Context: "Shipping",
            Method: ".ashx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\KeepAlive\Ping.ashx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\QBConnector.asmx:1
    [HttpPost("shipping/qbconnector")]
    public IActionResult Qbconnector()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/QBConnector.asmx",
            Context: "Shipping",
            Method: ".asmx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\QBConnector.asmx:1"
        );
        return Ok(payload);
    }

}