// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;
using Migration.Catalog.Api.Models;

namespace Migration.Catalog.Api.Controllers;

[ApiController]
[Route("api/catalog")]
public sealed class CatalogController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ACL.aspx:1
    [HttpGet("catalog/acl")]
    public IActionResult Acl()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ACL.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ACL.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AboutUs.aspx:1
    [HttpGet("catalog/aboutus")]
    public IActionResult Aboutus()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/AboutUs.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\AboutUs.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AccessDenied.aspx:1
    [HttpGet("catalog/accessdenied")]
    public IActionResult Accessdenied()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/AccessDenied.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\AccessDenied.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Account.aspx:1
    [HttpGet("catalog/account")]
    public IActionResult Account()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Account.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Account.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AccountActivation.aspx:1
    [HttpGet("catalog/accountactivation")]
    public IActionResult Accountactivation()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/AccountActivation.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\AccountActivation.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\ActiveDiscussions.aspx:1
    [HttpGet("catalog/activediscussions")]
    public IActionResult Activediscussions()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/ActiveDiscussions.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\ActiveDiscussions.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLog.aspx:1
    [HttpGet("catalog/activitylog")]
    public IActionResult Activitylog()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ActivityLog.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLog.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLogHome.aspx:1
    [HttpGet("catalog/activityloghome")]
    public IActionResult Activityloghome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ActivityLogHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLogHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityTypes.aspx:1
    [HttpGet("catalog/activitytypes")]
    public IActionResult Activitytypes()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ActivityTypes.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityTypes.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AddressAdd.aspx:1
    [HttpGet("catalog/addressadd")]
    public IActionResult Addressadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/AddressAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\AddressAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AddressDetails.aspx:1
    [HttpGet("catalog/addressdetails")]
    public IActionResult Addressdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/AddressDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\AddressDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AddressEdit.aspx:1
    [HttpGet("catalog/addressedit")]
    public IActionResult Addressedit()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/AddressEdit.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\AddressEdit.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateAdd.aspx:1
    [HttpGet("catalog/affiliateadd")]
    public IActionResult Affiliateadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/AffiliateAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateDetails.aspx:1
    [HttpGet("catalog/affiliatedetails")]
    public IActionResult Affiliatedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/AffiliateDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Affiliates.aspx:1
    [HttpGet("catalog/affiliates")]
    public IActionResult Affiliates()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Affiliates.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Affiliates.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Alipay_Notify.aspx:1
    [HttpGet("catalog/alipay-notify")]
    public IActionResult AlipayNotify()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Alipay_Notify.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Alipay_Notify.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Alipay_Return.aspx:1
    [HttpGet("catalog/alipay-return")]
    public IActionResult AlipayReturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Alipay_Return.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Alipay_Return.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AmazonSimplePayReturn.aspx:1
    [HttpGet("catalog/amazonsimplepayreturn")]
    public IActionResult Amazonsimplepayreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/AmazonSimplePayReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\AmazonSimplePayReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AssistHostedPaymentReturn.aspx:1
    [HttpGet("catalog/assisthostedpaymentreturn")]
    public IActionResult Assisthostedpaymentreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/AssistHostedPaymentReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\AssistHostedPaymentReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AttributesHome.aspx:1
    [HttpGet("catalog/attributeshome")]
    public IActionResult Attributeshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/AttributesHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\AttributesHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\BeanstreamHostedPaymentReturn.aspx:1
    [HttpGet("catalog/beanstreamhostedpaymentreturn")]
    public IActionResult Beanstreamhostedpaymentreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/BeanstreamHostedPaymentReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\BeanstreamHostedPaymentReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Blacklist.aspx:1
    [HttpGet("catalog/blacklist")]
    public IActionResult Blacklist()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Blacklist.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Blacklist.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPAdd.aspx:1
    [HttpGet("catalog/blacklistipadd")]
    public IActionResult Blacklistipadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlacklistIPAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPDetails.aspx:1
    [HttpGet("catalog/blacklistipdetails")]
    public IActionResult Blacklistipdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlacklistIPDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkAdd.aspx:1
    [HttpGet("catalog/blacklistnetworkadd")]
    public IActionResult Blacklistnetworkadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlacklistNetworkAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkDetails.aspx:1
    [HttpGet("catalog/blacklistnetworkdetails")]
    public IActionResult Blacklistnetworkdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlacklistNetworkDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Blog.aspx:1
    [HttpGet("catalog/blog")]
    public IActionResult Blog()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Blog.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Blog.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Blog.aspx:1
    [HttpGet("catalog/blog")]
    public IActionResult Blog()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Blog.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Blog.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogCommentDetails.aspx:1
    [HttpGet("catalog/blogcommentdetails")]
    public IActionResult Blogcommentdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlogCommentDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlogCommentDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogComments.aspx:1
    [HttpGet("catalog/blogcomments")]
    public IActionResult Blogcomments()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlogComments.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlogComments.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogHome.aspx:1
    [HttpGet("catalog/bloghome")]
    public IActionResult Bloghome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlogHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlogHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\BlogPost.aspx:1
    [HttpGet("catalog/blogpost")]
    public IActionResult Blogpost()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/BlogPost.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\BlogPost.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostAdd.aspx:1
    [HttpGet("catalog/blogpostadd")]
    public IActionResult Blogpostadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlogPostAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostDetails.aspx:1
    [HttpGet("catalog/blogpostdetails")]
    public IActionResult Blogpostdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlogPostDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\BlogRSS.aspx:1
    [HttpGet("catalog/blogrss")]
    public IActionResult Blogrss()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/BlogRSS.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\BlogRSS.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BlogSettings.aspx:1
    [HttpGet("catalog/blogsettings")]
    public IActionResult Blogsettings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BlogSettings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BlogSettings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\BulkEditProducts.aspx:1
    [HttpGet("catalog/bulkeditproducts")]
    public IActionResult Bulkeditproducts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/BulkEditProducts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\BulkEditProducts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CCAvenueReturn.aspx:1
    [HttpGet("catalog/ccavenuereturn")]
    public IActionResult Ccavenuereturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CCAvenueReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CCAvenueReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignAdd.aspx:1
    [HttpGet("catalog/campaignadd")]
    public IActionResult Campaignadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CampaignAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignDetails.aspx:1
    [HttpGet("catalog/campaigndetails")]
    public IActionResult Campaigndetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CampaignDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Campaigns.aspx:1
    [HttpGet("catalog/campaigns")]
    public IActionResult Campaigns()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Campaigns.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Campaigns.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CaptchaImage.aspx:1
    [HttpGet("catalog/captchaimage")]
    public IActionResult Captchaimage()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CaptchaImage.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CaptchaImage.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CatalogHome.aspx:1
    [HttpGet("catalog/cataloghome")]
    public IActionResult Cataloghome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CatalogHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CatalogHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Categories.aspx:1
    [HttpGet("catalog/categories")]
    public IActionResult Categories()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Categories.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Categories.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Category.aspx:1
    [HttpGet("catalog/category")]
    public IActionResult Category()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Category.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Category.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryAdd.aspx:1
    [HttpGet("catalog/categoryadd")]
    public IActionResult Categoryadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CategoryAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryDetails.aspx:1
    [HttpGet("catalog/categorydetails")]
    public IActionResult Categorydetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CategoryDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryProductAdd.aspx:1
    [HttpGet("catalog/categoryproductadd")]
    public IActionResult Categoryproductadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CategoryProductAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryProductAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplateAdd.aspx:1
    [HttpGet("catalog/categorytemplateadd")]
    public IActionResult Categorytemplateadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CategoryTemplateAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplateAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplateDetails.aspx:1
    [HttpGet("catalog/categorytemplatedetails")]
    public IActionResult Categorytemplatedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CategoryTemplateDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplateDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplates.aspx:1
    [HttpGet("catalog/categorytemplates")]
    public IActionResult Categorytemplates()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CategoryTemplates.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplates.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Checkout.aspx:1
    [HttpGet("catalog/checkout")]
    public IActionResult Checkout()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Checkout.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Checkout.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeAdd.aspx:1
    [HttpGet("catalog/checkoutattributeadd")]
    public IActionResult Checkoutattributeadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CheckoutAttributeAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeDetails.aspx:1
    [HttpGet("catalog/checkoutattributedetails")]
    public IActionResult Checkoutattributedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CheckoutAttributeDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributes.aspx:1
    [HttpGet("catalog/checkoutattributes")]
    public IActionResult Checkoutattributes()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CheckoutAttributes.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributes.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutBillingAddress.aspx:1
    [HttpGet("catalog/checkoutbillingaddress")]
    public IActionResult Checkoutbillingaddress()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutBillingAddress.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutBillingAddress.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutCompleted.aspx:1
    [HttpGet("catalog/checkoutcompleted")]
    public IActionResult Checkoutcompleted()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutCompleted.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutCompleted.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutConfirm.aspx:1
    [HttpGet("catalog/checkoutconfirm")]
    public IActionResult Checkoutconfirm()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutConfirm.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutConfirm.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutOnepage.aspx:1
    [HttpGet("catalog/checkoutonepage")]
    public IActionResult Checkoutonepage()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutOnepage.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutOnepage.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentInfo.aspx:1
    [HttpGet("catalog/checkoutpaymentinfo")]
    public IActionResult Checkoutpaymentinfo()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutPaymentInfo.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentInfo.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentMethod.aspx:1
    [HttpGet("catalog/checkoutpaymentmethod")]
    public IActionResult Checkoutpaymentmethod()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutPaymentMethod.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentMethod.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingAddress.aspx:1
    [HttpGet("catalog/checkoutshippingaddress")]
    public IActionResult Checkoutshippingaddress()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutShippingAddress.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingAddress.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingMethod.aspx:1
    [HttpGet("catalog/checkoutshippingmethod")]
    public IActionResult Checkoutshippingmethod()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CheckoutShippingMethod.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingMethod.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1
    [HttpGet("catalog/chronopayipnhandler")]
    public IActionResult Chronopayipnhandler()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ChronoPayIPNHandler.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CompareProducts.aspx:1
    [HttpGet("catalog/compareproducts")]
    public IActionResult Compareproducts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CompareProducts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CompareProducts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ConditionsInfo.aspx:1
    [HttpGet("catalog/conditionsinfo")]
    public IActionResult Conditionsinfo()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ConditionsInfo.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ConditionsInfo.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ConditionsInfoPopup.aspx:1
    [HttpGet("catalog/conditionsinfopopup")]
    public IActionResult Conditionsinfopopup()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ConditionsInfoPopup.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ConditionsInfoPopup.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ConfigurationHome.aspx:1
    [HttpGet("catalog/configurationhome")]
    public IActionResult Configurationhome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ConfigurationHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ConfigurationHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ContactUs.aspx:1
    [HttpGet("catalog/contactus")]
    public IActionResult Contactus()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ContactUs.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ContactUs.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ContentManagementHome.aspx:1
    [HttpGet("catalog/contentmanagementhome")]
    public IActionResult Contentmanagementhome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ContentManagementHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ContentManagementHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Countries.aspx:1
    [HttpGet("catalog/countries")]
    public IActionResult Countries()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Countries.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Countries.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CountryAdd.aspx:1
    [HttpGet("catalog/countryadd")]
    public IActionResult Countryadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CountryAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CountryAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CountryDetails.aspx:1
    [HttpGet("catalog/countrydetails")]
    public IActionResult Countrydetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CountryDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CountryDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeAdd.aspx:1
    [HttpGet("catalog/creditcardtypeadd")]
    public IActionResult Creditcardtypeadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CreditCardTypeAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeDetails.aspx:1
    [HttpGet("catalog/creditcardtypedetails")]
    public IActionResult Creditcardtypedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CreditCardTypeDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypes.aspx:1
    [HttpGet("catalog/creditcardtypes")]
    public IActionResult Creditcardtypes()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CreditCardTypes.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypes.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CrossSellProductAdd.aspx:1
    [HttpGet("catalog/crosssellproductadd")]
    public IActionResult Crosssellproductadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CrossSellProductAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CrossSellProductAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Currencies.aspx:1
    [HttpGet("catalog/currencies")]
    public IActionResult Currencies()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Currencies.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Currencies.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyAdd.aspx:1
    [HttpGet("catalog/currencyadd")]
    public IActionResult Currencyadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CurrencyAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyDetails.aspx:1
    [HttpGet("catalog/currencydetails")]
    public IActionResult Currencydetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CurrencyDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CurrentShoppingCarts.aspx:1
    [HttpGet("catalog/currentshoppingcarts")]
    public IActionResult Currentshoppingcarts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CurrentShoppingCarts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CurrentShoppingCarts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerAdd.aspx:1
    [HttpGet("catalog/customeradd")]
    public IActionResult Customeradd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomerAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerDetails.aspx:1
    [HttpGet("catalog/customerdetails")]
    public IActionResult Customerdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomerDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerReports.aspx:1
    [HttpGet("catalog/customerreports")]
    public IActionResult Customerreports()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomerReports.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerReports.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleAdd.aspx:1
    [HttpGet("catalog/customerroleadd")]
    public IActionResult Customerroleadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomerRoleAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleDetails.aspx:1
    [HttpGet("catalog/customerroledetails")]
    public IActionResult Customerroledetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomerRoleDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoles.aspx:1
    [HttpGet("catalog/customerroles")]
    public IActionResult Customerroles()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomerRoles.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoles.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Customers.aspx:1
    [HttpGet("catalog/customers")]
    public IActionResult Customers()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Customers.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Customers.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CustomersHome.aspx:1
    [HttpGet("catalog/customershome")]
    public IActionResult Customershome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/CustomersHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\CustomersHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CyberSourceIPNHandler.aspx:1
    [HttpGet("catalog/cybersourceipnhandler")]
    public IActionResult Cybersourceipnhandler()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/CyberSourceIPNHandler.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\CyberSourceIPNHandler.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Default.aspx:1
    [HttpGet("catalog/default")]
    public IActionResult Default()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/Default.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\Default.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Default.aspx:1
    [HttpGet("catalog/default")]
    public IActionResult Default()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Default.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Default.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Default.aspx:1
    [HttpGet("catalog/default")]
    public IActionResult Default()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Default.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Default.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\DibsFlexWinReturn.aspx:1
    [HttpGet("catalog/dibsflexwinreturn")]
    public IActionResult Dibsflexwinreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/DibsFlexWinReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\DibsFlexWinReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountAdd.aspx:1
    [HttpGet("catalog/discountadd")]
    public IActionResult Discountadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/DiscountAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountDetails.aspx:1
    [HttpGet("catalog/discountdetails")]
    public IActionResult Discountdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/DiscountDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Discounts.aspx:1
    [HttpGet("catalog/discounts")]
    public IActionResult Discounts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Discounts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Discounts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountAdd.aspx:1
    [HttpGet("catalog/emailaccountadd")]
    public IActionResult Emailaccountadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/EmailAccountAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountDetails.aspx:1
    [HttpGet("catalog/emailaccountdetails")]
    public IActionResult Emailaccountdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/EmailAccountDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccounts.aspx:1
    [HttpGet("catalog/emailaccounts")]
    public IActionResult Emailaccounts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/EmailAccounts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccounts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Forum.aspx:1
    [HttpGet("catalog/forum")]
    public IActionResult Forum()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/Forum.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\Forum.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumAdd.aspx:1
    [HttpGet("catalog/forumadd")]
    public IActionResult Forumadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ForumAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ForumAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumDetails.aspx:1
    [HttpGet("catalog/forumdetails")]
    public IActionResult Forumdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ForumDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ForumDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\ForumGroup.aspx:1
    [HttpGet("catalog/forumgroup")]
    public IActionResult Forumgroup()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/ForumGroup.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\ForumGroup.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupAdd.aspx:1
    [HttpGet("catalog/forumgroupadd")]
    public IActionResult Forumgroupadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ForumGroupAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupDetails.aspx:1
    [HttpGet("catalog/forumgroupdetails")]
    public IActionResult Forumgroupdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ForumGroupDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Forums.aspx:1
    [HttpGet("catalog/forums")]
    public IActionResult Forums()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Forums.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Forums.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsHome.aspx:1
    [HttpGet("catalog/forumshome")]
    public IActionResult Forumshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ForumsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsSettings.aspx:1
    [HttpGet("catalog/forumssettings")]
    public IActionResult Forumssettings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ForumsSettings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsSettings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\GiftCardDetails.aspx:1
    [HttpGet("catalog/giftcarddetails")]
    public IActionResult Giftcarddetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/GiftCardDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\GiftCardDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\GlobalSettings.aspx:1
    [HttpGet("catalog/globalsettings")]
    public IActionResult Globalsettings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/GlobalSettings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\GlobalSettings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\GooglePostHandler.aspx:1
    [HttpGet("catalog/googleposthandler")]
    public IActionResult Googleposthandler()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/GooglePostHandler.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\GooglePostHandler.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\HelpHome.aspx:1
    [HttpGet("catalog/helphome")]
    public IActionResult Helphome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/HelpHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\HelpHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\IdealNotify.aspx:1
    [HttpGet("catalog/idealnotify")]
    public IActionResult Idealnotify()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/IdealNotify.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\IdealNotify.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\IdealReturn.aspx:1
    [HttpGet("catalog/idealreturn")]
    public IActionResult Idealreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/IdealReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\IdealReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageAdd.aspx:1
    [HttpGet("catalog/languageadd")]
    public IActionResult Languageadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LanguageAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageDetails.aspx:1
    [HttpGet("catalog/languagedetails")]
    public IActionResult Languagedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LanguageDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Languages.aspx:1
    [HttpGet("catalog/languages")]
    public IActionResult Languages()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Languages.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Languages.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceAdd.aspx:1
    [HttpGet("catalog/localestringresourceadd")]
    public IActionResult Localestringresourceadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LocaleStringResourceAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceDetails.aspx:1
    [HttpGet("catalog/localestringresourcedetails")]
    public IActionResult Localestringresourcedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LocaleStringResourceDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResources.aspx:1
    [HttpGet("catalog/localestringresources")]
    public IActionResult Localestringresources()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LocaleStringResources.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResources.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocationSettingsHome.aspx:1
    [HttpGet("catalog/locationsettingshome")]
    public IActionResult Locationsettingshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LocationSettingsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LocationSettingsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LogDetails.aspx:1
    [HttpGet("catalog/logdetails")]
    public IActionResult Logdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/LogDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\LogDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Login.aspx:1
    [HttpGet("catalog/login")]
    public IActionResult Login()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Login.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Login.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Login.aspx:1
    [HttpGet("catalog/login")]
    public IActionResult Login()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Login.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Login.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Logout.aspx:1
    [HttpGet("catalog/logout")]
    public IActionResult Logout()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Logout.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Logout.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Logout.aspx:1
    [HttpGet("catalog/logout")]
    public IActionResult Logout()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Logout.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Logout.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Logs.aspx:1
    [HttpGet("catalog/logs")]
    public IActionResult Logs()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Logs.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Logs.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Maintenance.aspx:1
    [HttpGet("catalog/maintenance")]
    public IActionResult Maintenance()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Maintenance.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Maintenance.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Manufacturer.aspx:1
    [HttpGet("catalog/manufacturer")]
    public IActionResult Manufacturer()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Manufacturer.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Manufacturer.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerAdd.aspx:1
    [HttpGet("catalog/manufactureradd")]
    public IActionResult Manufactureradd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ManufacturerAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerDetails.aspx:1
    [HttpGet("catalog/manufacturerdetails")]
    public IActionResult Manufacturerdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ManufacturerDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerProductAdd.aspx:1
    [HttpGet("catalog/manufacturerproductadd")]
    public IActionResult Manufacturerproductadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ManufacturerProductAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerProductAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplateAdd.aspx:1
    [HttpGet("catalog/manufacturertemplateadd")]
    public IActionResult Manufacturertemplateadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ManufacturerTemplateAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplateAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplateDetails.aspx:1
    [HttpGet("catalog/manufacturertemplatedetails")]
    public IActionResult Manufacturertemplatedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ManufacturerTemplateDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplateDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplates.aspx:1
    [HttpGet("catalog/manufacturertemplates")]
    public IActionResult Manufacturertemplates()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ManufacturerTemplates.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplates.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Manufacturers.aspx:1
    [HttpGet("catalog/manufacturers")]
    public IActionResult Manufacturers()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Manufacturers.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Manufacturers.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Manufacturers.aspx:1
    [HttpGet("catalog/manufacturers")]
    public IActionResult Manufacturers()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Manufacturers.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Manufacturers.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionAdd.aspx:1
    [HttpGet("catalog/measuredimensionadd")]
    public IActionResult Measuredimensionadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MeasureDimensionAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionDetails.aspx:1
    [HttpGet("catalog/measuredimensiondetails")]
    public IActionResult Measuredimensiondetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MeasureDimensionDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightAdd.aspx:1
    [HttpGet("catalog/measureweightadd")]
    public IActionResult Measureweightadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MeasureWeightAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightDetails.aspx:1
    [HttpGet("catalog/measureweightdetails")]
    public IActionResult Measureweightdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MeasureWeightDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Measures.aspx:1
    [HttpGet("catalog/measures")]
    public IActionResult Measures()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Measures.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Measures.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueue.aspx:1
    [HttpGet("catalog/messagequeue")]
    public IActionResult Messagequeue()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MessageQueue.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueue.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueueDetails.aspx:1
    [HttpGet("catalog/messagequeuedetails")]
    public IActionResult Messagequeuedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MessageQueueDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueueDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplateDetails.aspx:1
    [HttpGet("catalog/messagetemplatedetails")]
    public IActionResult Messagetemplatedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MessageTemplateDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplateDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplates.aspx:1
    [HttpGet("catalog/messagetemplates")]
    public IActionResult Messagetemplates()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/MessageTemplates.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplates.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\MonerisHostedPaymentReturn.aspx:1
    [HttpGet("catalog/monerishostedpaymentreturn")]
    public IActionResult Monerishostedpaymentreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/MonerisHostedPaymentReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\MonerisHostedPaymentReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\MoneybookersReturn.aspx:1
    [HttpGet("catalog/moneybookersreturn")]
    public IActionResult Moneybookersreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/MoneybookersReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\MoneybookersReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\MoveTopic.aspx:1
    [HttpGet("catalog/movetopic")]
    public IActionResult Movetopic()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/MoveTopic.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\MoveTopic.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\News.aspx:1
    [HttpGet("catalog/news")]
    public IActionResult News()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/News.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\News.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\News.aspx:1
    [HttpGet("catalog/news")]
    public IActionResult News()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/News.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\News.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsAdd.aspx:1
    [HttpGet("catalog/newsadd")]
    public IActionResult Newsadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\NewsArchive.aspx:1
    [HttpGet("catalog/newsarchive")]
    public IActionResult Newsarchive()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/NewsArchive.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\NewsArchive.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsCommentDetails.aspx:1
    [HttpGet("catalog/newscommentdetails")]
    public IActionResult Newscommentdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsCommentDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsCommentDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsComments.aspx:1
    [HttpGet("catalog/newscomments")]
    public IActionResult Newscomments()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsComments.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsComments.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsDetails.aspx:1
    [HttpGet("catalog/newsdetails")]
    public IActionResult Newsdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsHome.aspx:1
    [HttpGet("catalog/newshome")]
    public IActionResult Newshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\NewsLetterSubscriptionActivation.aspx:1
    [HttpGet("catalog/newslettersubscriptionactivation")]
    public IActionResult Newslettersubscriptionactivation()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/NewsLetterSubscriptionActivation.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\NewsLetterSubscriptionActivation.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\NewsRSS.aspx:1
    [HttpGet("catalog/newsrss")]
    public IActionResult Newsrss()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/NewsRSS.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\NewsRSS.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsSettings.aspx:1
    [HttpGet("catalog/newssettings")]
    public IActionResult Newssettings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsSettings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsSettings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\NewsletterSubscribers.aspx:1
    [HttpGet("catalog/newslettersubscribers")]
    public IActionResult Newslettersubscribers()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/NewsletterSubscribers.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\NewsletterSubscribers.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\OnlineCustomers.aspx:1
    [HttpGet("catalog/onlinecustomers")]
    public IActionResult Onlinecustomers()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/OnlineCustomers.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\OnlineCustomers.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\OrderDetails.aspx:1
    [HttpGet("catalog/orderdetails")]
    public IActionResult Orderdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/OrderDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\OrderDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\OrderDetails.aspx:1
    [HttpGet("catalog/orderdetails")]
    public IActionResult Orderdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/OrderDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\OrderDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\OrderPartialRefund.aspx:1
    [HttpGet("catalog/orderpartialrefund")]
    public IActionResult Orderpartialrefund()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/OrderPartialRefund.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\OrderPartialRefund.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Orders.aspx:1
    [HttpGet("catalog/orders")]
    public IActionResult Orders()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Orders.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Orders.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PasswordRecovery.aspx:1
    [HttpGet("catalog/passwordrecovery")]
    public IActionResult Passwordrecovery()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PasswordRecovery.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PasswordRecovery.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PayPointHostedPaymentReturn.aspx:1
    [HttpGet("catalog/paypointhostedpaymentreturn")]
    public IActionResult Paypointhostedpaymentreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PayPointHostedPaymentReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PayPointHostedPaymentReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodAdd.aspx:1
    [HttpGet("catalog/paymentmethodadd")]
    public IActionResult Paymentmethodadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PaymentMethodAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodDetails.aspx:1
    [HttpGet("catalog/paymentmethoddetails")]
    public IActionResult Paymentmethoddetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PaymentMethodDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethods.aspx:1
    [HttpGet("catalog/paymentmethods")]
    public IActionResult Paymentmethods()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PaymentMethods.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethods.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentSettingsHome.aspx:1
    [HttpGet("catalog/paymentsettingshome")]
    public IActionResult Paymentsettingshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PaymentSettingsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentSettingsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalCancel.aspx:1
    [HttpGet("catalog/paypalcancel")]
    public IActionResult Paypalcancel()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PaypalCancel.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PaypalCancel.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalExpressReturn.aspx:1
    [HttpGet("catalog/paypalexpressreturn")]
    public IActionResult Paypalexpressreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PaypalExpressReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PaypalExpressReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalIPNHandler.aspx:1
    [HttpGet("catalog/paypalipnhandler")]
    public IActionResult Paypalipnhandler()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PaypalIPNHandler.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PaypalIPNHandler.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PaypalPDTHandler.aspx:1
    [HttpGet("catalog/paypalpdthandler")]
    public IActionResult Paypalpdthandler()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PaypalPDTHandler.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PaypalPDTHandler.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PictureBrowser.aspx:1
    [HttpGet("catalog/picturebrowser")]
    public IActionResult Picturebrowser()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PictureBrowser.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PictureBrowser.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PollAdd.aspx:1
    [HttpGet("catalog/polladd")]
    public IActionResult Polladd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PollAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PollAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PollDetails.aspx:1
    [HttpGet("catalog/polldetails")]
    public IActionResult Polldetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PollDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PollDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Polls.aspx:1
    [HttpGet("catalog/polls")]
    public IActionResult Polls()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Polls.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Polls.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\PostEdit.aspx:1
    [HttpGet("catalog/postedit")]
    public IActionResult Postedit()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/PostEdit.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\PostEdit.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\PostNew.aspx:1
    [HttpGet("catalog/postnew")]
    public IActionResult Postnew()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/PostNew.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\PostNew.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Pricelist.aspx:1
    [HttpGet("catalog/pricelist")]
    public IActionResult Pricelist()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Pricelist.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Pricelist.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PricelistAdd.aspx:1
    [HttpGet("catalog/pricelistadd")]
    public IActionResult Pricelistadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PricelistAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PricelistAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PricelistDetails.aspx:1
    [HttpGet("catalog/pricelistdetails")]
    public IActionResult Pricelistdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PricelistDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PricelistDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PrintOrderDetails.aspx:1
    [HttpGet("catalog/printorderdetails")]
    public IActionResult Printorderdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PrintOrderDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PrintOrderDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PrivacyInfo.aspx:1
    [HttpGet("catalog/privacyinfo")]
    public IActionResult Privacyinfo()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PrivacyInfo.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PrivacyInfo.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PrivateMessages.aspx:1
    [HttpGet("catalog/privatemessages")]
    public IActionResult Privatemessages()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/PrivateMessages.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\PrivateMessages.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Product.aspx:1
    [HttpGet("catalog/product")]
    public IActionResult Product()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Product.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Product.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAdd.aspx:1
    [HttpGet("catalog/productadd")]
    public IActionResult Productadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributeAdd.aspx:1
    [HttpGet("catalog/productattributeadd")]
    public IActionResult Productattributeadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductAttributeAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributeAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributeDetails.aspx:1
    [HttpGet("catalog/productattributedetails")]
    public IActionResult Productattributedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductAttributeDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributeDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributes.aspx:1
    [HttpGet("catalog/productattributes")]
    public IActionResult Productattributes()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductAttributes.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributes.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductDetails.aspx:1
    [HttpGet("catalog/productdetails")]
    public IActionResult Productdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ProductEmailAFriend.aspx:1
    [HttpGet("catalog/productemailafriend")]
    public IActionResult Productemailafriend()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ProductEmailAFriend.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ProductEmailAFriend.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ProductReviewAdd.aspx:1
    [HttpGet("catalog/productreviewadd")]
    public IActionResult Productreviewadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ProductReviewAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ProductReviewAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductReviewDetails.aspx:1
    [HttpGet("catalog/productreviewdetails")]
    public IActionResult Productreviewdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductReviewDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductReviewDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductReviews.aspx:1
    [HttpGet("catalog/productreviews")]
    public IActionResult Productreviews()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductReviews.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductReviews.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ProductTag.aspx:1
    [HttpGet("catalog/producttag")]
    public IActionResult Producttag()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ProductTag.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ProductTag.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTags.aspx:1
    [HttpGet("catalog/producttags")]
    public IActionResult Producttags()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductTags.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTags.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplateAdd.aspx:1
    [HttpGet("catalog/producttemplateadd")]
    public IActionResult Producttemplateadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductTemplateAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplateAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplateDetails.aspx:1
    [HttpGet("catalog/producttemplatedetails")]
    public IActionResult Producttemplatedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductTemplateDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplateDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplates.aspx:1
    [HttpGet("catalog/producttemplates")]
    public IActionResult Producttemplates()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductTemplates.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplates.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantAdd.aspx:1
    [HttpGet("catalog/productvariantadd")]
    public IActionResult Productvariantadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductVariantAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantAttributeValues.aspx:1
    [HttpGet("catalog/productvariantattributevalues")]
    public IActionResult Productvariantattributevalues()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductVariantAttributeValues.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantAttributeValues.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantDetails.aspx:1
    [HttpGet("catalog/productvariantdetails")]
    public IActionResult Productvariantdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductVariantDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantsLowStock.aspx:1
    [HttpGet("catalog/productvariantslowstock")]
    public IActionResult Productvariantslowstock()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductVariantsLowStock.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantsLowStock.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Products.aspx:1
    [HttpGet("catalog/products")]
    public IActionResult Products()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Products.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Products.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ProductsHome.aspx:1
    [HttpGet("catalog/productshome")]
    public IActionResult Productshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ProductsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ProductsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Profile.aspx:1
    [HttpGet("catalog/profile")]
    public IActionResult Profile()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Profile.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Profile.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionProviders.aspx:1
    [HttpGet("catalog/promotionproviders")]
    public IActionResult Promotionproviders()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PromotionProviders.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionProviders.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionsHome.aspx:1
    [HttpGet("catalog/promotionshome")]
    public IActionResult Promotionshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PromotionsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PurchasedGiftCards.aspx:1
    [HttpGet("catalog/purchasedgiftcards")]
    public IActionResult Purchasedgiftcards()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/PurchasedGiftCards.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\PurchasedGiftCards.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\QuickPayCancel.aspx:1
    [HttpGet("catalog/quickpaycancel")]
    public IActionResult Quickpaycancel()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/QuickPayCancel.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\QuickPayCancel.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\QuickPayReturn.aspx:1
    [HttpGet("catalog/quickpayreturn")]
    public IActionResult Quickpayreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/QuickPayReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\QuickPayReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\RecentlyAddedProducts.aspx:1
    [HttpGet("catalog/recentlyaddedproducts")]
    public IActionResult Recentlyaddedproducts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/RecentlyAddedProducts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\RecentlyAddedProducts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\RecentlyAddedProductsRSS.aspx:1
    [HttpGet("catalog/recentlyaddedproductsrss")]
    public IActionResult Recentlyaddedproductsrss()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/RecentlyAddedProductsRSS.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\RecentlyAddedProductsRSS.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\RecentlyViewedProducts.aspx:1
    [HttpGet("catalog/recentlyviewedproducts")]
    public IActionResult Recentlyviewedproducts()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/RecentlyViewedProducts.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\RecentlyViewedProducts.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPaymentDetails.aspx:1
    [HttpGet("catalog/recurringpaymentdetails")]
    public IActionResult Recurringpaymentdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/RecurringPaymentDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPaymentDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPayments.aspx:1
    [HttpGet("catalog/recurringpayments")]
    public IActionResult Recurringpayments()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/RecurringPayments.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPayments.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Register.aspx:1
    [HttpGet("catalog/register")]
    public IActionResult Register()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Register.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Register.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\RelatedProductAdd.aspx:1
    [HttpGet("catalog/relatedproductadd")]
    public IActionResult Relatedproductadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/RelatedProductAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\RelatedProductAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ReturnItems.aspx:1
    [HttpGet("catalog/returnitems")]
    public IActionResult Returnitems()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ReturnItems.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ReturnItems.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequestDetails.aspx:1
    [HttpGet("catalog/returnrequestdetails")]
    public IActionResult Returnrequestdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ReturnRequestDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequestDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequests.aspx:1
    [HttpGet("catalog/returnrequests")]
    public IActionResult Returnrequests()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ReturnRequests.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequests.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SMSProviders.aspx:1
    [HttpGet("catalog/smsproviders")]
    public IActionResult Smsproviders()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SMSProviders.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SMSProviders.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SagePayFailure.aspx:1
    [HttpGet("catalog/sagepayfailure")]
    public IActionResult Sagepayfailure()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SagePayFailure.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SagePayFailure.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SagePaySuccess.aspx:1
    [HttpGet("catalog/sagepaysuccess")]
    public IActionResult Sagepaysuccess()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SagePaySuccess.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SagePaySuccess.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SalesHome.aspx:1
    [HttpGet("catalog/saleshome")]
    public IActionResult Saleshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SalesHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SalesHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SalesReport.aspx:1
    [HttpGet("catalog/salesreport")]
    public IActionResult Salesreport()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SalesReport.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SalesReport.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Search.aspx:1
    [HttpGet("catalog/search")]
    public IActionResult Search()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/Search.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\Search.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Search.aspx:1
    [HttpGet("catalog/search")]
    public IActionResult Search()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Search.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Search.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SendPM.aspx:1
    [HttpGet("catalog/sendpm")]
    public IActionResult Sendpm()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SendPM.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SendPM.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SermepaError.aspx:1
    [HttpGet("catalog/sermepaerror")]
    public IActionResult Sermepaerror()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SermepaError.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SermepaError.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SermepaReturn.aspx:1
    [HttpGet("catalog/sermepareturn")]
    public IActionResult Sermepareturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SermepaReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SermepaReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SettingAdd.aspx:1
    [HttpGet("catalog/settingadd")]
    public IActionResult Settingadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SettingAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SettingAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SettingDetails.aspx:1
    [HttpGet("catalog/settingdetails")]
    public IActionResult Settingdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SettingDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SettingDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Settings.aspx:1
    [HttpGet("catalog/settings")]
    public IActionResult Settings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Settings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Settings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ShippingInfo.aspx:1
    [HttpGet("catalog/shippinginfo")]
    public IActionResult Shippinginfo()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ShippingInfo.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ShippingInfo.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethodAdd.aspx:1
    [HttpGet("catalog/shippingmethodadd")]
    public IActionResult Shippingmethodadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingMethodAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethodAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethodDetails.aspx:1
    [HttpGet("catalog/shippingmethoddetails")]
    public IActionResult Shippingmethoddetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingMethodDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethodDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethods.aspx:1
    [HttpGet("catalog/shippingmethods")]
    public IActionResult Shippingmethods()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingMethods.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethods.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethodAdd.aspx:1
    [HttpGet("catalog/shippingratecomputationmethodadd")]
    public IActionResult Shippingratecomputationmethodadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingRateComputationMethodAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethodAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethodDetails.aspx:1
    [HttpGet("catalog/shippingratecomputationmethoddetails")]
    public IActionResult Shippingratecomputationmethoddetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingRateComputationMethodDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethodDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethods.aspx:1
    [HttpGet("catalog/shippingratecomputationmethods")]
    public IActionResult Shippingratecomputationmethods()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingRateComputationMethods.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethods.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingSettings.aspx:1
    [HttpGet("catalog/shippingsettings")]
    public IActionResult Shippingsettings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingSettings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingSettings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingSettingsHome.aspx:1
    [HttpGet("catalog/shippingsettingshome")]
    public IActionResult Shippingsettingshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ShippingSettingsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingSettingsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ShoppingCart.aspx:1
    [HttpGet("catalog/shoppingcart")]
    public IActionResult Shoppingcart()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ShoppingCart.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ShoppingCart.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Sitemap.aspx:1
    [HttpGet("catalog/sitemap")]
    public IActionResult Sitemap()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Sitemap.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Sitemap.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SitemapSEO.aspx:1
    [HttpGet("catalog/sitemapseo")]
    public IActionResult Sitemapseo()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SitemapSEO.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SitemapSEO.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributeAdd.aspx:1
    [HttpGet("catalog/specificationattributeadd")]
    public IActionResult Specificationattributeadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SpecificationAttributeAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributeAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributeDetails.aspx:1
    [HttpGet("catalog/specificationattributedetails")]
    public IActionResult Specificationattributedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SpecificationAttributeDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributeDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributes.aspx:1
    [HttpGet("catalog/specificationattributes")]
    public IActionResult Specificationattributes()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SpecificationAttributes.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributes.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceAdd.aspx:1
    [HttpGet("catalog/stateprovinceadd")]
    public IActionResult Stateprovinceadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/StateProvinceAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceDetails.aspx:1
    [HttpGet("catalog/stateprovincedetails")]
    public IActionResult Stateprovincedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/StateProvinceDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinces.aspx:1
    [HttpGet("catalog/stateprovinces")]
    public IActionResult Stateprovinces()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/StateProvinces.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinces.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SveaHostedPaymentReturn.aspx:1
    [HttpGet("catalog/sveahostedpaymentreturn")]
    public IActionResult Sveahostedpaymentreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/SveaHostedPaymentReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\SveaHostedPaymentReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SystemHome.aspx:1
    [HttpGet("catalog/systemhome")]
    public IActionResult Systemhome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SystemHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SystemHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SystemInformation.aspx:1
    [HttpGet("catalog/systeminformation")]
    public IActionResult Systeminformation()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/SystemInformation.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\SystemInformation.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategories.aspx:1
    [HttpGet("catalog/taxcategories")]
    public IActionResult Taxcategories()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxCategories.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategories.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategoryAdd.aspx:1
    [HttpGet("catalog/taxcategoryadd")]
    public IActionResult Taxcategoryadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxCategoryAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategoryAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategoryDetails.aspx:1
    [HttpGet("catalog/taxcategorydetails")]
    public IActionResult Taxcategorydetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxCategoryDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategoryDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviderAdd.aspx:1
    [HttpGet("catalog/taxprovideradd")]
    public IActionResult Taxprovideradd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxProviderAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviderAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviderDetails.aspx:1
    [HttpGet("catalog/taxproviderdetails")]
    public IActionResult Taxproviderdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxProviderDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviderDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviders.aspx:1
    [HttpGet("catalog/taxproviders")]
    public IActionResult Taxproviders()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxProviders.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviders.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxSettings.aspx:1
    [HttpGet("catalog/taxsettings")]
    public IActionResult Taxsettings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxSettings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxSettings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TaxSettingsHome.aspx:1
    [HttpGet("catalog/taxsettingshome")]
    public IActionResult Taxsettingshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TaxSettingsHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TaxSettingsHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TemplatesHome.aspx:1
    [HttpGet("catalog/templateshome")]
    public IActionResult Templateshome()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TemplatesHome.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TemplatesHome.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ThirdPartyIntegration.aspx:1
    [HttpGet("catalog/thirdpartyintegration")]
    public IActionResult Thirdpartyintegration()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/ThirdPartyIntegration.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\ThirdPartyIntegration.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\Topic.aspx:1
    [HttpGet("catalog/topic")]
    public IActionResult Topic()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/Topic.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\Topic.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Topic.aspx:1
    [HttpGet("catalog/topic")]
    public IActionResult Topic()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Topic.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Topic.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TopicAdd.aspx:1
    [HttpGet("catalog/topicadd")]
    public IActionResult Topicadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TopicAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TopicAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TopicDetails.aspx:1
    [HttpGet("catalog/topicdetails")]
    public IActionResult Topicdetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/TopicDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\TopicDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\TopicEdit.aspx:1
    [HttpGet("catalog/topicedit")]
    public IActionResult Topicedit()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/TopicEdit.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\TopicEdit.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Boards\TopicNew.aspx:1
    [HttpGet("catalog/topicnew")]
    public IActionResult Topicnew()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Boards/TopicNew.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Boards\TopicNew.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Topics.aspx:1
    [HttpGet("catalog/topics")]
    public IActionResult Topics()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Topics.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Topics.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutINSHandler.aspx:1
    [HttpGet("catalog/twocheckoutinshandler")]
    public IActionResult Twocheckoutinshandler()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/TwoCheckoutINSHandler.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutINSHandler.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutReturn.aspx:1
    [HttpGet("catalog/twocheckoutreturn")]
    public IActionResult Twocheckoutreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/TwoCheckoutReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\USAePayEPaymentFormReturn.aspx:1
    [HttpGet("catalog/usaepayepaymentformreturn")]
    public IActionResult Usaepayepaymentformreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/USAePayEPaymentFormReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\USAePayEPaymentFormReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\UserAgreement.aspx:1
    [HttpGet("catalog/useragreement")]
    public IActionResult Useragreement()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/UserAgreement.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\UserAgreement.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ViewPM.aspx:1
    [HttpGet("catalog/viewpm")]
    public IActionResult Viewpm()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/ViewPM.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\ViewPM.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseAdd.aspx:1
    [HttpGet("catalog/warehouseadd")]
    public IActionResult Warehouseadd()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/WarehouseAdd.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseAdd.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseDetails.aspx:1
    [HttpGet("catalog/warehousedetails")]
    public IActionResult Warehousedetails()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/WarehouseDetails.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseDetails.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Warehouses.aspx:1
    [HttpGet("catalog/warehouses")]
    public IActionResult Warehouses()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Warehouses.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Warehouses.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Warnings.aspx:1
    [HttpGet("catalog/warnings")]
    public IActionResult Warnings()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Administration/Warnings.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Administration\Warnings.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Wishlist.aspx:1
    [HttpGet("catalog/wishlist")]
    public IActionResult Wishlist()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Wishlist.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Wishlist.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\WishlistEmailAFriend.aspx:1
    [HttpGet("catalog/wishlistemailafriend")]
    public IActionResult Wishlistemailafriend()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/WishlistEmailAFriend.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\WishlistEmailAFriend.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\WorldpayReturn.aspx:1
    [HttpGet("catalog/worldpayreturn")]
    public IActionResult Worldpayreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/WorldpayReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\WorldpayReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\connector.aspx:1
    [HttpGet("catalog/connector")]
    public IActionResult Connector()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/editors/fckeditor/editor/filemanager/connectors/aspx/connector.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\connector.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\eWayMerchantReturn.aspx:1
    [HttpGet("catalog/ewaymerchantreturn")]
    public IActionResult Ewaymerchantreturn()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/eWayMerchantReturn.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\eWayMerchantReturn.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Install\install.aspx:1
    [HttpGet("catalog/install")]
    public IActionResult Install()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/Install/install.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\Install\install.aspx:1"
        );
        return Ok(payload);
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\upload.aspx:1
    [HttpGet("catalog/upload")]
    public IActionResult Upload()
    {
        var payload = new EndpointInfo(
            LegacyEndpoint: "/editors/fckeditor/editor/filemanager/connectors/aspx/upload.aspx",
            Context: "Catalog",
            Method: ".aspx",
            Evidence: "nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\upload.aspx:1"
        );
        return Ok(payload);
    }

}