namespace BOOKSTORENEW.Web.Models.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public required string  BookTitle { get; set; }

        public required string AuthorName { get; set; }
        public required string ISBN { get; set; }
        public required string PublishedDate { get; set; }
        public required decimal Price { get; set; }


    }
}
