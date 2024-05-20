using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using WebMenu.Models;

namespace WebMenu.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MenuItemsContext _context;
        public ItemsController(MenuItemsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int itemID, string itemName, string description, decimal price)
        {
            ItemsViewModel model = new ItemsViewModel(_context);
            Items items = new Items(itemID, itemName, description, price);
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
        public IActionResult GetAllAppetizers(string menu)
        {
            menu = "Appetizer";
            ItemsViewModel model = new ItemsViewModel(_context);
            model.GetAllAppetizers(menu);
            model.IsActionSuccess = true;
            model.ActionMessage = "";
            return View(model);
        }
        public IActionResult GetAllDinners(string menu)
        {
            menu = "Dinner";
            ItemsViewModel model = new ItemsViewModel(_context);
            model.GetAllDinenrs(menu);
            model.IsActionSuccess = true;
            model.ActionMessage = "";
            return View(model);
        }
        public IActionResult GetAllDesserts(string menu)
        {
            menu = "Dessert";
            ItemsViewModel model = new ItemsViewModel(_context);
            model.GetAllDesserts(menu);
            model.IsActionSuccess = true;
            model.ActionMessage = "";
            return View(model);
        }

        /* Need an "Add To Cart" Button*/
    }
}

