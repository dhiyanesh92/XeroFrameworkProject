Feature: Add a bank
	

@SmokeTests
Scenario: Add ANZ bank
	Given Browse the XeroLogin page
	And Enter user name and Password
	And Click Login button
	And Click on Use Another authentication method link
	And Select security questions
	And Answer Security Questions
	And Select Bank accounts from Accounting to add bank
	When Add Bank Account and select ANZ
	Then ANZ Bank should be added
	
