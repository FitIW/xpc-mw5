namespace SpecFlowExamples.StepDefinitions.Background
{
    public abstract class BaseSteps
    {
        protected readonly Store store = new Store();

        [Given("I have (.*) book in store")]
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
    }
}
