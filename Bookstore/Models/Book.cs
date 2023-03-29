using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  
        public DateTime ReservedDate { get; set; }
        public Customer? Customer { get; set; }
    }
}
