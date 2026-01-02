// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Customer.Api.Controllers;

[ApiController]
[Route("api/customer")]
public sealed class CustomerController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Account.aspx:1
    [HttpGet("customer/account")]
    public IActionResult Account()
    {
        return Ok(new { LegacyEndpoint = "/Account.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AccountActivation.aspx:1
    [HttpGet("customer/accountactivation")]
    public IActionResult Accountactivation()
    {
        return Ok(new { LegacyEndpoint = "/AccountActivation.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AddressAdd.aspx:1
    [HttpGet("customer/addressadd")]
    public IActionResult Addressadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/AddressAdd.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AddressDetails.aspx:1
    [HttpGet("customer/addressdetails")]
    public IActionResult Addressdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/AddressDetails.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AddressEdit.aspx:1
    [HttpGet("customer/addressedit")]
    public IActionResult Addressedit()
    {
        return Ok(new { LegacyEndpoint = "/AddressEdit.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutBillingAddress.aspx:1
    [HttpGet("customer/checkoutbillingaddress")]
    public IActionResult Checkoutbillingaddress()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutBillingAddress.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingAddress.aspx:1
    [HttpGet("customer/checkoutshippingaddress")]
    public IActionResult Checkoutshippingaddress()
    {
        return Ok(new { LegacyEndpoint = "/CheckoutShippingAddress.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerAdd.aspx:1
    [HttpGet("customer/customeradd")]
    public IActionResult Customeradd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomerAdd.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerDetails.aspx:1
    [HttpGet("customer/customerdetails")]
    public IActionResult Customerdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomerDetails.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerReports.aspx:1
    [HttpGet("customer/customerreports")]
    public IActionResult Customerreports()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomerReports.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleAdd.aspx:1
    [HttpGet("customer/customerroleadd")]
    public IActionResult Customerroleadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomerRoleAdd.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleDetails.aspx:1
    [HttpGet("customer/customerroledetails")]
    public IActionResult Customerroledetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomerRoleDetails.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoles.aspx:1
    [HttpGet("customer/customerroles")]
    public IActionResult Customerroles()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomerRoles.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Customers.aspx:1
    [HttpGet("customer/customers")]
    public IActionResult Customers()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Customers.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomersHome.aspx:1
    [HttpGet("customer/customershome")]
    public IActionResult Customershome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CustomersHome.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountAdd.aspx:1
    [HttpGet("customer/emailaccountadd")]
    public IActionResult Emailaccountadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/EmailAccountAdd.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountDetails.aspx:1
    [HttpGet("customer/emailaccountdetails")]
    public IActionResult Emailaccountdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/EmailAccountDetails.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccounts.aspx:1
    [HttpGet("customer/emailaccounts")]
    public IActionResult Emailaccounts()
    {
        return Ok(new { LegacyEndpoint = "/Administration/EmailAccounts.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\NewsLetterSubscriptionActivation.aspx:1
    [HttpGet("customer/newslettersubscriptionactivation")]
    public IActionResult Newslettersubscriptionactivation()
    {
        return Ok(new { LegacyEndpoint = "/NewsLetterSubscriptionActivation.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsletterSubscribers.aspx:1
    [HttpGet("customer/newslettersubscribers")]
    public IActionResult Newslettersubscribers()
    {
        return Ok(new { LegacyEndpoint = "/Administration/NewsletterSubscribers.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\OnlineCustomers.aspx:1
    [HttpGet("customer/onlinecustomers")]
    public IActionResult Onlinecustomers()
    {
        return Ok(new { LegacyEndpoint = "/Administration/OnlineCustomers.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Profile.aspx:1
    [HttpGet("customer/profile")]
    public IActionResult Profile()
    {
        return Ok(new { LegacyEndpoint = "/Profile.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Wishlist.aspx:1
    [HttpGet("customer/wishlist")]
    public IActionResult Wishlist()
    {
        return Ok(new { LegacyEndpoint = "/Wishlist.aspx", Context = "Customer" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\WishlistEmailAFriend.aspx:1
    [HttpGet("customer/wishlistemailafriend")]
    public IActionResult Wishlistemailafriend()
    {
        return Ok(new { LegacyEndpoint = "/WishlistEmailAFriend.aspx", Context = "Customer" });
    }

}