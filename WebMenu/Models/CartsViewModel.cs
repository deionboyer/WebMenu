using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using MenuItems.DataAccess.EF.Repositories;

namespace WebMenu.Models
{
    public class CartsViewModel
    {
        private ItemsRepository _repo;

        public List<CartItem>? CartItems { get;  set; }
        public decimal Total { get;  set; }

        public void AddToCart(MenuItemsContext context, int itemId, int quantity)
        {
            _repo.AddItem(context, itemId, quantity);
        }
        public void RemoveFromCart(MenuItemsContext context, int itemId)
        {
            _repo.RemoveItem(context, itemId);
        }
        public decimal GetCartTotal(MenuItemsContext context)
        {
            return _repo.GetTotal(context);

        }
    }
}
