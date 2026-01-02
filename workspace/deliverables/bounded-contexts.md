# Bounded Contexts (Graph-derived)

## Agent workflow

Generator agent: Agent-BC-Gen
Judge agent: Agent-BC-Judge
Status: draft pending judge + human approval

## Contexts

### Catalog

- Purpose: manage categories, manufacturers, products, attributes.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Categories\CategoryService.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Manufacturers\IManufacturerService.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Category.aspx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\BulkEditProducts.aspx:1`

### Customer

- Purpose: manage customer profiles, activation, and customer data.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Customer\Customer.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Customer\CustomerService.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Modules\CustomerAccountActivation.ascx:1`

### Cart and Checkout

- Purpose: manage shopping carts and checkout flow.
- Evidence:
  - `nopCommerce-release-1.90\NopCommerceStore\Checkout.aspx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Modules\CheckoutShippingAddress.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CurrentShoppingCarts.ascx:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Orders\DeleteExpiredShoppingCartsTask.cs:1`

### Orders

- Purpose: create and manage orders.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Orders\OrderService.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CustomerOrders.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx:1`

### Payments

- Purpose: process payments through multiple providers.
- Evidence:
  - `nopCommerce-release-1.90\Payment\Nop.Payment.Alipay\AlipayPaymentProcessor.cs:1`
  - `nopCommerce-release-1.90\Payment\Nop.Payment.AuthorizeNet\AuthorizeNetPaymentProcessor.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\AssistHostedPaymentReturn.aspx:1`

### Shipping

- Purpose: calculate and manage shipping via providers.
- Evidence:
  - `nopCommerce-release-1.90\Shipping\Nop.Shipping.FedEx\FedExServices.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\CheckoutShippingAddress.aspx:1`

### Promotions

- Purpose: discounts, affiliates, campaigns.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Promo\Discounts\DiscountService.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Promo\Affiliates\AffiliateService.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\DiscountAdd.ascx:1`

### Content

- Purpose: blog, forums, and news content.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Content\Blog\BlogService.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Content\Forums\ForumService.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Content\News\INewsService.cs:1`

### Localization and Directory

- Purpose: localization, currency, and country directories.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Localization\LocalizationManager.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Directory\CurrencyService.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Directory\CountryService.cs:1`

### Security and ACL

- Purpose: access control and security administration.
- Evidence:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Security\ACLService.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\ACL.aspx:1`

### Integrations

- Purpose: external integration endpoints and feeds.
- Evidence:
  - `nopCommerce-release-1.90\NopCommerceStore\QBConnector.asmx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Froogle.ashx:1`

## Judge review notes (pending)

- Validate each context boundary against dependency graph and service usage.
- Confirm no missing domains from legacy modules list.
- Approve for inclusion after human signoff.
