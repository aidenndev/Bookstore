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

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<Book> UpdateAsync(string id, Book newBook)
        {
            _context.Update(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
    }
}
