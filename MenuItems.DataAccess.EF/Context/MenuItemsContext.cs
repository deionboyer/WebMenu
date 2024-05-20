using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MenuItems.DataAccess.EF.Models;
using MenuItems.DataAccess.EF.Models;

namespace MenuItems.DataAccess.EF.Context
{
    public class MenuItemsContext :DbContext
    {
        public MenuItemsContext()
        {

        }
        public MenuItemsContext(DbContextOptions<MenuItemsContext> options) : base(options)
        {

        }
        public virtual DbSet<Items> Items { get; set; }
        
    }
}
