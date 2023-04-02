using Bookstore.Data.Cart;
using Bookstore.Data.Services;
using Bookstore.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBooksService _booksService;
        private readonly BookingCart _bookingCart;
        public OrdersController(IBooksService booksService, BookingCart bookingCart)
        {
            _booksService = booksService;
            _bookingCart = bookingCart;
        }

        public IActionResult BookingCart()
        {
            var items = _bookingCart.GetBookingCartItems();
            _bookingCart.BookingCartItems = items;
            
            var response = new BookingCartViewModel()
            {
                BookingCart = _bookingCart
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddToBookingCart(int id)
        {
            var item = await _booksService.GetByIdAsync(id);

            if(item != null)
            {
                _bookingCart.AddItemToCart(item);  
            }
            return RedirectToAction(nameof(BookingCart));
        }
    }
}
