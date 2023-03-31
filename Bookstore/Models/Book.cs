using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}
