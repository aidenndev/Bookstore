using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly AppDbContext _context;

        //Constructor
        public CustomersService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int id, Customer newCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
