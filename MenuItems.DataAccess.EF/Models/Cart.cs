using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItems.DataAccess.EF.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string CartName { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Tip { get; set; }
        public decimal TotalPrice { get; set; }
        public Cart() { }
        public Cart(int cartID, string cartName, decimal itemPrice,int quantity ,decimal tip, decimal totalPrice)
        {
            CartID = cartID;
            CartName = cartName;
            ItemPrice = itemPrice;
            Quantity = quantity;
            Tip = tip;
            TotalPrice = totalPrice;
        }
    }
}
