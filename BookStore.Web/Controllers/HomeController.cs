using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Web.Models;
using BookStore.Web.Models.Book;
using BookStore.Web.Repository;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAll();

            var booksData = new List<BookCardViewModel>(books.Count);
            foreach (var book in books)
            {
                booksData.Add(new BookCardViewModel
                {
                    AuthorFirstName = book.Author.FirstName,
                    AuthorLastName = book.Author.LastName,
                    Summary = book.Summary,
                    Price = book.Price,
                    Title = book.Title,
                    BookId = book.Id
                });
            }

            ViewData["Books"] = booksData;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
