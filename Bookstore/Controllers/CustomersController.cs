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
            var customers = await _service.GetAllAsync();
            return View(customers);
        }

        /*
        //Get the customer details by its Id
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _service.GetByIdAsync(id);

            if (customer == null) return View("NotFound");
            return View(customer);
        }
        */

        
        //Create a new Customer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Password")]Customer customer)
        {
            if(!ModelState.IsValid) return View(customer);
            await _service.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        //Edit a Customer
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if(customer == null) return View("NotFound");
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);

            if(id == customer.Id)
            {
                await _service.UpdateAsync(id, customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        //Delete a Customer
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return View("NotFound");
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
