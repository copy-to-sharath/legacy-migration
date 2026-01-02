# Legacy-to-New API Mapping and Coverage

## Agent workflow

Generator agent: Agent-Map-Gen
Judge agent: Agent-Map-Judge
Status: draft pending judge + human approval

## Legacy endpoint inventory (graph-derived via MCP)

Note: request/response shapes are inferred from endpoint names and common WebForms patterns. Citation strength and inference level are now explicitly marked. MCP node IDs are included where available.

| Legacy endpoint | Type | Proposed REST endpoint | Context | Evidence | Citation Strength | MCP Node | Inference Level |
| --- | --- | --- | --- | --- | --- | --- | --- |
| `/Froogle.ashx` | `.ashx` | `/api/shipping/froogle` | Shipping | `nopCommerce-release-1.90\NopCommerceStore\Froogle.ashx:1` | file-level | (unmapped) | inferred |
| `/GetDownload.ashx` | `.ashx` | `/api/shipping/getdownload` | Shipping | `nopCommerce-release-1.90\NopCommerceStore\GetDownload.ashx:1` | file-level | (unmapped) | inferred |
| `/Administration/GetDownloadAdmin.ashx` | `.ashx` | `/api/shipping/getdownloadadmin` | Shipping | `nopCommerce-release-1.90\NopCommerceStore\Administration\GetDownloadAdmin.ashx:1` | file-level | (unmapped) | inferred |
| `/GetLicense.ashx` | `.ashx` | `/api/shipping/getlicense` | Shipping | `nopCommerce-release-1.90\NopCommerceStore\GetLicense.ashx:1` | file-level | (unmapped) | inferred |
| `/KeepAlive/Ping.ashx` | `.ashx` | `/api/shipping/ping` | Shipping | `nopCommerce-release-1.90\NopCommerceStore\KeepAlive\Ping.ashx:1` | file-level | (unmapped) | inferred |
| `/QBConnector.asmx` | `.asmx` | `/api/shipping/qbconnector` | Shipping | `nopCommerce-release-1.90\NopCommerceStore\QBConnector.asmx:1` | file-level | (unmapped) | inferred |
| `/Administration/ACL.aspx` | `.aspx` | `/api/catalog/acl` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ACL.aspx:1` | file-level | (unmapped) | inferred |
| `/AboutUs.aspx` | `.aspx` | `/api/catalog/aboutus` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\AboutUs.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/AccessDenied.aspx` | `.aspx` | `/api/catalog/accessdenied` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\AccessDenied.aspx:1` | file-level | (unmapped) | inferred |
| `/Account.aspx` | `.aspx` | `/api/catalog/account` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Account.aspx:1` | file-level | (unmapped) | inferred |
| `/AccountActivation.aspx` | `.aspx` | `/api/catalog/accountactivation` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\AccountActivation.aspx:1` | file-level | (unmapped) | inferred |
| `/Boards/ActiveDiscussions.aspx` | `.aspx` | `/api/catalog/activediscussions` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\ActiveDiscussions.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ActivityLog.aspx` | `.aspx` | `/api/catalog/activitylog` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLog.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ActivityLogHome.aspx` | `.aspx` | `/api/catalog/activityloghome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityLogHome.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ActivityTypes.aspx` | `.aspx` | `/api/catalog/activitytypes` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ActivityTypes.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/AddressAdd.aspx` | `.aspx` | `/api/catalog/addressadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\AddressAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/AddressDetails.aspx` | `.aspx` | `/api/catalog/addressdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\AddressDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/AddressEdit.aspx` | `.aspx` | `/api/catalog/addressedit` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\AddressEdit.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/AffiliateAdd.aspx` | `.aspx` | `/api/catalog/affiliateadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/AffiliateDetails.aspx` | `.aspx` | `/api/catalog/affiliatedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\AffiliateDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Affiliates.aspx` | `.aspx` | `/api/catalog/affiliates` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Affiliates.aspx:1` | file-level | (unmapped) | inferred |
| `/Alipay_Notify.aspx` | `.aspx` | `/api/catalog/alipay-notify` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Alipay_Notify.aspx:1` | file-level | (unmapped) | inferred |
| `/Alipay_Return.aspx` | `.aspx` | `/api/catalog/alipay-return` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Alipay_Return.aspx:1` | file-level | (unmapped) | inferred |
| `/AmazonSimplePayReturn.aspx` | `.aspx` | `/api/catalog/amazonsimplepayreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\AmazonSimplePayReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/AssistHostedPaymentReturn.aspx` | `.aspx` | `/api/catalog/assisthostedpaymentreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\AssistHostedPaymentReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/AttributesHome.aspx` | `.aspx` | `/api/catalog/attributeshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\AttributesHome.aspx:1` | file-level | (unmapped) | inferred |
| `/BeanstreamHostedPaymentReturn.aspx` | `.aspx` | `/api/catalog/beanstreamhostedpaymentreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\BeanstreamHostedPaymentReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Blacklist.aspx` | `.aspx` | `/api/catalog/blacklist` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Blacklist.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlacklistIPAdd.aspx` | `.aspx` | `/api/catalog/blacklistipadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlacklistIPDetails.aspx` | `.aspx` | `/api/catalog/blacklistipdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistIPDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlacklistNetworkAdd.aspx` | `.aspx` | `/api/catalog/blacklistnetworkadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlacklistNetworkDetails.aspx` | `.aspx` | `/api/catalog/blacklistnetworkdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlacklistNetworkDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Blog.aspx` | `.aspx` | `/api/catalog/blog` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Blog.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Blog.aspx` | `.aspx` | `/api/catalog/blog` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Blog.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlogCommentDetails.aspx` | `.aspx` | `/api/catalog/blogcommentdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlogCommentDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlogComments.aspx` | `.aspx` | `/api/catalog/blogcomments` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlogComments.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlogHome.aspx` | `.aspx` | `/api/catalog/bloghome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlogHome.aspx:1` | file-level | (unmapped) | inferred |
| `/BlogPost.aspx` | `.aspx` | `/api/catalog/blogpost` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\BlogPost.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlogPostAdd.aspx` | `.aspx` | `/api/catalog/blogpostadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlogPostDetails.aspx` | `.aspx` | `/api/catalog/blogpostdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlogPostDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/BlogRSS.aspx` | `.aspx` | `/api/catalog/blogrss` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\BlogRSS.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BlogSettings.aspx` | `.aspx` | `/api/catalog/blogsettings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BlogSettings.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/BulkEditProducts.aspx` | `.aspx` | `/api/catalog/bulkeditproducts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\BulkEditProducts.aspx:1` | file-level | (unmapped) | inferred |
| `/CCAvenueReturn.aspx` | `.aspx` | `/api/catalog/ccavenuereturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CCAvenueReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CampaignAdd.aspx` | `.aspx` | `/api/catalog/campaignadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CampaignDetails.aspx` | `.aspx` | `/api/catalog/campaigndetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CampaignDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Campaigns.aspx` | `.aspx` | `/api/catalog/campaigns` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Campaigns.aspx:1` | file-level | (unmapped) | inferred |
| `/CaptchaImage.aspx` | `.aspx` | `/api/catalog/captchaimage` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CaptchaImage.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CatalogHome.aspx` | `.aspx` | `/api/catalog/cataloghome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CatalogHome.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Categories.aspx` | `.aspx` | `/api/catalog/categories` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Categories.aspx:1` | file-level | (unmapped) | inferred |
| `/Category.aspx` | `.aspx` | `/api/catalog/category` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Category.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CategoryAdd.aspx` | `.aspx` | `/api/catalog/categoryadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CategoryDetails.aspx` | `.aspx` | `/api/catalog/categorydetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CategoryProductAdd.aspx` | `.aspx` | `/api/catalog/categoryproductadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryProductAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CategoryTemplateAdd.aspx` | `.aspx` | `/api/catalog/categorytemplateadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplateAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CategoryTemplateDetails.aspx` | `.aspx` | `/api/catalog/categorytemplatedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplateDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CategoryTemplates.aspx` | `.aspx` | `/api/catalog/categorytemplates` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CategoryTemplates.aspx:1` | file-level | (unmapped) | inferred |
| `/Checkout.aspx` | `.aspx` | `/api/catalog/checkout` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Checkout.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CheckoutAttributeAdd.aspx` | `.aspx` | `/api/catalog/checkoutattributeadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CheckoutAttributeDetails.aspx` | `.aspx` | `/api/catalog/checkoutattributedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CheckoutAttributes.aspx` | `.aspx` | `/api/catalog/checkoutattributes` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributes.aspx:1` | file-level | (unmapped) | inferred |
| `/CheckoutBillingAddress.aspx` | `.aspx` | `/api/catalog/checkoutbillingaddress` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutBillingAddress.aspx:1` |
| `/CheckoutCompleted.aspx` | `.aspx` | `/api/catalog/checkoutcompleted` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutCompleted.aspx:1` |
| `/CheckoutConfirm.aspx` | `.aspx` | `/api/catalog/checkoutconfirm` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutConfirm.aspx:1` |
| `/CheckoutOnepage.aspx` | `.aspx` | `/api/catalog/checkoutonepage` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutOnepage.aspx:1` |
| `/CheckoutPaymentInfo.aspx` | `.aspx` | `/api/catalog/checkoutpaymentinfo` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentInfo.aspx:1` |
| `/CheckoutPaymentMethod.aspx` | `.aspx` | `/api/catalog/checkoutpaymentmethod` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutPaymentMethod.aspx:1` |
| `/CheckoutShippingAddress.aspx` | `.aspx` | `/api/catalog/checkoutshippingaddress` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingAddress.aspx:1` |
| `/CheckoutShippingMethod.aspx` | `.aspx` | `/api/catalog/checkoutshippingmethod` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingMethod.aspx:1` |
| `/ChronoPayIPNHandler.aspx` | `.aspx` | `/api/catalog/chronopayipnhandler` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1` |
| `/CompareProducts.aspx` | `.aspx` | `/api/catalog/compareproducts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CompareProducts.aspx:1` |
| `/ConditionsInfo.aspx` | `.aspx` | `/api/catalog/conditionsinfo` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ConditionsInfo.aspx:1` |
| `/ConditionsInfoPopup.aspx` | `.aspx` | `/api/catalog/conditionsinfopopup` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ConditionsInfoPopup.aspx:1` |
| `/Administration/ConfigurationHome.aspx` | `.aspx` | `/api/catalog/configurationhome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ConfigurationHome.aspx:1` |
| `/ContactUs.aspx` | `.aspx` | `/api/catalog/contactus` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ContactUs.aspx:1` |
| `/Administration/ContentManagementHome.aspx` | `.aspx` | `/api/catalog/contentmanagementhome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ContentManagementHome.aspx:1` |
| `/Administration/Countries.aspx` | `.aspx` | `/api/catalog/countries` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Countries.aspx:1` |
| `/Administration/CountryAdd.aspx` | `.aspx` | `/api/catalog/countryadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CountryAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CountryDetails.aspx` | `.aspx` | `/api/catalog/countrydetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CountryDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CreditCardTypeAdd.aspx` | `.aspx` | `/api/catalog/creditcardtypeadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CreditCardTypeDetails.aspx` | `.aspx` | `/api/catalog/creditcardtypedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypeDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CreditCardTypes.aspx` | `.aspx` | `/api/catalog/creditcardtypes` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CreditCardTypes.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CrossSellProductAdd.aspx` | `.aspx` | `/api/catalog/crosssellproductadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CrossSellProductAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Currencies.aspx` | `.aspx` | `/api/catalog/currencies` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Currencies.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CurrencyAdd.aspx` | `.aspx` | `/api/catalog/currencyadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CurrencyDetails.aspx` | `.aspx` | `/api/catalog/currencydetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CurrencyDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CurrentShoppingCarts.aspx` | `.aspx` | `/api/catalog/currentshoppingcarts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CurrentShoppingCarts.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomerAdd.aspx` | `.aspx` | `/api/catalog/customeradd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomerDetails.aspx` | `.aspx` | `/api/catalog/customerdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomerReports.aspx` | `.aspx` | `/api/catalog/customerreports` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerReports.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomerRoleAdd.aspx` | `.aspx` | `/api/catalog/customerroleadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomerRoleDetails.aspx` | `.aspx` | `/api/catalog/customerroledetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoleDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomerRoles.aspx` | `.aspx` | `/api/catalog/customerroles` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomerRoles.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Customers.aspx` | `.aspx` | `/api/catalog/customers` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Customers.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/CustomersHome.aspx` | `.aspx` | `/api/catalog/customershome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\CustomersHome.aspx:1` | file-level | (unmapped) | inferred |
| `/CyberSourceIPNHandler.aspx` | `.aspx` | `/api/catalog/cybersourceipnhandler` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\CyberSourceIPNHandler.aspx:1` | file-level | (unmapped) | inferred |
| `/Boards/Default.aspx` | `.aspx` | `/api/catalog/default` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\Default.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Default.aspx` | `.aspx` | `/api/catalog/default` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Default.aspx:1` | file-level | (unmapped) | inferred |
| `/Default.aspx` | `.aspx` | `/api/catalog/default` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Default.aspx:1` | file-level | (unmapped) | inferred |
| `/DibsFlexWinReturn.aspx` | `.aspx` | `/api/catalog/dibsflexwinreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\DibsFlexWinReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/DiscountAdd.aspx` | `.aspx` | `/api/catalog/discountadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/DiscountDetails.aspx` | `.aspx` | `/api/catalog/discountdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\DiscountDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Discounts.aspx` | `.aspx` | `/api/catalog/discounts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Discounts.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/EmailAccountAdd.aspx` | `.aspx` | `/api/catalog/emailaccountadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/EmailAccountDetails.aspx` | `.aspx` | `/api/catalog/emailaccountdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccountDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/EmailAccounts.aspx` | `.aspx` | `/api/catalog/emailaccounts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\EmailAccounts.aspx:1` | file-level | (unmapped) | inferred |
| `/Boards/Forum.aspx` | `.aspx` | `/api/catalog/forum` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\Forum.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ForumAdd.aspx` | `.aspx` | `/api/catalog/forumadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ForumDetails.aspx` | `.aspx` | `/api/catalog/forumdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Boards/ForumGroup.aspx` | `.aspx` | `/api/catalog/forumgroup` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\ForumGroup.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ForumGroupAdd.aspx` | `.aspx` | `/api/catalog/forumgroupadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ForumGroupDetails.aspx` | `.aspx` | `/api/catalog/forumgroupdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Forums.aspx` | `.aspx` | `/api/catalog/forums` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Forums.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ForumsHome.aspx` | `.aspx` | `/api/catalog/forumshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsHome.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/ForumsSettings.aspx` | `.aspx` | `/api/catalog/forumssettings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumsSettings.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/GiftCardDetails.aspx` | `.aspx` | `/api/catalog/giftcarddetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\GiftCardDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/GlobalSettings.aspx` | `.aspx` | `/api/catalog/globalsettings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\GlobalSettings.aspx:1` | file-level | (unmapped) | inferred |
| `/GooglePostHandler.aspx` | `.aspx` | `/api/catalog/googleposthandler` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\GooglePostHandler.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/HelpHome.aspx` | `.aspx` | `/api/catalog/helphome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\HelpHome.aspx:1` | file-level | (unmapped) | inferred |
| `/IdealNotify.aspx` | `.aspx` | `/api/catalog/idealnotify` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\IdealNotify.aspx:1` | file-level | (unmapped) | inferred |
| `/IdealReturn.aspx` | `.aspx` | `/api/catalog/idealreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\IdealReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/LanguageAdd.aspx` | `.aspx` | `/api/catalog/languageadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/LanguageDetails.aspx` | `.aspx` | `/api/catalog/languagedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LanguageDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/Languages.aspx` | `.aspx` | `/api/catalog/languages` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Languages.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/LocaleStringResourceAdd.aspx` | `.aspx` | `/api/catalog/localestringresourceadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceAdd.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/LocaleStringResourceDetails.aspx` | `.aspx` | `/api/catalog/localestringresourcedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResourceDetails.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/LocaleStringResources.aspx` | `.aspx` | `/api/catalog/localestringresources` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LocaleStringResources.aspx:1` | file-level | (unmapped) | inferred |
| `/Administration/LocationSettingsHome.aspx` | `.aspx` | `/api/catalog/locationsettingshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LocationSettingsHome.aspx:1` |
| `/Administration/LogDetails.aspx` | `.aspx` | `/api/catalog/logdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\LogDetails.aspx:1` |
| `/Administration/Login.aspx` | `.aspx` | `/api/catalog/login` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Login.aspx:1` |
| `/Login.aspx` | `.aspx` | `/api/catalog/login` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Login.aspx:1` |
| `/Administration/Logout.aspx` | `.aspx` | `/api/catalog/logout` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Logout.aspx:1` |
| `/Logout.aspx` | `.aspx` | `/api/catalog/logout` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Logout.aspx:1` |
| `/Administration/Logs.aspx` | `.aspx` | `/api/catalog/logs` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Logs.aspx:1` |
| `/Administration/Maintenance.aspx` | `.aspx` | `/api/catalog/maintenance` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Maintenance.aspx:1` |
| `/Manufacturer.aspx` | `.aspx` | `/api/catalog/manufacturer` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Manufacturer.aspx:1` |
| `/Administration/ManufacturerAdd.aspx` | `.aspx` | `/api/catalog/manufactureradd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerAdd.aspx:1` |
| `/Administration/ManufacturerDetails.aspx` | `.aspx` | `/api/catalog/manufacturerdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerDetails.aspx:1` |
| `/Administration/ManufacturerProductAdd.aspx` | `.aspx` | `/api/catalog/manufacturerproductadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerProductAdd.aspx:1` |
| `/Administration/ManufacturerTemplateAdd.aspx` | `.aspx` | `/api/catalog/manufacturertemplateadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplateAdd.aspx:1` |
| `/Administration/ManufacturerTemplateDetails.aspx` | `.aspx` | `/api/catalog/manufacturertemplatedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplateDetails.aspx:1` |
| `/Administration/ManufacturerTemplates.aspx` | `.aspx` | `/api/catalog/manufacturertemplates` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ManufacturerTemplates.aspx:1` |
| `/Administration/Manufacturers.aspx` | `.aspx` | `/api/catalog/manufacturers` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Manufacturers.aspx:1` |
| `/Manufacturers.aspx` | `.aspx` | `/api/catalog/manufacturers` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Manufacturers.aspx:1` |
| `/Administration/MeasureDimensionAdd.aspx` | `.aspx` | `/api/catalog/measuredimensionadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionAdd.aspx:1` |
| `/Administration/MeasureDimensionDetails.aspx` | `.aspx` | `/api/catalog/measuredimensiondetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureDimensionDetails.aspx:1` |
| `/Administration/MeasureWeightAdd.aspx` | `.aspx` | `/api/catalog/measureweightadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightAdd.aspx:1` |
| `/Administration/MeasureWeightDetails.aspx` | `.aspx` | `/api/catalog/measureweightdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MeasureWeightDetails.aspx:1` |
| `/Administration/Measures.aspx` | `.aspx` | `/api/catalog/measures` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Measures.aspx:1` |
| `/Administration/MessageQueue.aspx` | `.aspx` | `/api/catalog/messagequeue` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueue.aspx:1` |
| `/Administration/MessageQueueDetails.aspx` | `.aspx` | `/api/catalog/messagequeuedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MessageQueueDetails.aspx:1` |
| `/Administration/MessageTemplateDetails.aspx` | `.aspx` | `/api/catalog/messagetemplatedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplateDetails.aspx:1` |
| `/Administration/MessageTemplates.aspx` | `.aspx` | `/api/catalog/messagetemplates` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\MessageTemplates.aspx:1` |
| `/MonerisHostedPaymentReturn.aspx` | `.aspx` | `/api/catalog/monerishostedpaymentreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\MonerisHostedPaymentReturn.aspx:1` |
| `/MoneybookersReturn.aspx` | `.aspx` | `/api/catalog/moneybookersreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\MoneybookersReturn.aspx:1` |
| `/Boards/MoveTopic.aspx` | `.aspx` | `/api/catalog/movetopic` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\MoveTopic.aspx:1` |
| `/Administration/News.aspx` | `.aspx` | `/api/catalog/news` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\News.aspx:1` |
| `/News.aspx` | `.aspx` | `/api/catalog/news` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\News.aspx:1` |
| `/Administration/NewsAdd.aspx` | `.aspx` | `/api/catalog/newsadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsAdd.aspx:1` |
| `/NewsArchive.aspx` | `.aspx` | `/api/catalog/newsarchive` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\NewsArchive.aspx:1` |
| `/Administration/NewsCommentDetails.aspx` | `.aspx` | `/api/catalog/newscommentdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsCommentDetails.aspx:1` |
| `/Administration/NewsComments.aspx` | `.aspx` | `/api/catalog/newscomments` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsComments.aspx:1` |
| `/Administration/NewsDetails.aspx` | `.aspx` | `/api/catalog/newsdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsDetails.aspx:1` |
| `/Administration/NewsHome.aspx` | `.aspx` | `/api/catalog/newshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsHome.aspx:1` |
| `/NewsLetterSubscriptionActivation.aspx` | `.aspx` | `/api/catalog/newslettersubscriptionactivation` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\NewsLetterSubscriptionActivation.aspx:1` |
| `/NewsRSS.aspx` | `.aspx` | `/api/catalog/newsrss` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\NewsRSS.aspx:1` |
| `/Administration/NewsSettings.aspx` | `.aspx` | `/api/catalog/newssettings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsSettings.aspx:1` |
| `/Administration/NewsletterSubscribers.aspx` | `.aspx` | `/api/catalog/newslettersubscribers` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\NewsletterSubscribers.aspx:1` |
| `/Administration/OnlineCustomers.aspx` | `.aspx` | `/api/catalog/onlinecustomers` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\OnlineCustomers.aspx:1` |
| `/OrderDetails.aspx` | `.aspx` | `/api/catalog/orderdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\OrderDetails.aspx:1` |
| `/Administration/OrderDetails.aspx` | `.aspx` | `/api/catalog/orderdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\OrderDetails.aspx:1` |
| `/Administration/OrderPartialRefund.aspx` | `.aspx` | `/api/catalog/orderpartialrefund` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\OrderPartialRefund.aspx:1` |
| `/Administration/Orders.aspx` | `.aspx` | `/api/catalog/orders` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Orders.aspx:1` |
| `/PasswordRecovery.aspx` | `.aspx` | `/api/catalog/passwordrecovery` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PasswordRecovery.aspx:1` |
| `/PayPointHostedPaymentReturn.aspx` | `.aspx` | `/api/catalog/paypointhostedpaymentreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PayPointHostedPaymentReturn.aspx:1` |
| `/Administration/PaymentMethodAdd.aspx` | `.aspx` | `/api/catalog/paymentmethodadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodAdd.aspx:1` |
| `/Administration/PaymentMethodDetails.aspx` | `.aspx` | `/api/catalog/paymentmethoddetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethodDetails.aspx:1` |
| `/Administration/PaymentMethods.aspx` | `.aspx` | `/api/catalog/paymentmethods` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentMethods.aspx:1` |
| `/Administration/PaymentSettingsHome.aspx` | `.aspx` | `/api/catalog/paymentsettingshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PaymentSettingsHome.aspx:1` |
| `/PaypalCancel.aspx` | `.aspx` | `/api/catalog/paypalcancel` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PaypalCancel.aspx:1` |
| `/PaypalExpressReturn.aspx` | `.aspx` | `/api/catalog/paypalexpressreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PaypalExpressReturn.aspx:1` |
| `/PaypalIPNHandler.aspx` | `.aspx` | `/api/catalog/paypalipnhandler` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PaypalIPNHandler.aspx:1` |
| `/PaypalPDTHandler.aspx` | `.aspx` | `/api/catalog/paypalpdthandler` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PaypalPDTHandler.aspx:1` |
| `/Administration/PictureBrowser.aspx` | `.aspx` | `/api/catalog/picturebrowser` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PictureBrowser.aspx:1` |
| `/Administration/PollAdd.aspx` | `.aspx` | `/api/catalog/polladd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PollAdd.aspx:1` |
| `/Administration/PollDetails.aspx` | `.aspx` | `/api/catalog/polldetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PollDetails.aspx:1` |
| `/Administration/Polls.aspx` | `.aspx` | `/api/catalog/polls` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Polls.aspx:1` |
| `/Boards/PostEdit.aspx` | `.aspx` | `/api/catalog/postedit` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\PostEdit.aspx:1` |
| `/Boards/PostNew.aspx` | `.aspx` | `/api/catalog/postnew` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\PostNew.aspx:1` |
| `/Administration/Pricelist.aspx` | `.aspx` | `/api/catalog/pricelist` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Pricelist.aspx:1` |
| `/Administration/PricelistAdd.aspx` | `.aspx` | `/api/catalog/pricelistadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PricelistAdd.aspx:1` |
| `/Administration/PricelistDetails.aspx` | `.aspx` | `/api/catalog/pricelistdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PricelistDetails.aspx:1` |
| `/PrintOrderDetails.aspx` | `.aspx` | `/api/catalog/printorderdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PrintOrderDetails.aspx:1` |
| `/PrivacyInfo.aspx` | `.aspx` | `/api/catalog/privacyinfo` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PrivacyInfo.aspx:1` |
| `/PrivateMessages.aspx` | `.aspx` | `/api/catalog/privatemessages` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\PrivateMessages.aspx:1` |
| `/Product.aspx` | `.aspx` | `/api/catalog/product` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Product.aspx:1` |
| `/Administration/ProductAdd.aspx` | `.aspx` | `/api/catalog/productadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAdd.aspx:1` |
| `/Administration/ProductAttributeAdd.aspx` | `.aspx` | `/api/catalog/productattributeadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributeAdd.aspx:1` |
| `/Administration/ProductAttributeDetails.aspx` | `.aspx` | `/api/catalog/productattributedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributeDetails.aspx:1` |
| `/Administration/ProductAttributes.aspx` | `.aspx` | `/api/catalog/productattributes` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributes.aspx:1` |
| `/Administration/ProductDetails.aspx` | `.aspx` | `/api/catalog/productdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductDetails.aspx:1` |
| `/ProductEmailAFriend.aspx` | `.aspx` | `/api/catalog/productemailafriend` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ProductEmailAFriend.aspx:1` |
| `/ProductReviewAdd.aspx` | `.aspx` | `/api/catalog/productreviewadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ProductReviewAdd.aspx:1` |
| `/Administration/ProductReviewDetails.aspx` | `.aspx` | `/api/catalog/productreviewdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductReviewDetails.aspx:1` |
| `/Administration/ProductReviews.aspx` | `.aspx` | `/api/catalog/productreviews` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductReviews.aspx:1` |
| `/ProductTag.aspx` | `.aspx` | `/api/catalog/producttag` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ProductTag.aspx:1` |
| `/Administration/ProductTags.aspx` | `.aspx` | `/api/catalog/producttags` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTags.aspx:1` |
| `/Administration/ProductTemplateAdd.aspx` | `.aspx` | `/api/catalog/producttemplateadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplateAdd.aspx:1` |
| `/Administration/ProductTemplateDetails.aspx` | `.aspx` | `/api/catalog/producttemplatedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplateDetails.aspx:1` |
| `/Administration/ProductTemplates.aspx` | `.aspx` | `/api/catalog/producttemplates` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductTemplates.aspx:1` |
| `/Administration/ProductVariantAdd.aspx` | `.aspx` | `/api/catalog/productvariantadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantAdd.aspx:1` |
| `/Administration/ProductVariantAttributeValues.aspx` | `.aspx` | `/api/catalog/productvariantattributevalues` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantAttributeValues.aspx:1` |
| `/Administration/ProductVariantDetails.aspx` | `.aspx` | `/api/catalog/productvariantdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantDetails.aspx:1` |
| `/Administration/ProductVariantsLowStock.aspx` | `.aspx` | `/api/catalog/productvariantslowstock` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductVariantsLowStock.aspx:1` |
| `/Administration/Products.aspx` | `.aspx` | `/api/catalog/products` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Products.aspx:1` |
| `/Administration/ProductsHome.aspx` | `.aspx` | `/api/catalog/productshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductsHome.aspx:1` |
| `/Profile.aspx` | `.aspx` | `/api/catalog/profile` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Profile.aspx:1` |
| `/Administration/PromotionProviders.aspx` | `.aspx` | `/api/catalog/promotionproviders` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionProviders.aspx:1` |
| `/Administration/PromotionsHome.aspx` | `.aspx` | `/api/catalog/promotionshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PromotionsHome.aspx:1` |
| `/Administration/PurchasedGiftCards.aspx` | `.aspx` | `/api/catalog/purchasedgiftcards` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\PurchasedGiftCards.aspx:1` |
| `/QuickPayCancel.aspx` | `.aspx` | `/api/catalog/quickpaycancel` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\QuickPayCancel.aspx:1` |
| `/QuickPayReturn.aspx` | `.aspx` | `/api/catalog/quickpayreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\QuickPayReturn.aspx:1` |
| `/RecentlyAddedProducts.aspx` | `.aspx` | `/api/catalog/recentlyaddedproducts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\RecentlyAddedProducts.aspx:1` |
| `/RecentlyAddedProductsRSS.aspx` | `.aspx` | `/api/catalog/recentlyaddedproductsrss` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\RecentlyAddedProductsRSS.aspx:1` |
| `/RecentlyViewedProducts.aspx` | `.aspx` | `/api/catalog/recentlyviewedproducts` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\RecentlyViewedProducts.aspx:1` |
| `/Administration/RecurringPaymentDetails.aspx` | `.aspx` | `/api/catalog/recurringpaymentdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPaymentDetails.aspx:1` |
| `/Administration/RecurringPayments.aspx` | `.aspx` | `/api/catalog/recurringpayments` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\RecurringPayments.aspx:1` |
| `/Register.aspx` | `.aspx` | `/api/catalog/register` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Register.aspx:1` |
| `/Administration/RelatedProductAdd.aspx` | `.aspx` | `/api/catalog/relatedproductadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\RelatedProductAdd.aspx:1` |
| `/ReturnItems.aspx` | `.aspx` | `/api/catalog/returnitems` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ReturnItems.aspx:1` |
| `/Administration/ReturnRequestDetails.aspx` | `.aspx` | `/api/catalog/returnrequestdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequestDetails.aspx:1` |
| `/Administration/ReturnRequests.aspx` | `.aspx` | `/api/catalog/returnrequests` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ReturnRequests.aspx:1` |
| `/Administration/SMSProviders.aspx` | `.aspx` | `/api/catalog/smsproviders` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SMSProviders.aspx:1` |
| `/SagePayFailure.aspx` | `.aspx` | `/api/catalog/sagepayfailure` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SagePayFailure.aspx:1` |
| `/SagePaySuccess.aspx` | `.aspx` | `/api/catalog/sagepaysuccess` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SagePaySuccess.aspx:1` |
| `/Administration/SalesHome.aspx` | `.aspx` | `/api/catalog/saleshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SalesHome.aspx:1` |
| `/Administration/SalesReport.aspx` | `.aspx` | `/api/catalog/salesreport` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SalesReport.aspx:1` |
| `/Boards/Search.aspx` | `.aspx` | `/api/catalog/search` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\Search.aspx:1` |
| `/Search.aspx` | `.aspx` | `/api/catalog/search` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Search.aspx:1` |
| `/SendPM.aspx` | `.aspx` | `/api/catalog/sendpm` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SendPM.aspx:1` |
| `/SermepaError.aspx` | `.aspx` | `/api/catalog/sermepaerror` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SermepaError.aspx:1` |
| `/SermepaReturn.aspx` | `.aspx` | `/api/catalog/sermepareturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SermepaReturn.aspx:1` |
| `/Administration/SettingAdd.aspx` | `.aspx` | `/api/catalog/settingadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SettingAdd.aspx:1` |
| `/Administration/SettingDetails.aspx` | `.aspx` | `/api/catalog/settingdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SettingDetails.aspx:1` |
| `/Administration/Settings.aspx` | `.aspx` | `/api/catalog/settings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Settings.aspx:1` |
| `/ShippingInfo.aspx` | `.aspx` | `/api/catalog/shippinginfo` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ShippingInfo.aspx:1` |
| `/Administration/ShippingMethodAdd.aspx` | `.aspx` | `/api/catalog/shippingmethodadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethodAdd.aspx:1` |
| `/Administration/ShippingMethodDetails.aspx` | `.aspx` | `/api/catalog/shippingmethoddetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethodDetails.aspx:1` |
| `/Administration/ShippingMethods.aspx` | `.aspx` | `/api/catalog/shippingmethods` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingMethods.aspx:1` |
| `/Administration/ShippingRateComputationMethodAdd.aspx` | `.aspx` | `/api/catalog/shippingratecomputationmethodadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethodAdd.aspx:1` |
| `/Administration/ShippingRateComputationMethodDetails.aspx` | `.aspx` | `/api/catalog/shippingratecomputationmethoddetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethodDetails.aspx:1` |
| `/Administration/ShippingRateComputationMethods.aspx` | `.aspx` | `/api/catalog/shippingratecomputationmethods` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingRateComputationMethods.aspx:1` |
| `/Administration/ShippingSettings.aspx` | `.aspx` | `/api/catalog/shippingsettings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingSettings.aspx:1` |
| `/Administration/ShippingSettingsHome.aspx` | `.aspx` | `/api/catalog/shippingsettingshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ShippingSettingsHome.aspx:1` |
| `/ShoppingCart.aspx` | `.aspx` | `/api/catalog/shoppingcart` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ShoppingCart.aspx:1` |
| `/Sitemap.aspx` | `.aspx` | `/api/catalog/sitemap` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Sitemap.aspx:1` |
| `/SitemapSEO.aspx` | `.aspx` | `/api/catalog/sitemapseo` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SitemapSEO.aspx:1` |
| `/Administration/SpecificationAttributeAdd.aspx` | `.aspx` | `/api/catalog/specificationattributeadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributeAdd.aspx:1` |
| `/Administration/SpecificationAttributeDetails.aspx` | `.aspx` | `/api/catalog/specificationattributedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributeDetails.aspx:1` |
| `/Administration/SpecificationAttributes.aspx` | `.aspx` | `/api/catalog/specificationattributes` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SpecificationAttributes.aspx:1` |
| `/Administration/StateProvinceAdd.aspx` | `.aspx` | `/api/catalog/stateprovinceadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceAdd.aspx:1` |
| `/Administration/StateProvinceDetails.aspx` | `.aspx` | `/api/catalog/stateprovincedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinceDetails.aspx:1` |
| `/Administration/StateProvinces.aspx` | `.aspx` | `/api/catalog/stateprovinces` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\StateProvinces.aspx:1` |
| `/SveaHostedPaymentReturn.aspx` | `.aspx` | `/api/catalog/sveahostedpaymentreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\SveaHostedPaymentReturn.aspx:1` |
| `/Administration/SystemHome.aspx` | `.aspx` | `/api/catalog/systemhome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SystemHome.aspx:1` |
| `/Administration/SystemInformation.aspx` | `.aspx` | `/api/catalog/systeminformation` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\SystemInformation.aspx:1` |
| `/Administration/TaxCategories.aspx` | `.aspx` | `/api/catalog/taxcategories` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategories.aspx:1` |
| `/Administration/TaxCategoryAdd.aspx` | `.aspx` | `/api/catalog/taxcategoryadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategoryAdd.aspx:1` |
| `/Administration/TaxCategoryDetails.aspx` | `.aspx` | `/api/catalog/taxcategorydetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxCategoryDetails.aspx:1` |
| `/Administration/TaxProviderAdd.aspx` | `.aspx` | `/api/catalog/taxprovideradd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviderAdd.aspx:1` |
| `/Administration/TaxProviderDetails.aspx` | `.aspx` | `/api/catalog/taxproviderdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviderDetails.aspx:1` |
| `/Administration/TaxProviders.aspx` | `.aspx` | `/api/catalog/taxproviders` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxProviders.aspx:1` |
| `/Administration/TaxSettings.aspx` | `.aspx` | `/api/catalog/taxsettings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxSettings.aspx:1` |
| `/Administration/TaxSettingsHome.aspx` | `.aspx` | `/api/catalog/taxsettingshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TaxSettingsHome.aspx:1` |
| `/Administration/TemplatesHome.aspx` | `.aspx` | `/api/catalog/templateshome` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TemplatesHome.aspx:1` |
| `/Administration/ThirdPartyIntegration.aspx` | `.aspx` | `/api/catalog/thirdpartyintegration` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\ThirdPartyIntegration.aspx:1` |
| `/Boards/Topic.aspx` | `.aspx` | `/api/catalog/topic` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\Topic.aspx:1` |
| `/Topic.aspx` | `.aspx` | `/api/catalog/topic` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Topic.aspx:1` |
| `/Administration/TopicAdd.aspx` | `.aspx` | `/api/catalog/topicadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TopicAdd.aspx:1` |
| `/Administration/TopicDetails.aspx` | `.aspx` | `/api/catalog/topicdetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\TopicDetails.aspx:1` |
| `/Boards/TopicEdit.aspx` | `.aspx` | `/api/catalog/topicedit` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\TopicEdit.aspx:1` |
| `/Boards/TopicNew.aspx` | `.aspx` | `/api/catalog/topicnew` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Boards\TopicNew.aspx:1` |
| `/Administration/Topics.aspx` | `.aspx` | `/api/catalog/topics` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Topics.aspx:1` |
| `/TwoCheckoutINSHandler.aspx` | `.aspx` | `/api/catalog/twocheckoutinshandler` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutINSHandler.aspx:1` |
| `/TwoCheckoutReturn.aspx` | `.aspx` | `/api/catalog/twocheckoutreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\TwoCheckoutReturn.aspx:1` |
| `/USAePayEPaymentFormReturn.aspx` | `.aspx` | `/api/catalog/usaepayepaymentformreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\USAePayEPaymentFormReturn.aspx:1` |
| `/UserAgreement.aspx` | `.aspx` | `/api/catalog/useragreement` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\UserAgreement.aspx:1` |
| `/ViewPM.aspx` | `.aspx` | `/api/catalog/viewpm` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\ViewPM.aspx:1` |
| `/Administration/WarehouseAdd.aspx` | `.aspx` | `/api/catalog/warehouseadd` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseAdd.aspx:1` |
| `/Administration/WarehouseDetails.aspx` | `.aspx` | `/api/catalog/warehousedetails` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseDetails.aspx:1` |
| `/Administration/Warehouses.aspx` | `.aspx` | `/api/catalog/warehouses` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Warehouses.aspx:1` |
| `/Administration/Warnings.aspx` | `.aspx` | `/api/catalog/warnings` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Administration\Warnings.aspx:1` |
| `/Wishlist.aspx` | `.aspx` | `/api/catalog/wishlist` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Wishlist.aspx:1` |
| `/WishlistEmailAFriend.aspx` | `.aspx` | `/api/catalog/wishlistemailafriend` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\WishlistEmailAFriend.aspx:1` |
| `/WorldpayReturn.aspx` | `.aspx` | `/api/catalog/worldpayreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\WorldpayReturn.aspx:1` |
| `/editors/fckeditor/editor/filemanager/connectors/aspx/connector.aspx` | `.aspx` | `/api/catalog/connector` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\connector.aspx:1` | file-level | (unmapped) | inferred |
| `/eWayMerchantReturn.aspx` | `.aspx` | `/api/catalog/ewaymerchantreturn` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\eWayMerchantReturn.aspx:1` | file-level | (unmapped) | inferred |
| `/Install/install.aspx` | `.aspx` | `/api/catalog/install` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\Install\install.aspx:1` | file-level | (unmapped) | inferred |
| `/editors/fckeditor/editor/filemanager/connectors/aspx/upload.aspx` | `.aspx` | `/api/catalog/upload` | Catalog | `nopCommerce-release-1.90\NopCommerceStore\editors\fckeditor\editor\filemanager\connectors\aspx\upload.aspx:1` | file-level | (unmapped) | inferred |


