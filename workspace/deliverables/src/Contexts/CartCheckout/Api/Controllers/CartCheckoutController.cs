// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.CartCheckout.Api.Controllers;

[ApiController]
[Route("api/cartcheckout")]
public sealed class CartCheckoutController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Checkout.aspx:1
    [HttpGet("cartcheckout/checkout")]
    public IActionResult Checkout()
    {
        return Ok(new { LegacyEndpoint = "/Checkout.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutCompleted.aspx:1
    [HttpGet("cartcheckout/checkoutcompleted")]
    public IActionResult Checkoutcompleted()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutCompleted.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutConfirm.aspx:1
    [HttpGet("cartcheckout/checkoutconfirm")]
    public IActionResult Checkoutconfirm()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutConfirm.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutOnepage.aspx:1
    [HttpGet("cartcheckout/checkoutonepage")]
    public IActionResult Checkoutonepage()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutOnepage.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentInfo.aspx:1
    [HttpGet("cartcheckout/checkoutpaymentinfo")]
    public IActionResult Checkoutpaymentinfo()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutPaymentInfo.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentMethod.aspx:1
    [HttpGet("cartcheckout/checkoutpaymentmethod")]
    public IActionResult Checkoutpaymentmethod()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutPaymentMethod.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingMethod.aspx:1
    [HttpGet("cartcheckout/checkoutshippingmethod")]
    public IActionResult Checkoutshippingmethod()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutShippingMethod.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CurrentShoppingCarts.aspx:1
    [HttpGet("cartcheckout/currentshoppingcarts")]
    public IActionResult Currentshoppingcarts()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CurrentShoppingCarts.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ShoppingCart.aspx:1
    [HttpGet("cartcheckout/shoppingcart")]
    public IActionResult Shoppingcart()
    {
        return Ok(new { LegacyEndpoint = "/ShoppingCart.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutINSHandler.aspx:1
    [HttpGet("cartcheckout/twocheckoutinshandler")]
    public IActionResult Twocheckoutinshandler()
    {
        return Ok(new { LegacyEndpoint = "/TwoCheckoutINSHandler.aspx", Context = "CartCheckout" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutReturn.aspx:1
    [HttpGet("cartcheckout/twocheckoutreturn")]
    public IActionResult Twocheckoutreturn()
    {
        return Ok(new { LegacyEndpoint = "/TwoCheckoutReturn.aspx", Context = "CartCheckout" });
    }

}