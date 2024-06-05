using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        //public string ItemName { get; set; }
        public Items Item { get; set; }
        public int Quantity { get; set; }
        public double Price {  get; set; }
        public CartItem()
        {

        }
        public CartItem(int id, int itemId, string itemName, Items item, int quantity, double price)
        {
            //Id = id;
            //ItemId = itemId;
            //ItemName = itemName;
            Item = item;
            Quantity = quantity;
            Price = price;
        }
        public CartItem(int id, int itemId, string itemName, int quantity, double price)
        {
            //Id = id;
            ItemId = itemId;
            //ItemName = itemName;
            Quantity = quantity;
        }
    }
}
