using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebMenu.Models;

namespace WebMenu.Controllers
{
    public class CartController : Controller
    {
        private readonly MenuItemsContext _context;

        public CartController(MenuItemsContext context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int id, int itemId, string itemName, int quantity, double price)
        {
            CartsViewModel model = new CartsViewModel(_context);
            CartItem cartItem = new CartItem(id, itemId, itemName,quantity,price);
            return View(model);
        }
        public IActionResult AddItem( int itemId,string itemName, int quantity)
        {
            CartsViewModel model = new CartsViewModel(_context);
           
            return View(model);
        }
        public IActionResult RemoveItem(CartItem cartsItem)
        {
            CartsViewModel model = new CartsViewModel(_context);
           
            return View(model);
        }

        // Helper method to get the current user's cart
        //private Cart GetCurrentUserCart()
        //{
        //    // Implement logic to retrieve the current user's cart
        //    // This could be from the database or the session, depending on your application's design
        //}
    }
}
