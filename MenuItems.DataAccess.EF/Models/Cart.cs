using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Models
{
    public class Cart
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public List<ItemsToAdd> ItemsAdded { get; set; }
        /*public Cart() 
        { 
            ItemsAdded = new List<ItemsToAdd>(); // already have a list, now its empty
        }
        public void AddToCart(int id, int quantity)
        {
            var itemToAdd = new ItemsToAdd(id,quantity);
            ItemsAdded.Add(itemToAdd);
        }
        public Cart GetCart()
        {
            // Get the cart from session or create one if it doesn't exist
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public void SaveCart(Cart cart)
        {
            // Save the cart back to session
            Session["Cart"] = cart;
        }
        public static class SessionExtensions
        {
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }

            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
        //use contructor to make sure the list is created. 
        //Calculate total */
    }
}
