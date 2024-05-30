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
        public int CartItemId { get; set; }
        public string ItemName {  get; set; }
        public string Description {  get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Items Item { get; set; }
        public int Quantity { get; set; }
        public CartItem()
        {

        }
        public CartItem(int cartItemId, string itemName, string description, int itemId, Items item, int quantity)
        {
            CartItemId = cartItemId;
            ItemName = itemName;
            Description = description;
            ItemId = itemId;
            Item = item;
            Quantity = quantity;
        }
    }
}
