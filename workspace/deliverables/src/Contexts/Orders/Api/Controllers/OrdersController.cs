// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Orders.Api.Controllers;

[ApiController]
[Route("api/orders")]
public sealed class OrdersController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Alipay_Return.aspx:1
    [HttpGet("orders/alipay-return")]
    public IActionResult AlipayReturn()
    {
        return Ok(new { LegacyEndpoint = "/Alipay_Return.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AmazonSimplePayReturn.aspx:1
    [HttpGet("orders/amazonsimplepayreturn")]
    public IActionResult Amazonsimplepayreturn()
    {
        return Ok(new { LegacyEndpoint = "/AmazonSimplePayReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AssistHostedPaymentReturn.aspx:1
    [HttpGet("orders/assisthostedpaymentreturn")]
    public IActionResult Assisthostedpaymentreturn()
    {
        return Ok(new { LegacyEndpoint = "/AssistHostedPaymentReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\BeanstreamHostedPaymentReturn.aspx:1
    [HttpGet("orders/beanstreamhostedpaymentreturn")]
    public IActionResult Beanstreamhostedpaymentreturn()
    {
        return Ok(new { LegacyEndpoint = "/BeanstreamHostedPaymentReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CCAvenueReturn.aspx:1
    [HttpGet("orders/ccavenuereturn")]
    public IActionResult Ccavenuereturn()
    {
        return Ok(new { LegacyEndpoint = "/CCAvenueReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\DibsFlexWinReturn.aspx:1
    [HttpGet("orders/dibsflexwinreturn")]
    public IActionResult Dibsflexwinreturn()
    {
        return Ok(new { LegacyEndpoint = "/DibsFlexWinReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\IdealReturn.aspx:1
    [HttpGet("orders/idealreturn")]
    public IActionResult Idealreturn()
    {
        return Ok(new { LegacyEndpoint = "/IdealReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\MonerisHostedPaymentReturn.aspx:1
    [HttpGet("orders/monerishostedpaymentreturn")]
    public IActionResult Monerishostedpaymentreturn()
    {
        return Ok(new { LegacyEndpoint = "/MonerisHostedPaymentReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\MoneybookersReturn.aspx:1
    [HttpGet("orders/moneybookersreturn")]
    public IActionResult Moneybookersreturn()
    {
        return Ok(new { LegacyEndpoint = "/MoneybookersReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\OrderDetails.aspx:1
    [HttpGet("orders/orderdetails")]
    public IActionResult Orderdetails()
    {
        return Ok(new { LegacyEndpoint = "/OrderDetails.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\OrderDetails.aspx:1
    [HttpGet("orders/orderdetails")]
    public IActionResult Orderdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/OrderDetails.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\OrderPartialRefund.aspx:1
    [HttpGet("orders/orderpartialrefund")]
    public IActionResult Orderpartialrefund()
    {
        return Ok(new { LegacyEndpoint = "/Administration/OrderPartialRefund.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Orders.aspx:1
    [HttpGet("orders/orders")]
    public IActionResult Orders()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Orders.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PayPointHostedPaymentReturn.aspx:1
    [HttpGet("orders/paypointhostedpaymentreturn")]
    public IActionResult Paypointhostedpaymentreturn()
    {
        return Ok(new { LegacyEndpoint = "/PayPointHostedPaymentReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalExpressReturn.aspx:1
    [HttpGet("orders/paypalexpressreturn")]
    public IActionResult Paypalexpressreturn()
    {
        return Ok(new { LegacyEndpoint = "/PaypalExpressReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PrintOrderDetails.aspx:1
    [HttpGet("orders/printorderdetails")]
    public IActionResult Printorderdetails()
    {
        return Ok(new { LegacyEndpoint = "/PrintOrderDetails.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\QuickPayReturn.aspx:1
    [HttpGet("orders/quickpayreturn")]
    public IActionResult Quickpayreturn()
    {
        return Ok(new { LegacyEndpoint = "/QuickPayReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ReturnItems.aspx:1
    [HttpGet("orders/returnitems")]
    public IActionResult Returnitems()
    {
        return Ok(new { LegacyEndpoint = "/ReturnItems.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequestDetails.aspx:1
    [HttpGet("orders/returnrequestdetails")]
    public IActionResult Returnrequestdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ReturnRequestDetails.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequests.aspx:1
    [HttpGet("orders/returnrequests")]
    public IActionResult Returnrequests()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ReturnRequests.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SermepaReturn.aspx:1
    [HttpGet("orders/sermepareturn")]
    public IActionResult Sermepareturn()
    {
        return Ok(new { LegacyEndpoint = "/SermepaReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SveaHostedPaymentReturn.aspx:1
    [HttpGet("orders/sveahostedpaymentreturn")]
    public IActionResult Sveahostedpaymentreturn()
    {
        return Ok(new { LegacyEndpoint = "/SveaHostedPaymentReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\USAePayEPaymentFormReturn.aspx:1
    [HttpGet("orders/usaepayepaymentformreturn")]
    public IActionResult Usaepayepaymentformreturn()
    {
        return Ok(new { LegacyEndpoint = "/USAePayEPaymentFormReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\WorldpayReturn.aspx:1
    [HttpGet("orders/worldpayreturn")]
    public IActionResult Worldpayreturn()
    {
        return Ok(new { LegacyEndpoint = "/WorldpayReturn.aspx", Context = "Orders" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\eWayMerchantReturn.aspx:1
    [HttpGet("orders/ewaymerchantreturn")]
    public IActionResult Ewaymerchantreturn()
    {
        return Ok(new { LegacyEndpoint = "/eWayMerchantReturn.aspx", Context = "Orders" });
    }

}