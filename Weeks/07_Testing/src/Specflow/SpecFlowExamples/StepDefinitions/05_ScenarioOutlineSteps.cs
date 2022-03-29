using SpecFlowExamples.Models;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowExamples.StepDefinitions
{
    [Binding]
    [Scope(Feature = "ScenarioOutline")]
    public class ScenarioOutlineSteps
    {
        private readonly Store store = new Store();

        [Given("I have (.*) books in store")]
        public void PrepareBooksInStore(int booksCount)
        {
            store.AddBooks(booksCount);
            Assert.True(store.Books.Count == booksCount);
        }

        [Given("I have (.*) magazine in store")]
        public void PrepareMagazinesInStore(int magazinesCount)
        {
            store.AddMagazines(magazinesCount);
            Assert.True(store.Magazines.Count == magazinesCount);
        }

        [When("I add a new book to store with following details:")]
        public void AddTwoBooksToStore(Table bookTable)
        {
            var bookObject = bookTable.CreateInstance<Book>();
            store.AddBook(bookObject);
        }

        [Then("there should be 1 book with name (.*)")]
        public void CheckForSpecifiedBook(string bookName)
        {
            var books = store.Books.FindAll(book => book.Name == bookName);
            Assert.True(books.Count == 1);
        }

        [Then("there should be (.*) magazine")]
        public void CheckNumberOfMagazines(int magazinesCount)
        {
            Assert.True(store.Magazines.Count == magazinesCount);
        }
    }
}
