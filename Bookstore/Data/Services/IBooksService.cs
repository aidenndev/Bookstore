using Bookstore.Data.Base;
using Bookstore.Models;

namespace Bookstore.Data.Services
{
    public interface IBooksService:IEntityBaseRepository<Book>
    {
    }
}
