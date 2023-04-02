using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class BookingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Book Book { get; set; }
        public int Amount { get; set; }

        public string BookingCartId { get; set; }

    }
}
