Feature: Background

	This feature shows how to:
	- Create Background for multiple scenarios
	- Reuse step definitions by using base class
	- Use scoped step definitions

	Background:

		These steps will be executed before each scenario

		Given I have 1 book in store
		And I have 1 magazine in store

	# Rule can not be above the Background!!
	Rule: Manipulation with books does not affect magazines

		Scenario: Add books to store

			Testing the addition of a book to the store
			Related C# class: AddBookSteps.cs

			When I add 2 more book to store
			Then there should be 3 books in store
			And there should be 1 magazine

		Scenario: Remove books from store

			Testing the removal of a book from the store
			Related C# class: RemoveBookSteps.cs

			When I remove one book from store
			Then there should be 0 books in store
			And there should be 1 magazine
