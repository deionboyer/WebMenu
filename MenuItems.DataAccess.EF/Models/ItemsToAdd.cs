namespace MenuItems.DataAccess.EF.Models
{
    public class ItemsToAdd
    {
        public ItemsToAdd(int iD, int quantity)
        {
            ID = iD;
            Quantity = quantity;
        }

        public int ID { get; set; }
        public int Quantity {  get; set; }
        //Just holds information. Just to create a Cart that holds the item id and how many of them . 
    }
}