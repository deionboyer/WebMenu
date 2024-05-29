using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using MenuItems.DataAccess.EF.Repositories;

namespace WebMenu.Models
{
    public class ItemsViewModel
    {
        private ItemsRepository _repo;
        public List<Items> ItemList { get; set; }
        public List<Items> AppList { get; set; }
        public List<Items> DinList { get; set; }
        public List<Items> DesList { get; set; }
        
        public Items CurrentItem { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }
        public ItemsViewModel(MenuItemsContext context)
        {
            _repo = new ItemsRepository(context);
            ItemList = GetAllItems();
            CurrentItem = ItemList.FirstOrDefault();
        }
        public ItemsViewModel(MenuItemsContext context, int itemID)
        {
            _repo = new ItemsRepository(context);
            ItemList = GetAllItems();
            if (itemID > 0)
            {
                CurrentItem = GetItem(itemID);
            }
            else
            {
                CurrentItem = new Items();
            }
        }
        public void SaveItem(Items item)
        {
            if (item.ItemID > 0)
            {
                _repo.Update(item);
            }
            else
            {
                _repo.Create(item);
            }
            ItemList = GetAllItems();
            CurrentItem = GetItem(item.ItemID);
        }
        public void DeleteItem(int itemID)
        {
            _repo.Delete(itemID);
            ItemList = GetAllItems();
            CurrentItem = ItemList.FirstOrDefault();
        }

        public List<Items> GetAllItems()
        {
            return _repo.GetAllItems();
        }
        public Items GetItem(int id)
        {
            return _repo.GetItemByID(id);
        }
        public List<Items> GetMealByType(string menu)
        {
            return _repo.GetMealType(menu).ToList(); // This will be called on the website. When user If i move the List of Meal Type to its own page. I can make just one property and use just that one propeerty for thw whol epage. 
        }
        public void AddToCart(int itemId, int quantity)
        {
            Cart cartItem = new Cart();
            var item = GetItem(itemId);
            if (item != null)
            {
                // Assuming CartList is a property of type Cart
                cartItem.AddItem(item, quantity);
            }
        }
        ///*public Cart GetCart()
        //{
        //    // Get the cart from session or create one if it doesn't exist
        //    Cart cart = Session["Cart"] as Cart;
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        //public void SaveCart(Cart cart)
        //{
        //    // Save the cart back to session
        //    Session["Cart"] = cart;
        //}

        ///*public List<Cart> GetCartItems()
        //{

        //}
        
        //public bool AddToCart(int id, int quantity)
        //{
        //    _repo.AddToCart(id,quantity);
        //    CartList = new List<Cart>();
        //    return true;
        //}
        ////The cart does not need to be stored in database
        //// would combine and save item ids to the object its self. */
        ////state of the application
    }
}
        