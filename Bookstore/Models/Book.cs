using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Book Name")]
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 letters.")]
        public string Name { get; set; }

        public string PhotoURL { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 letters.")]
        public string Description { get; set; }

        public DateTime ReservedDate { get; set; }

        //Relationship with Customer
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
