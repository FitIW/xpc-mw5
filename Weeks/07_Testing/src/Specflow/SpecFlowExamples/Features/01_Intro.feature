Feature: Intro

	This feature shows how to:
	- Bind steps on step definitions
	- Share data between bindings via fake store in step definitions class
	- Use scoped step definitions

	Rule: Adding a book does not affect magazines

		Scenario: Add books to store
	
			Testing the addition of a book to the store
			Related C# class: IntroSteps.cs

			Given I have one book in store
			And I have one magazine in store
			When I add two more books to store
			Then there should be three books in store
			And there should be one magazine
