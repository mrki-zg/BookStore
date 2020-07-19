using System.Threading.Tasks;
using BookStore.Web.Models.Book;
using BookStore.Web.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _bookRepository.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookDetailViewModel
            {
                Title = book.Title,
                Summary = book.Summary,
                Price = book.Price,
                AuthorName = $"{book.Author.LastName}, {book.Author.FirstName}"
            };

            return View(viewModel);
        }
    }
}
