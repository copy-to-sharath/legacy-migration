# Generator: Agent-Gherkin-Gen
# Judge: Agent-Gherkin-Judge
# Status: draft pending judge + human approval
Feature: Shipping workflows
  # cite: nopCommerce-release-1.90\NopCommerceStore\Administration\ACL.aspx:1
  # cite: nopCommerce-release-1.90\NopCommerceStore\AboutUs.aspx:1

  Scenario: Access ACL.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Administration/ACL.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Administration/ACL.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Administration/ACL.aspx"

  Scenario: Access AboutUs.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/AboutUs.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/AboutUs.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/AboutUs.aspx"

  Scenario: Access AccessDenied.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Administration/AccessDenied.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Administration/AccessDenied.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Administration/AccessDenied.aspx"

  Scenario: Access Account.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/Account.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/Account.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/Account.aspx"

  Scenario: Access AccountActivation.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/AccountActivation.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/AccountActivation.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/AccountActivation.aspx"
