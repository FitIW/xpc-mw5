namespace SpecFlowExamples.StepDefinitions.Background
{
    [Binding]
    [Scope(Feature = "Background", Scenario = "Add books to store")]
    public sealed class AddBooksSteps : BaseSteps
    {
        [When("I add (.*) more book to store")]
        public void AddTwoBooksToStore(int booksCount)
        {
            store.AddBooks(booksCount);
        }

        [Then("there should be (.*) books in store")]
        public void CheckNumberOfBooks(int booksCount)
        {
            Assert.True(store.Books.Count == booksCount);
        }

        [Then("there should be (.*) magazine")]
        public void CheckNumberOfMagazines(int magazinesCount)
        {
            Assert.True(store.Magazines.Count == magazinesCount);
        }
    }
}
