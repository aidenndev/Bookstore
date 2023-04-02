using Bookstore.Data;
using Bookstore.Data.Services;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;

        //Constructor
        public CustomersController(ICustomersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _service.GetAll();
            return View(customers);
        }

        //Create a new Customer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Password")]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }
            _service.Add(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
