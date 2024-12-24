using BookShoppingCartMVCUI.Models;
using BookShoppingCartMVCUI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShoppingCartMVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository, ApplicationDbContext context)
        {
            _logger = logger;
            _homeRepository = homeRepository;
            _context = context;
        }

        public async Task<IActionResult> Index(string sterm = "", int genreId = 0)
        {
            IEnumerable<Book> books = await _homeRepository.GetBooks(sterm,genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            var bookModel = new BookDisplayModel()
            {
                Books = books,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };
            return View(bookModel);
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

        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(string name, double price, string image, string authorName, int genreId)
        {
            if (ModelState.IsValid)
            {
                var book = new BookShoppingCartMVCUI.Models.Book()
                {
                    BookName = name,
                    Price = price,
                    Image = image,
                    AuthorName = authorName,
                    GenreId = genreId
                };
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}