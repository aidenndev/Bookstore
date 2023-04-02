using Bookstore.Models;

namespace Bookstore.Data.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(string id);
        Task AddAsync(Book book);
        Task<Book> UpdateAsync(string id, Book newBook);
        Task DeleteAsync(string id);
    }
}
