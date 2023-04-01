using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Services
{
    public class BooksService : IBooksService
    {
        private readonly AppDbContext _context;

        //Constructor
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public Book GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Book Update(string id, Book newBook)
        {
            throw new NotImplementedException();
        }
    }
}
