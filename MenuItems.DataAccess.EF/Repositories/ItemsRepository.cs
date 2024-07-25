using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Repositories
{
    public class ItemsRepository
    {
        private MenuItemsContext _context;
        public List<Items> CartItems { get; set; } // List to store cart items
        public ItemsRepository(MenuItemsContext context)
        {
            _context = context;
        }
        // Method to create a new item
        public int Create(Items items)
        {
            _context.Add(items); // Add the new item to the context
            _context.SaveChanges(); // Save changes to the database
            return items.ItemID;  // Return the ID of the created item
        }
        // Method to update an existing item
        public int Update(Items items)
        {
            Items item = _context.Items.Find(items.ItemID); // Find the item by ID
            item.ItemName = items.ItemName; // Update the item name
            item.Description = items.Description; // Update the item description
            item.Price = items.Price;  // Update the item price

            _context.SaveChanges(); // Save changes to the database
            return item.ItemID; // Return the ID of the updated item
        }
        // Method to delete an item by ID
        public bool Delete(int itemID)
        {
            _context.Remove(itemID); // Remove the item from the context
            _context.SaveChanges(); // Save changes to the database
            return true; // Return true to indicate successful deletion
        }
        // Method to get all items (currently returns an empty list)
        public List<Items>? GetAllItems()
        {
            List<Items> listItems = new List<Items>(); // Create a new list of items
            return listItems; // Return the list of items
        }
        // Method to get an item by ID
        public Items GetItemByID(int itemID)
        {
            Items items = _context.Items.Find(itemID); // Find the item by ID
            return items; // Return the found item
        }
        // Method to get items by meal type (e.g., Appetizer, Dinner, Dessert)
        public IQueryable<Items> GetMealType(string menu)
        {
            return _context.Items.Where(x=> x.MealType == menu); // Filter items by meal type
        }
    }
}

