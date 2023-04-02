using Bookstore.Models;

namespace Bookstore.Data.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customer>> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        Customer Update(int id, Customer newCustomer);
        void Delete(int id);
    }
}
