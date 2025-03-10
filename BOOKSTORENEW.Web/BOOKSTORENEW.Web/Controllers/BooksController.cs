using Microsoft.AspNetCore.Mvc;
using BOOKSTORENEW.Web.Models;
using BOOKSTORENEW.Web.Data; 
using BOOKSTORENEW.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORENEW.Web.Controllers
{
    public class BooksController : Controller
    {
        private  readonly ApplicaionDbContext dbContext;
               public BooksController(ApplicaionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel viewModel)
        {
            var book = new Book
            {
              BookId=viewModel.BookId,
                BookTitle = viewModel.BookTitle,
                AuthorName = viewModel.AuthorName,
                ISBN = viewModel.ISBN,
                PublishedDate = viewModel.PublishedDate,
                Price = viewModel.Price,


            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var book = await dbContext.Books.ToListAsync();
            return View(book);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid BookId)

        {
            var book = await dbContext.Books.FindAsync(BookId);
            return View(book);

        }
        [HttpPost]
        public  async Task<IActionResult> Edit(Book viewModel)
        {
            var student = await dbContext.Books.FindAsync(viewModel.BookId);

            if (book is not null)
            {
                book.BookId = viewModel.BookId;
                book.BookTitle = viewModel.BookTitle;
                book.AuthorName = viewModel.AuthorName;
                book.ISBN = viewModel.ISBN;
                book.PublishedDate = viewModel.PublishedDate;
                book.Price = viewModel.Price;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Books");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Book viewModel)
        {
            var book = await dbContext.Books.
                AsNoTracking()
               .FirstOrDefaultAsync(x=> x.BookId == viewModel.BookId);
            if (book is not null)
            {
                dbContext.Books.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "books");
                
        }
    }
            
    }
