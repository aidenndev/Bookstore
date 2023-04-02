﻿using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Data.Cart
{
    public class BookingCart
    {
        public AppDbContext _context { get; set; }
        //Constructor
        public BookingCart(AppDbContext _context)
        {
            _context = _context;
        }

        public string BookingCartId { get; set; }
        public List<BookingCartItem> BookingCartItems { get; set; }


        //Get the current cart
        public static BookingCart GetBookingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CardId", cartId);

            return new BookingCart(context)
            {
                BookingCartId = cartId
            };
        }

        //Add a book to cart
        public void AddItemToCart(Book book)
        {
            var cartItem = _context.BookingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.BookingCartId == BookingCartId);
            if (cartItem == null)
            {
                cartItem = new BookingCartItem()
                {
                    BookingCartId = BookingCartId,
                    Book = book,
                    Amount = 1
                };

                _context.BookingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount++;
            }
            _context.SaveChanges();
        }

        //Remove a book from cart
        public void RemoveItemFromCart(Book book)
        {
            var cartItem = _context.BookingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.BookingCartId == BookingCartId);
            if (cartItem != null)
            {
                if(cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                }
                else
                {
                    _context.BookingCartItems.Remove(cartItem);
                }
            }
            _context.SaveChanges();
        }

        //Get the list of books in the current cart
        public List<BookingCartItem> GetBookingCartItems()
        {
            return BookingCartItems ?? (BookingCartItems = _context.BookingCartItems.Where(n => n.BookingCartId == BookingCartId).Include(n => n.Book).ToList());
        }
    }
}