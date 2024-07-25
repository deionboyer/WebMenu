using MenuItems.DataAccess.EF.Context;
using MenuItems.DataAccess.EF.Models;
using MenuItems.DataAccess.EF.Repositories;

namespace WebMenu.Models
{
    public class ItemsViewModel
    {
        private ItemsRepository _repo;
        public List<Items> ItemList { get; set; } // List of all items
        public List<Items> AppList { get; set; } // List of appetizer items
        public List<Items> DinList { get; set; } // List of dinner items
        public List<Items> DesList { get; set; } // List of dessert items
        public Items CurrentItem { get; set; } // The current item being viewed or edited
        public bool IsActionSuccess { get; set; } // Indicates if the last action was successful
        public string ActionMessage { get; set; } // Message related to the last action
        
        // Constructor that initializes the repository and loads all items
        public ItemsViewModel(MenuItemsContext context)
        {
            _repo = new ItemsRepository(context);
            ItemList = GetAllItems();
            CurrentItem = ItemList.FirstOrDefault(); // Set the first item as the current item
        }

        // Constructor that initializes the repository and loads a specific item by ID
        public ItemsViewModel(MenuItemsContext context, int itemID)
        {
            _repo = new ItemsRepository(context);
            ItemList = GetAllItems();
            if (itemID > 0)
            {
                CurrentItem = GetItem(itemID); // Set the current item to the specified item
            }
            else
            {
                CurrentItem = new Items(); // Create a new item if no ID is specified
            }
        }

        // Save an item (create or update)
        public void SaveItem(Items item)
        {
            if (item.ItemID > 0)
            {
                _repo.Update(item); // Update existing item
            }
            else
            {
                _repo.Create(item); // Create new item
            }
            ItemList = GetAllItems(); // Refresh the item list
            CurrentItem = GetItem(item.ItemID); // Set the current item to the saved item
        }

        // Delete an item by ID
        public void DeleteItem(int itemID)
        { 
            _repo.Delete(itemID); // Delete the item
            ItemList = GetAllItems(); // Refresh the item list
            CurrentItem = ItemList.FirstOrDefault(); // Set the current item to the first item in the list
        }

        // Get all items from the repository
        public List<Items> GetAllItems()
        {
            return _repo.GetAllItems();
        }

        // Get a specific item by ID
        public Items GetItem(int id)
        {
            return _repo.GetItemByID(id);
        }

        // Get items by meal type (e.g., Appetizer, Dinner, Dessert)
        public List<Items> GetMealByType(string menu)
        {
            return _repo.GetMealType(menu).ToList(); 
        }
    }
}
        