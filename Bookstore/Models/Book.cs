using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public DateTime ReservedDate { get; set; }

        //Relationship with Customer
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
