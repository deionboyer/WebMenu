using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using MenuItems.DataAccess.EF.Repositories;

namespace WebMenu.Models
{
    public class CartsViewModel
    {
        private ItemsRepository _repo;

        public CartsViewModel(MenuItemsContext context)
        {
            _repo = new ItemsRepository(context);
        }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal Total { get;  set; }

        
        //public decimal GetCartTotal()
        //{
        //    return _repo.GetTotal();

        //}
    }
}