## Coverage summary

- Legacy endpoints listed: 299
- Mapped endpoints in this document: 299
- Remaining endpoints: 0 (legacy inventory coverage complete)
- MCP graph nodes: 18,688
- MCP nodes not mapped to REST endpoints: 18,389

### Rationale for Unmapped MCP Nodes

The following MCP node types are not mapped to REST endpoints because they represent internal code artifacts, infrastructure, or domain models not exposed as API surface:

| MCP Node Type | Count | Rationale |
| --- | --- | --- |
| Method | 9,353 | Internal logic, helpers, business rules, not API-facing |
| File | 3,099 | Source files, not endpoints |
| Class | 2,645 | Domain models, services, infrastructure, not directly exposed |
| RoslynFile | 2,233 | Code analysis artifacts, not API-facing |
| LinqQuery | 777 | Internal queries, not endpoints |
| PlainEntry | 295 | Miscellaneous entries, not API-facing |
| Enum | 216 | Data types, not endpoints |
| Interface | 63 | Abstractions, not endpoints |
| Page | 5 | Non-API pages |
| OrmUsage | 2 | ORM usage, not endpoints |

These nodes are excluded from the mapping for traceability. If future API requirements change, relevant nodes can be reviewed and mapped as needed.

## Vector sample citations (Qdrant, via MCP)

- `nopCommerce-release-1.90\NopCommerceStore\Administration\ForumGroupAdd.aspx.cs:1`
- `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateCustomers.ascx:1`
- `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\LocationHome.ascx.cs:1`
- `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\TopicAdd.ascx:1`
- `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\Warehouses.ascx.cs:1`
- `nopCommerce-release-1.90\NopCommerceStore\Administration\ProductAttributes.aspx.designer.cs:1`
- `nopCommerce-release-1.90\NopCommerceStore\Administration\WarehouseDetails.aspx.designer.cs:1`
- `nopCommerce-release-1.90\NopCommerceStore\BeanstreamHostedPaymentReturn.aspx.designer.cs:1`
- `nopCommerce-release-1.90\NopCommerceStore\Modules\ProductsAlsoPurchased.ascx:1`
- `nopCommerce-release-1.90\Shipping\Nop.Shipping.ShippingByWeightAndCountry\Nop.Shipping.ShippingByWeightAndCountry.csproj:1`

## Judge review notes (pending)

- Validate endpoint mapping rules against bounded contexts.
- Confirm any Legacy endpoints are routed to appropriate contexts.
- Approve coverage summary after human signoff.