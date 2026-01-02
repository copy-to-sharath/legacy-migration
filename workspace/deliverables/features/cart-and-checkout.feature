# Generator: Agent-Gherkin-Gen
# Judge: Agent-Gherkin-Judge
# Status: draft pending judge + human approval
Feature: Cart and Checkout workflows
  # cite: nopCommerce-release-1.90\NopCommerceStore\Checkout.aspx:1
  # cite: nopCommerce-release-1.90\NopCommerceStore\Administration\CheckoutAttributeAdd.aspx:1

  Scenario: Access Checkout.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Checkout.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Checkout.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Checkout.aspx"

  Scenario: Access CheckoutAttributeAdd.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributeAdd.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributeAdd.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributeAdd.aspx"

  Scenario: Access CheckoutAttributeDetails.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributeDetails.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributeDetails.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributeDetails.aspx"

  Scenario: Access CheckoutAttributes.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributes.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributes.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Administration/CheckoutAttributes.aspx"

  Scenario: Access CheckoutBillingAddress.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/CheckoutBillingAddress.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/CheckoutBillingAddress.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/CheckoutBillingAddress.aspx"
