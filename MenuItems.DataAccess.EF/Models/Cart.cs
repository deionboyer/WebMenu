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
        public int CartId { get; set; }
        public List<CartItems> CartItem { get; set; }

        public Cart()
        {
            CartItem = new List<CartItems>();
        }

        public void AddItem(Items item, int quantity = 1)
        {
            var existingItem = CartItem.FirstOrDefault(ci => ci.ItemId == item.ItemID);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItem.Add(new CartItems { ItemId = item.ItemID, Item = item, Quantity = quantity });
            }
        }

        public void RemoveItem(int itemId)
        {
            var cartItem = CartItem.FirstOrDefault(ci => ci.ItemId == itemId);
            if (cartItem != null)
            {
                CartItem.Remove(cartItem);
            }
        }

        public decimal GetTotal()
        {
            return CartItem.Sum(ci => ci.Item.Price * ci.Quantity);
        }
    }
}
