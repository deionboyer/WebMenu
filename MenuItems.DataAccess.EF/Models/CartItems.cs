namespace MenuItems.DataAccess.EF.Models
{
    public class CartItems
    {
        public int CartItemId { get; set; }
        public int ItemId { get; set; }
        public Items Item { get; set; }
        public int Quantity { get; set; }
    }
}