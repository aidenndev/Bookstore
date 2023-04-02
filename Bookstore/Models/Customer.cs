using Bookstore.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Customer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 letters.")]
        public string Name { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 50 letters.")]
        public string Password { get; set; }

        //Relationship with Book
        public List<Book>? Books { get; set; }
    }
}
