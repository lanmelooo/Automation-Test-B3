Feature: Zip Code Search


Search by non-existent zip code, existing zip code and tracking code

@tag1
Scenario: Zip Code Search
	Given access website correios
	When search for non-existent zip code
	And search by existing zip code
	And look for tracking code
	Then close browser
