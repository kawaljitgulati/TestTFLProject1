Feature: TFLJourneyLoginPage
	Login to Journey Planner


Scenario: Plan a journey
Given Navigate to TFL Journey Planner
	And I input journey From and to details
		| From   | To     |
		| Epping | Leyton |
 When I Click on the Plan Journey Page
Then user should be presented with the Journey Results page with the correct summary
		| From   | To     |
		| Epping | Leyton |


Scenario: Edit a journey
Given Navigate to TFL Journey Planner
	And I input journey From and to details
		| From     | To            |
		| Victoria | London Bridge |
When I Click on the Plan Journey Page
When I edit a journey and input the following station 
		| From          | To       |
		| London Bridge | Victoria |
Then user should be presented with the Journey Results page with the correct summary
		| From          | To       |
		| London Bridge | Victoria |

Scenario: Invalid field entry
Given Navigate to TFL Journey Planner
And I input journey From and to details
		| From | To  |
		| XYZ  | XYZ |
When I Click on the Plan Journey Page
Then user should be presented with the Journey Results page with an error message

Scenario: No destination entered
Given Navigate to TFL Journey Planner
And I input journey From and to details
		| From | To   |
		|      | Bank |
When I Click on the Plan Journey Page
Then user sees an error message telling them that the To field is required


Scenario: Recent journey
Given Navigate to TFL Journey Planner
	And I input journey From and to details
		| From     | To            |
		| Victoria | London Bridge |
 When I Click on the Plan Journey Page
Then user should be presented with the Journey Results page with the correct summary
		| From          | To       |
		| London Bridge | Victoria |
When user click on the link to go back to Plan a journey page
Then user will click on Recents link button
Then user should see recent journeys