using Bookstore.Data.Base;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        //Constructor
        public BooksService(AppDbContext context) : base(context) { }
    }
}
