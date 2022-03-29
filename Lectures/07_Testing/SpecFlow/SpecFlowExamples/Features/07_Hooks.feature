# [BeforeFeature]

Feature: Hooks

	This feature shows the execution order of hooks

	# [BeforeScenario]

	Scenario: Change state of the system
	
		Testing the addition of a book to the store
		Related C# class: HooksSteps.cs

		# [BeforeStep]

		Given I bring the system to state A

		# [AfterStep]
		# [BeforeStep]

		When I do some changes to the system

		# [AfterStep]
		# [BeforeStep]

		Then System should be in state B

		# [AfterStep]

	# [AfterScenario]

# [AfterFeature]
