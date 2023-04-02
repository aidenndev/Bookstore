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
            var books = await _service.GetAllAsync();
            return View(books);
        }

        //Create a new Book
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,BookId,PhotoURL,Description")] Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            await _service.AddAsync(book);
            return RedirectToAction(nameof(Index));
        }

        //Get the book details by its Id
        public async Task<IActionResult> Details(int id)
        {
            var book = await _service.GetByIdAsync(id);

            if (book == null) return View("NotFound");
            return View(book);
        }

        //Edit the book details
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return View("NotFound");
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,BookId,PhotoURL,Description")] Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            await _service.UpdateAsync(id, book);
            return RedirectToAction(nameof(Index));
        }

        //Delete a book
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return View("NotFound");
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
