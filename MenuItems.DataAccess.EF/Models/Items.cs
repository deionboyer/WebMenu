using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Models
{
    public class Items
    {
        public int ItemID { get; set; }
        public string MealType { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; }
        public Items() { }
        public Items(int itemID, string itemName, string mealType ,string description, decimal price)
        {
            ItemID = itemID;
            ItemName = itemName;
            MealType = mealType;
            Description = description;
            Price = price;
            
        }
    }
}
