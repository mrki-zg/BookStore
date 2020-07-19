namespace BookStore.Web.Models.Book
{
    public class BookCardViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
