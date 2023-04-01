using Bookstore.Models;

namespace Bookstore.Data.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAll();
        Book GetById(string id);
        void Add(Book book);
        Book Update(string id, Book newBook);
        void Delete(string id);
    }
}
