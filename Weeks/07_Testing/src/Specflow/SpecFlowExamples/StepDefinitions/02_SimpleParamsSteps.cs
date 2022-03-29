namespace SpecFlowExamples.StepDefinitions
{
    [Binding]
    [Scope(Feature = "SimpleParams", Scenario = "Add books to store")]
    public class SimpleParamsSteps
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

        [When("I add (.*) more books to store")]
        public void AddTwoBooksToStore(int booksCount)
        {
            store.AddBooks(booksCount);
        }

        [Then("there should be (.*) books in store")]
        public void CheckNumberOfBooks(int booksCount)
        {
            Assert.True(store.Books.Count == booksCount);
        }

        [Then("there should be (.*) magazines")]
        public void CheckNumberOfMagazines(int magazinesCount)
        {
            Assert.True(store.Magazines.Count == magazinesCount);
        }
    }
}
