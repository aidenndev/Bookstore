using Bookstore.Data;
using Bookstore.Data.Services;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        //Constructor
        public BooksController(IBooksService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _service.GetAll();
            return View(books);
        }

        //Create a new Book
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,PhotoURL,Description")] Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _service.Add(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
