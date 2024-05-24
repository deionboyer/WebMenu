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
        public Cart() 
        { 
            ItemsAdded = new List<ItemsToAdd>(); // already have a list, now its empty
        }
        public void AddToCart(int id, int quantity)
        {
            var itemToAdd = new ItemsToAdd(id,quantity);
            ItemsAdded.Add(itemToAdd);
        }
        //use contructor to make sure the list is created. 
        //Calculate total 
    }
}
