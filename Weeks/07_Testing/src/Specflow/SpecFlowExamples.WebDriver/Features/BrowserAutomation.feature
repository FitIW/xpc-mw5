Feature: BrowserAutomation

Scenario: Open VUT website
	Given I open google chrome
	When I navigate to VUT website
	Then I should see play button
