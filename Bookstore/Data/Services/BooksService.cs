using Bookstore.Data.Base;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        //Constructor
        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(n => n.Id == id);
            return book;
        }
    }
}
