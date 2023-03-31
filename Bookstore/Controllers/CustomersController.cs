using Bookstore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        //Constructor
        public CustomersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();
            return View();
        }
    }
}
