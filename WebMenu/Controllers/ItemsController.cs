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
        // Constants for meal types
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

            // Get the list of appetizer items and assign it to the AppList property of the model
            model.AppList = model.GetMealByType(Appetizer);

            // Get the list of dinner items and assign it to the DinList property of the model
            model.DinList = model.GetMealByType(Dinner);

            // Get the list of dessert items and assign it to the DesList property of the model
            model.DesList = model.GetMealByType(Dessert); 

            return View(model); // Return the view with the model
        }
        [HttpPost]
        public IActionResult Index(int itemID, string itemName, string mealType ,string description, decimal price)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            Items items = new Items(itemID, itemName, mealType ,description, price); // Create a new item
            model.SaveItem(items); // Create a new item
            model.IsActionSuccess = true; // Indicate that the action was successful
            model.ActionMessage = "Added"; // Set the action message
            return View(model); // Return the view with the updated model
        }
        public IActionResult Update(int id)
        {
            ItemsViewModel model = new ItemsViewModel(_context, id); // Initialize the model with the specified item ID
            return View(model); // Return the view with the model
        }
        public IActionResult Delete(int id)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            if (id > 0)
            {
                model.DeleteItem(id); // Delete the item if the ID is greater than 0
            }
            model.IsActionSuccess = true; // Indicate that the action was successful
            model.ActionMessage = "Deleted";  // Set the action message
            return View("Index", model); // Return the Index view with the updated model
        }
    }
}

