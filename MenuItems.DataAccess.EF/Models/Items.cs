using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Models
{
    public class Items
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Items() { }
        public Items(int itemID, string itemName, string description, decimal price)
        {
            ItemID = itemID;
            ItemName = itemName;
            Description = description;
            Price = price;
        }
    }
}
