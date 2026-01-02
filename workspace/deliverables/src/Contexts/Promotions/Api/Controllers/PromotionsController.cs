// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Promotions.Api.Controllers;

[ApiController]
[Route("api/promotions")]
public sealed class PromotionsController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateAdd.aspx:1
    [HttpGet("promotions/affiliateadd")]
    public IActionResult Affiliateadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/AffiliateAdd.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateDetails.aspx:1
    [HttpGet("promotions/affiliatedetails")]
    public IActionResult Affiliatedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/AffiliateDetails.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Affiliates.aspx:1
    [HttpGet("promotions/affiliates")]
    public IActionResult Affiliates()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Affiliates.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignAdd.aspx:1
    [HttpGet("promotions/campaignadd")]
    public IActionResult Campaignadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CampaignAdd.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignDetails.aspx:1
    [HttpGet("promotions/campaigndetails")]
    public IActionResult Campaigndetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CampaignDetails.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Campaigns.aspx:1
    [HttpGet("promotions/campaigns")]
    public IActionResult Campaigns()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Campaigns.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountAdd.aspx:1
    [HttpGet("promotions/discountadd")]
    public IActionResult Discountadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/DiscountAdd.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountDetails.aspx:1
    [HttpGet("promotions/discountdetails")]
    public IActionResult Discountdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/DiscountDetails.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Discounts.aspx:1
    [HttpGet("promotions/discounts")]
    public IActionResult Discounts()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Discounts.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\GiftCardDetails.aspx:1
    [HttpGet("promotions/giftcarddetails")]
    public IActionResult Giftcarddetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/GiftCardDetails.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionProviders.aspx:1
    [HttpGet("promotions/promotionproviders")]
    public IActionResult Promotionproviders()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PromotionProviders.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionsHome.aspx:1
    [HttpGet("promotions/promotionshome")]
    public IActionResult Promotionshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PromotionsHome.aspx", Context = "Promotions" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PurchasedGiftCards.aspx:1
    [HttpGet("promotions/purchasedgiftcards")]
    public IActionResult Purchasedgiftcards()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PurchasedGiftCards.aspx", Context = "Promotions" });
    }

}