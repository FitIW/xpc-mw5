Feature: ScenarioOutline

	This feature shows how to:
	- Pass structured data to step definitions (pass object as parameter)
	- Run scenario multiple times with different data
	- Share data between bindings via fake store in step definitions class

	Scenario Outline: Add multiple books with details to store
	
		Testing the addition of a books to the store
		Related C# class: TableParamsSteps.cs

		Given I have 0 books in store
		And I have 1 magazine in store
		When I add a new book to store with following details:
			| Property | Value    |
			| Name     | <name>   |
			| Author   | <author> |
			| Price    | <price>  |
		Then there should be 1 book with name <name>
		And there should be 1 magazine

		Examples:
			| name                 | author          | price |
			| C# in depth          | Skeet Jon       | 30.55 |
			| C# 10 in nutshell    | Josepf Albahari | 70.99 |
			| Pragmatic programmer | Andrew Hunt     | 50.99 |
