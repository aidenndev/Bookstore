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
            
            var response = new BookingCartVM()
            {
                BookingCart = _bookingCart,
                TotalBookingFee = _bookingCart.GetTotalBookingFee()
            };
            return View(response);
        }

        //Add a book to the cart
        public async Task<IActionResult> AddItemToBookingCart(int id)
        {
            var item = await _booksService.GetBookByIdAsync(id);

            if(item != null)
            {
                _bookingCart.AddItemToCart(item);  
            }
            return RedirectToAction(nameof(BookingCart));
        }

        //Remove a book from a cart
        public async Task<IActionResult> RemoveItemFromBookingCart(int id)
        {
            var item = await _booksService.GetBookByIdAsync(id);

            if (item != null)
            {
                _bookingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(BookingCart));
        }
    }
}
