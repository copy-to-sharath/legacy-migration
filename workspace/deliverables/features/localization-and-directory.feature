# Generator: Agent-Gherkin-Gen
# Judge: Agent-Gherkin-Judge
# Status: draft pending judge + human approval
Feature: Localization and Directory workflows
  # cite: nopCommerce-release-1.90\NopCommerceStore\ChronoPayIPNHandler.aspx:1
  # cite: nopCommerce-release-1.90\NopCommerceStore\CyberSourceIPNHandler.aspx:1

  Scenario: Access ChronoPayIPNHandler.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/ChronoPayIPNHandler.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/ChronoPayIPNHandler.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/ChronoPayIPNHandler.aspx"

  Scenario: Access CyberSourceIPNHandler.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/CyberSourceIPNHandler.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/CyberSourceIPNHandler.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/CyberSourceIPNHandler.aspx"

  Scenario: Access GooglePostHandler.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/GooglePostHandler.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/GooglePostHandler.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/GooglePostHandler.aspx"

  Scenario: Access PaypalIPNHandler.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/PaypalIPNHandler.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/PaypalIPNHandler.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/PaypalIPNHandler.aspx"

  Scenario: Access PaypalPDTHandler.aspx
    Given endpoint "nopCommerce-release-1.90/NopCommerceStore/PaypalPDTHandler.aspx" is available
    When a ".aspx" request is issued to "nopCommerce-release-1.90/NopCommerceStore/PaypalPDTHandler.aspx"
    Then the system responds for "nopCommerce-release-1.90/NopCommerceStore/PaypalPDTHandler.aspx"
