using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
