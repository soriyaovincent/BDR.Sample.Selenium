@Regression @RegisterAddress @InstallerPortal
Feature: SpecFlowFeature2
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


@SmokeTest
Scenario: User enter valid postal code
	Given I am on the Installer registration page
	Then I should see a '0000 AA' placeholder value for  postal code input field
	Then I should see a '000' placeholder value for house number input field
	When I have entered '7332AZ' postal code and '55' house number
	Then I should see '(38, 171, 29' border bottom color for postal code and house number
	Then I should see 'Marchantstraat 55, 7332AZ Apeldoorn' register address success message

@SmokeTest @AAA
Scenario: User enter invalid postal code
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message


Scenario: User enter valid postal code2
	Given I am on the Installer registration page
	Then I should see a '0000 AA' placeholder value for  postal code input field
	Then I should see a '000' placeholder value for house number input field
	When I have entered '7332AZ' postal code and '55' house number
	Then I should see '(38, 171, 29' border bottom color for postal code and house number
	Then I should see 'Marchantstraat 55, 7332AZ Apeldoorn' register address success message

	
Scenario: User enter invalid postal code3
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message


Scenario: User enter invalid postal code4
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message


Scenario: User enter invalid postal code5
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message

Scenario: User enter invalid postal code6
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message

Scenario: User enter invalid postal code7
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message

Scenario: User enter invalid postal code9
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message

Scenario: User enter invalid postal code10
	Given I am on the Installer registration page
	When I have entered '7332AX' postal code and '55' house number
	Then I should see '(210, 18, 66' border bottom color for postal code and house number
	Then I should see 'Adres is onbekend. Controleer alsjeblieft of het ingevoerde adres correct is' error message
	Then I should see 'Montserrat, serif' font family for error message
