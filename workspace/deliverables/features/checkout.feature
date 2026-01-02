# Generator: Agent-Gherkin-Gen
# Judge: Agent-Gherkin-Judge
# Status: draft pending judge + human approval
Feature: Checkout and shipping

  Scenario: Primary flow
    Given a valid request exists
    When the request is processed
    Then the system returns the expected result

  Scenario: Alternate flow
    Given a related request exists
    When the request is processed
    Then the system returns the expected result