using SpecFlowExamples.Models;

namespace SpecFlowExamples
{
    public sealed class Store
    {
        public List<Book> Books { get; set; } = new();
        public List<Magazine> Magazines { get; set; } = new();

        public void AddBook(Book book) => Books.Add(book);

        public void AddBooks(IEnumerable<Book> books) => Books.AddRange(books);

        public void AddBooks(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Books.Add(new Book());
            }
        }

        public void AddMagazines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Magazines.Add(new Magazine());
            }
        }

        public void RemoveBook()
        {
            Books.RemoveAt(0);
        }
    }
}
