using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
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


        public ItemsRepository(MenuItemsContext context)
        {
            _context = context;
        }

        public int Create(Items items)
        {
            _context.Add(items);
            _context.SaveChanges();
            return items.ItemID;
        }
        public int Update(Items items)
        {
            Items item = _context.Items.Find(items.ItemID);
            item.ItemName = items.ItemName;
            item.Description = items.Description;
            item.Price = items.Price;

            _context.SaveChanges();
            return item.ItemID;
        }
        public bool Delete(int itemID)
        {
            _context.Remove(itemID);
            _context.SaveChanges();
            return true;
        }

        public List<Items>? GetAllItems()
        {
            List<Items> listItems = new List<Items>();
            return listItems;
        }
        public Items GetItemByID(int itemID)
        {
            Items items = _context.Items.Find(itemID);
            return items;
        }
        public List<Items> GetMealType(string menu)
        {
            List<Items> menuList = new List<Items>();
            return menuList;
        }
        /*Need "Add To Cart Button' Find how to create a method that returns a filters list using a linq. 
          Will Return GetAllDeserts*/

    }
}

