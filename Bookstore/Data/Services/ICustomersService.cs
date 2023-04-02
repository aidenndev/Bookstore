using Bookstore.Data.Base;
using Bookstore.Models;

namespace Bookstore.Data.Services
{
    public interface ICustomersService : IEntityBaseRepository<Customer> { }
}
