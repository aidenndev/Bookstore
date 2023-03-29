using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Relationship with Book
        public List<Book> Books { get; set; }
    }
}
