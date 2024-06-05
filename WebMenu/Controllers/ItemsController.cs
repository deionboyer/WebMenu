using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using MenuItems.DataAccess.EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel;
using System.ComponentModel.Design;
using WebMenu.Models;

namespace WebMenu.Controllers
{
    public class ItemsController : Controller
    {
        
        private const string Appetizer = "Appetizer";
        private const string Dinner = "Dinner";
        private const string Dessert = "Dessert";
        private readonly MenuItemsContext _context;
        public ItemsController(MenuItemsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            //Calls my GetMealByTtype Method. 
            //they are getting called before my View is return so they are holdong valuse prior to being Viewed. 
            model.AppList = model.GetMealByType(Appetizer);
            model.DinList = model.GetMealByType(Dinner);
            model.DesList = model.GetMealByType(Dessert);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int itemID, string itemName, string mealType ,string description, decimal price)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            Items items = new Items(itemID, itemName, mealType ,description, price);
            model.SaveItem(items);
            model.IsActionSuccess = true;
            model.ActionMessage = "Added";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            ItemsViewModel model = new ItemsViewModel(_context, id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            if (id > 0)
            {
                model.DeleteItem(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Deleted";
            return View("Index", model);
        }
        //public IActionResult AddItemToCart(int itemId, int quantity)
        //{
        //    ItemsViewModel model = new ItemsViewModel(_context);
        //    model.AddToCart(_context, itemId, quantity);
        //    model.IsActionSuccess = true;
        //    model.ActionMessage = "Add To Cart";
        //    // Redirect to the cart view or return a success response
        //    return Json(new { success = true }); // Return a JSON response
        //}

        ////public IActionResult RemoveItemFromCart(int itemId)
        ////{
        ////    ItemsViewModel model = new ItemsViewModel(_context);
        ////    model.RemoveFromCart(_context, itemId);
        ////    model.IsActionSuccess = true;
        ////    model.ActionMessage = "Item Deleted";
        ////    // Redirect to the cart view or return a success response
        ////    return RedirectToAction("ViewCart");
        ////}

        ////public IActionResult ViewCart()
        ////{
        ////    ItemsViewModel model = new ItemsViewModel(_context);
        ////    var total = model.GetCartTotal(_context);
        ////    var cartItems = _context.Carts
        ////        .Include(c => c.CartItems)
        ////        .ThenInclude(ci => ci.Item)
        ////        .FirstOrDefault()?.CartItems;
        ////    // Pass the cart items and total to the view
        ////    return View(new CartsViewModel { CartItems = cartItems, Total = total });
        ////}


        //Controller 
        /*public ActionResult AddToCart(int id)
        {
            var item = _context.MenuItems.Find(id);
            if (item != null)
            {
                // Assuming you have a method to get the current cart from session
                var cart = GetCart();
                var cartItem = cart.Items.FirstOrDefault(i => i.ItemId == id);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        ItemId = item.Id,
                        ItemName = item.Name,
                        Price = item.Price,
                        Quantity = 1
                    });
                }
                // Assuming you have a method to save the cart back to session
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }
        /*public IActionResult AddItemsToCart(int id,int quantity)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            bool addedToCart = model.AddToCart(id, quantity);
            if (addedToCart)
            {
                return RedirectToAction("Cart", "Home");
            }
            else
            {
                return View("Error");
            }
            
        }

        /* Need an "Add To Cart" Button*/
    }
}

