using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
