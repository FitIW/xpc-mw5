Feature: TableParams

	This feature shows how to:
	- Pass structured data to step definitions (pass multiple object as parameter using Table)
	- Share data between bindings via fake store in step definitions class

	Scenario: Add multiple books with details to store
	
		Testing the addition of a books to the store
		Related C# class: TableParamsSteps.cs

		Given I have 2 books in store
		And I have 1 magazine in store
		When I add a new books to store with following details:
			| Name                 | Author          | Price |
			| C# in depth          | Skeet Jon       | 30.55 |
			| C# 10 in nutshell    | Josepf Albahari | 70.99 |
			| Pragmatic programmer | Andrew Hunt     | 50.99 |

		Then there should be 5 books in store
		And there should be 1 magazine
