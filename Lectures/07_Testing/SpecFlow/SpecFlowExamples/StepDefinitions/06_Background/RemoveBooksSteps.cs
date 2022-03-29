namespace SpecFlowExamples.StepDefinitions.Background
{
    [Binding]
    [Scope(Feature = "Background", Scenario = "Remove books from store")]
    public sealed class RemoveBooksSteps : BaseSteps
    {
        [When("I remove one book from store")]
        public void RemoveOneBookFromStore()
        {
            store.RemoveBook();
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
