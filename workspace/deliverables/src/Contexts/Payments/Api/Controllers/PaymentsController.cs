// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Payments.Api.Controllers;

[ApiController]
[Route("api/payments")]
public sealed class PaymentsController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Alipay_Notify.aspx:1
    [HttpGet("payments/alipay-notify")]
    public IActionResult AlipayNotify()
    {
        return Ok(new { LegacyEndpoint = "/Alipay_Notify.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodAdd.aspx:1
    [HttpGet("payments/paymentmethodadd")]
    public IActionResult Paymentmethodadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PaymentMethodAdd.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodDetails.aspx:1
    [HttpGet("payments/paymentmethoddetails")]
    public IActionResult Paymentmethoddetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PaymentMethodDetails.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethods.aspx:1
    [HttpGet("payments/paymentmethods")]
    public IActionResult Paymentmethods()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PaymentMethods.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentSettingsHome.aspx:1
    [HttpGet("payments/paymentsettingshome")]
    public IActionResult Paymentsettingshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PaymentSettingsHome.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalCancel.aspx:1
    [HttpGet("payments/paypalcancel")]
    public IActionResult Paypalcancel()
    {
        return Ok(new { LegacyEndpoint = "/PaypalCancel.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalIPNHandler.aspx:1
    [HttpGet("payments/paypalipnhandler")]
    public IActionResult Paypalipnhandler()
    {
        return Ok(new { LegacyEndpoint = "/PaypalIPNHandler.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalPDTHandler.aspx:1
    [HttpGet("payments/paypalpdthandler")]
    public IActionResult Paypalpdthandler()
    {
        return Ok(new { LegacyEndpoint = "/PaypalPDTHandler.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPaymentDetails.aspx:1
    [HttpGet("payments/recurringpaymentdetails")]
    public IActionResult Recurringpaymentdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/RecurringPaymentDetails.aspx", Context = "Payments" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPayments.aspx:1
    [HttpGet("payments/recurringpayments")]
    public IActionResult Recurringpayments()
    {
        return Ok(new { LegacyEndpoint = "/Administration/RecurringPayments.aspx", Context = "Payments" });
    }

}