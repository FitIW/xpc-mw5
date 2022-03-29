namespace SpecFlowExamples.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Intro", Scenario = "Add books to store")]
    public class IntroSteps
    {
        private readonly Store store = new Store();

        [Given("I have one book in store")]
        public void PrepareBooksInStore()
        {
            store.AddBooks(1);
            Assert.True(store.Books.Count == 1);
        }

        [Given("I have one magazine in store")]
        public void PrepareMagazinesInStore()
        {
            store.AddMagazines(1);
            Assert.True(store.Magazines.Count == 1);
        }

        [When("I add two more books to store")]
        public void AddTwoBooksToStore()
        {
            store.AddBooks(2);
        }

        [Then("there should be three books in store")]
        public void CheckNumberOfBooks()
        {
            Assert.True(store.Books.Count == 3);
        }

        [Then("there should be one magazine")]
        public void CheckNumberOfMagazines()
        {
            Assert.True(store.Magazines.Count == 1);
        }
    }
}
