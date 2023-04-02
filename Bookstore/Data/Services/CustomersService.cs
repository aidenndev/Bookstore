using Bookstore.Data.Base;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Services
{
    public class CustomersService : EntityBaseRepository<Customer>, ICustomersService
    {
        //Constructor
        public CustomersService(AppDbContext context) : base(context) { }
    }
}
