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
        public List<Items> CartItems { get; set; }
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
        public IQueryable<Items> GetMealType(string menu)
        {
            return _context.Items.Where(x=> x.MealType == menu);//Filter the result. Will only return an IQuaerable, returns an IENumerable obeject. Filterd by the mealtype assigned
        }
        //Divide everything in small chunkcs fix things one thing at a time. 

        
        //Adds removed read info from database it has to be on the repository


        //Create static list at top. Addthe methods 
        ///*public IQueryable<Cart> GetCartTotal(int totalPrice)
        //{
        //    Cart cart;
        //    //Calc total price of items in the cart. 
        //    //Call that takes a cart as a argument
        //    //uses Linq to filter 
        //    //Get cart total does return anything. 
        //    //Passing in cart object. 
        //    //I have acces tot he cart object. 
        //    //Use linq to hit the table of items then foreach item to find ID and then mulitply that by quantity
        //    //When

        //}

        ///*Need "Add To Cart Button' Find how to create a method that returns a filters list using a linq. 
        //  Will Return GetAllDeserts*/

    }
}

