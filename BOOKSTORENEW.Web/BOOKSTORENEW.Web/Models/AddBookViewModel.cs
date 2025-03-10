using Microsoft.AspNetCore.Mvc;
namespace BOOKSTORENEW.Web.Models
{
    public class AddBookViewModel
    {
        public Guid BookId { get; set; }

        public string BookTitle { get; set; }

        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public string PublishedDate { get; set; }
        public decimal Price { get; set; }

    }
}
