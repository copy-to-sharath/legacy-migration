// Generator: Agent-Code-Gen
// Judge: Agent-Code-Judge
// Status: draft pending judge + human approval
using Microsoft.AspNetCore.Mvc;

namespace Migration.Legacy.Api.Controllers;

[ApiController]
[Route("api/legacy")]
public sealed class LegacyController : ControllerBase
{
    // Evidence: nopCommerce-release-1.90\NopCommerceStore\GetDownload.ashx:1
    [HttpGet("legacy/getdownload")]
    public IActionResult Getdownload()
    {
        return Ok(new { LegacyEndpoint = "/GetDownload.ashx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\GetDownloadAdmin.ashx:1
    [HttpGet("legacy/getdownloadadmin")]
    public IActionResult Getdownloadadmin()
    {
        return Ok(new { LegacyEndpoint = "/Administration/GetDownloadAdmin.ashx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\GetLicense.ashx:1
    [HttpGet("legacy/getlicense")]
    public IActionResult Getlicense()
    {
        return Ok(new { LegacyEndpoint = "/GetLicense.ashx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\KeepAlive\Ping.ashx:1
    [HttpGet("legacy/ping")]
    public IActionResult Ping()
    {
        return Ok(new { LegacyEndpoint = "/KeepAlive/Ping.ashx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\AboutUs.aspx:1
    [HttpGet("legacy/aboutus")]
    public IActionResult Aboutus()
    {
        return Ok(new { LegacyEndpoint = "/AboutUs.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLog.aspx:1
    [HttpGet("legacy/activitylog")]
    public IActionResult Activitylog()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ActivityLog.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLogHome.aspx:1
    [HttpGet("legacy/activityloghome")]
    public IActionResult Activityloghome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ActivityLogHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityTypes.aspx:1
    [HttpGet("legacy/activitytypes")]
    public IActionResult Activitytypes()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ActivityTypes.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CaptchaImage.aspx:1
    [HttpGet("legacy/captchaimage")]
    public IActionResult Captchaimage()
    {
        return Ok(new { LegacyEndpoint = "/CaptchaImage.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Categories.aspx:1
    [HttpGet("legacy/categories")]
    public IActionResult Categories()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Categories.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1
    [HttpGet("legacy/chronopayipnhandler")]
    public IActionResult Chronopayipnhandler()
    {
        return Ok(new { LegacyEndpoint = "/ChronoPayIPNHandler.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ConditionsInfo.aspx:1
    [HttpGet("legacy/conditionsinfo")]
    public IActionResult Conditionsinfo()
    {
        return Ok(new { LegacyEndpoint = "/ConditionsInfo.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ConditionsInfoPopup.aspx:1
    [HttpGet("legacy/conditionsinfopopup")]
    public IActionResult Conditionsinfopopup()
    {
        return Ok(new { LegacyEndpoint = "/ConditionsInfoPopup.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ConfigurationHome.aspx:1
    [HttpGet("legacy/configurationhome")]
    public IActionResult Configurationhome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ConfigurationHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ContactUs.aspx:1
    [HttpGet("legacy/contactus")]
    public IActionResult Contactus()
    {
        return Ok(new { LegacyEndpoint = "/ContactUs.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\ContentManagementHome.aspx:1
    [HttpGet("legacy/contentmanagementhome")]
    public IActionResult Contentmanagementhome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/ContentManagementHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Countries.aspx:1
    [HttpGet("legacy/countries")]
    public IActionResult Countries()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Countries.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeAdd.aspx:1
    [HttpGet("legacy/creditcardtypeadd")]
    public IActionResult Creditcardtypeadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CreditCardTypeAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeDetails.aspx:1
    [HttpGet("legacy/creditcardtypedetails")]
    public IActionResult Creditcardtypedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CreditCardTypeDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypes.aspx:1
    [HttpGet("legacy/creditcardtypes")]
    public IActionResult Creditcardtypes()
    {
        return Ok(new { LegacyEndpoint = "/Administration/CreditCardTypes.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Currencies.aspx:1
    [HttpGet("legacy/currencies")]
    public IActionResult Currencies()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Currencies.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\CyberSourceIPNHandler.aspx:1
    [HttpGet("legacy/cybersourceipnhandler")]
    public IActionResult Cybersourceipnhandler()
    {
        return Ok(new { LegacyEndpoint = "/CyberSourceIPNHandler.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Default.aspx:1
    [HttpGet("legacy/default")]
    public IActionResult Default()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Default.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Default.aspx:1
    [HttpGet("legacy/default")]
    public IActionResult Default()
    {
        return Ok(new { LegacyEndpoint = "/Default.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\GlobalSettings.aspx:1
    [HttpGet("legacy/globalsettings")]
    public IActionResult Globalsettings()
    {
        return Ok(new { LegacyEndpoint = "/Administration/GlobalSettings.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\GooglePostHandler.aspx:1
    [HttpGet("legacy/googleposthandler")]
    public IActionResult Googleposthandler()
    {
        return Ok(new { LegacyEndpoint = "/GooglePostHandler.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\HelpHome.aspx:1
    [HttpGet("legacy/helphome")]
    public IActionResult Helphome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/HelpHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\IdealNotify.aspx:1
    [HttpGet("legacy/idealnotify")]
    public IActionResult Idealnotify()
    {
        return Ok(new { LegacyEndpoint = "/IdealNotify.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceAdd.aspx:1
    [HttpGet("legacy/localestringresourceadd")]
    public IActionResult Localestringresourceadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LocaleStringResourceAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceDetails.aspx:1
    [HttpGet("legacy/localestringresourcedetails")]
    public IActionResult Localestringresourcedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LocaleStringResourceDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResources.aspx:1
    [HttpGet("legacy/localestringresources")]
    public IActionResult Localestringresources()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LocaleStringResources.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LocationSettingsHome.aspx:1
    [HttpGet("legacy/locationsettingshome")]
    public IActionResult Locationsettingshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LocationSettingsHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\LogDetails.aspx:1
    [HttpGet("legacy/logdetails")]
    public IActionResult Logdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/LogDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Login.aspx:1
    [HttpGet("legacy/login")]
    public IActionResult Login()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Login.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Login.aspx:1
    [HttpGet("legacy/login")]
    public IActionResult Login()
    {
        return Ok(new { LegacyEndpoint = "/Login.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Logout.aspx:1
    [HttpGet("legacy/logout")]
    public IActionResult Logout()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Logout.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Logout.aspx:1
    [HttpGet("legacy/logout")]
    public IActionResult Logout()
    {
        return Ok(new { LegacyEndpoint = "/Logout.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Logs.aspx:1
    [HttpGet("legacy/logs")]
    public IActionResult Logs()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Logs.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Maintenance.aspx:1
    [HttpGet("legacy/maintenance")]
    public IActionResult Maintenance()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Maintenance.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionAdd.aspx:1
    [HttpGet("legacy/measuredimensionadd")]
    public IActionResult Measuredimensionadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MeasureDimensionAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionDetails.aspx:1
    [HttpGet("legacy/measuredimensiondetails")]
    public IActionResult Measuredimensiondetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MeasureDimensionDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightAdd.aspx:1
    [HttpGet("legacy/measureweightadd")]
    public IActionResult Measureweightadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MeasureWeightAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightDetails.aspx:1
    [HttpGet("legacy/measureweightdetails")]
    public IActionResult Measureweightdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/MeasureWeightDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Measures.aspx:1
    [HttpGet("legacy/measures")]
    public IActionResult Measures()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Measures.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PasswordRecovery.aspx:1
    [HttpGet("legacy/passwordrecovery")]
    public IActionResult Passwordrecovery()
    {
        return Ok(new { LegacyEndpoint = "/PasswordRecovery.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\PictureBrowser.aspx:1
    [HttpGet("legacy/picturebrowser")]
    public IActionResult Picturebrowser()
    {
        return Ok(new { LegacyEndpoint = "/Administration/PictureBrowser.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\PrivacyInfo.aspx:1
    [HttpGet("legacy/privacyinfo")]
    public IActionResult Privacyinfo()
    {
        return Ok(new { LegacyEndpoint = "/PrivacyInfo.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\QuickPayCancel.aspx:1
    [HttpGet("legacy/quickpaycancel")]
    public IActionResult Quickpaycancel()
    {
        return Ok(new { LegacyEndpoint = "/QuickPayCancel.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Register.aspx:1
    [HttpGet("legacy/register")]
    public IActionResult Register()
    {
        return Ok(new { LegacyEndpoint = "/Register.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SMSProviders.aspx:1
    [HttpGet("legacy/smsproviders")]
    public IActionResult Smsproviders()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SMSProviders.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SagePayFailure.aspx:1
    [HttpGet("legacy/sagepayfailure")]
    public IActionResult Sagepayfailure()
    {
        return Ok(new { LegacyEndpoint = "/SagePayFailure.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SagePaySuccess.aspx:1
    [HttpGet("legacy/sagepaysuccess")]
    public IActionResult Sagepaysuccess()
    {
        return Ok(new { LegacyEndpoint = "/SagePaySuccess.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SalesHome.aspx:1
    [HttpGet("legacy/saleshome")]
    public IActionResult Saleshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SalesHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SalesReport.aspx:1
    [HttpGet("legacy/salesreport")]
    public IActionResult Salesreport()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SalesReport.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Search.aspx:1
    [HttpGet("legacy/search")]
    public IActionResult Search()
    {
        return Ok(new { LegacyEndpoint = "/Search.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SendPM.aspx:1
    [HttpGet("legacy/sendpm")]
    public IActionResult Sendpm()
    {
        return Ok(new { LegacyEndpoint = "/SendPM.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SermepaError.aspx:1
    [HttpGet("legacy/sermepaerror")]
    public IActionResult Sermepaerror()
    {
        return Ok(new { LegacyEndpoint = "/SermepaError.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SettingAdd.aspx:1
    [HttpGet("legacy/settingadd")]
    public IActionResult Settingadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SettingAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SettingDetails.aspx:1
    [HttpGet("legacy/settingdetails")]
    public IActionResult Settingdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SettingDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Settings.aspx:1
    [HttpGet("legacy/settings")]
    public IActionResult Settings()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Settings.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Sitemap.aspx:1
    [HttpGet("legacy/sitemap")]
    public IActionResult Sitemap()
    {
        return Ok(new { LegacyEndpoint = "/Sitemap.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\SitemapSEO.aspx:1
    [HttpGet("legacy/sitemapseo")]
    public IActionResult Sitemapseo()
    {
        return Ok(new { LegacyEndpoint = "/SitemapSEO.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceAdd.aspx:1
    [HttpGet("legacy/stateprovinceadd")]
    public IActionResult Stateprovinceadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/StateProvinceAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceDetails.aspx:1
    [HttpGet("legacy/stateprovincedetails")]
    public IActionResult Stateprovincedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/StateProvinceDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinces.aspx:1
    [HttpGet("legacy/stateprovinces")]
    public IActionResult Stateprovinces()
    {
        return Ok(new { LegacyEndpoint = "/Administration/StateProvinces.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SystemHome.aspx:1
    [HttpGet("legacy/systemhome")]
    public IActionResult Systemhome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SystemHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\SystemInformation.aspx:1
    [HttpGet("legacy/systeminformation")]
    public IActionResult Systeminformation()
    {
        return Ok(new { LegacyEndpoint = "/Administration/SystemInformation.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TemplatesHome.aspx:1
    [HttpGet("legacy/templateshome")]
    public IActionResult Templateshome()
    {
        return Ok(new { LegacyEndpoint = "/Administration/TemplatesHome.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Topic.aspx:1
    [HttpGet("legacy/topic")]
    public IActionResult Topic()
    {
        return Ok(new { LegacyEndpoint = "/Topic.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TopicAdd.aspx:1
    [HttpGet("legacy/topicadd")]
    public IActionResult Topicadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/TopicAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\TopicDetails.aspx:1
    [HttpGet("legacy/topicdetails")]
    public IActionResult Topicdetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/TopicDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\UserAgreement.aspx:1
    [HttpGet("legacy/useragreement")]
    public IActionResult Useragreement()
    {
        return Ok(new { LegacyEndpoint = "/UserAgreement.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\ViewPM.aspx:1
    [HttpGet("legacy/viewpm")]
    public IActionResult Viewpm()
    {
        return Ok(new { LegacyEndpoint = "/ViewPM.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseAdd.aspx:1
    [HttpGet("legacy/warehouseadd")]
    public IActionResult Warehouseadd()
    {
        return Ok(new { LegacyEndpoint = "/Administration/WarehouseAdd.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseDetails.aspx:1
    [HttpGet("legacy/warehousedetails")]
    public IActionResult Warehousedetails()
    {
        return Ok(new { LegacyEndpoint = "/Administration/WarehouseDetails.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Warehouses.aspx:1
    [HttpGet("legacy/warehouses")]
    public IActionResult Warehouses()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Warehouses.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Administration\Warnings.aspx:1
    [HttpGet("legacy/warnings")]
    public IActionResult Warnings()
    {
        return Ok(new { LegacyEndpoint = "/Administration/Warnings.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\connector.aspx:1
    [HttpGet("legacy/connector")]
    public IActionResult Connector()
    {
        return Ok(new { LegacyEndpoint = "/editors/fckeditor/editor/filemanager/connectors/aspx/connector.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\Install\install.aspx:1
    [HttpGet("legacy/install")]
    public IActionResult Install()
    {
        return Ok(new { LegacyEndpoint = "/Install/install.aspx", Context = "Legacy" });
    }

    // Evidence: nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\upload.aspx:1
    [HttpGet("legacy/upload")]
    public IActionResult Upload()
    {
        return Ok(new { LegacyEndpoint = "/editors/fckeditor/editor/filemanager/connectors/aspx/upload.aspx", Context = "Legacy" });
    }

}