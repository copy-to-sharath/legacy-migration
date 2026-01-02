# Business Requirements Document (BRD)

## Agent workflow

Generator agent: Agent-BRD-Gen
Judge agent: Agent-BRD-Judge
Status: draft pending judge + human approval

## Scope summary

This BRD describes a .NET 8 rewrite of the legacy solution. Requirements are derived from graph/vector sources via MCP only.
Detected bounded contexts: 11.

## Stakeholders (evidence-driven)

Stakeholders will be confirmed by human review. Evidence is listed per context below.

## Business goals (evidence-driven)

- Preserve and expose workflows for 11 bounded contexts.
- Provide REST-based APIs and clean architecture in the .NET 8 rewrite.

## In-scope legacy modules (MCP-derived citations)

- Catalog:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CatalogHome.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CatalogHome.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CatalogHome.ascx:1`
- Customer:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.designer.cs:1`
- Cart and Checkout:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CurrentShoppingCarts.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CurrentShoppingCarts.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Controls\CheckoutStepChangedEventHandler.cs:1`
- Orders:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx:1`
- Payments:
  - `nopCommerce-release-1.90\Payment\Nop.Payment.ChronoPay\HostedPaymentSettings.cs:1`
  - `nopCommerce-release-1.90\Payment\Nop.Payment.Moneris\HostedPaymentSettings.cs:1`
  - `nopCommerce-release-1.90\Payment\Nop.Payment.Moneris\HostedPaymentSettings.cs:1`
- Shipping:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.designer.cs:1`
- Promotions:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\PromotionsHome.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\PromotionsHome.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\PromotionsHome.ascx:1`
- Content:
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ContentManagementHome.ascx:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ContentManagementHome.ascx.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ContentManagementHome.ascx:1`
- Localization and Directory:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Localization\ILocalizationManager.cs:1`
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Localization\LocalizationManager.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Controls\CheckoutStepChangedEventHandler.cs:1`
- Security and ACL:
  - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Security\SecurityHelper.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\Controls\CheckoutStepChangedEventHandler.cs:1`
  - `nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1`

## Functional requirements (FR)

FR-1 Catalog workflows
- The system shall support catalog workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CatalogHome.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CatalogHome.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CatalogHome.ascx.designer.cs:1`

FR-2 Customer workflows
- The system shall support customer workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.designer.cs:1`

FR-3 Cart and Checkout workflows
- The system shall support cart and checkout workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CurrentShoppingCarts.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CurrentShoppingCarts.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\CurrentShoppingCarts.ascx.designer.cs:1`

FR-4 Orders workflows
- The system shall support orders workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\AffiliateOrders.ascx.designer.cs:1`

FR-5 Payments workflows
- The system shall support payments workflows.
  - Evidence:
    - `nopCommerce-release-1.90\Payment\Nop.Payment.ChronoPay\HostedPaymentSettings.cs:1`
    - `nopCommerce-release-1.90\Payment\Nop.Payment.Moneris\HostedPaymentSettings.cs:1`
    - `nopCommerce-release-1.90\Payment\Nop.Payment.PayPoint\HostedPaymentSettings.cs:1`

FR-6 Shipping workflows
- The system shall support shipping workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ACL.ascx.designer.cs:1`

FR-7 Promotions workflows
- The system shall support promotions workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\PromotionsHome.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\PromotionsHome.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\PromotionsHome.ascx.designer.cs:1`

FR-8 Content workflows
- The system shall support content workflows.
  - Evidence:
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ContentManagementHome.ascx:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ContentManagementHome.ascx.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Administration\Modules\ContentManagementHome.ascx.designer.cs:1`

FR-9 Localization and Directory workflows
- The system shall support localization and directory workflows.
  - Evidence:
    - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Localization\ILocalizationManager.cs:1`
    - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Localization\LocalizationManager.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Controls\CheckoutStepChangedEventHandler.cs:1`

FR-10 Security and ACL workflows
- The system shall support security and acl workflows.
  - Evidence:
    - `nopCommerce-release-1.90\Libraries\Nop.BusinessLogic\Security\SecurityHelper.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\Controls\CheckoutStepChangedEventHandler.cs:1`
    - `nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1`


## Non-functional requirements (LLM-inferred)

- Scalability: support high-volume datasets and requests.
- Observability: structured logs for traceability.
- Compatibility: .NET 8, clean architecture, DDD boundaries.

LLM inference note: non-functional requirements are derived from migration goals and must be confirmed by humans.

## Judge review notes (pending)

- Verify FR items against MCP-derived citations.
- Confirm LLM-inferred statements are labeled.