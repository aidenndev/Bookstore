using Bookstore.Data;
using Bookstore.Data.Services;
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
    }
}
