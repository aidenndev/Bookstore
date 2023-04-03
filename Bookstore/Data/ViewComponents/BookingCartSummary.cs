using Bookstore.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Data.ViewComponents
{
    public class BookingCartSummary : ViewComponent
    {
        private readonly BookingCart _bookingCart;
        public BookingCartSummary(BookingCart bookingCart)
        {
            _bookingCart = bookingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _bookingCart.GetBookingCartItems();
            return View(items.Count);
        }
    }
}
