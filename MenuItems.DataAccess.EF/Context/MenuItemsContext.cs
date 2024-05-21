using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MenuItems.DataAccess.EF.Models;


namespace MenuItems.DataAccess.EF.Context
{
    public class MenuItemsContext : DbContext
    {
        public MenuItemsContext()
        {

        }
        public MenuItemsContext(DbContextOptions<MenuItemsContext> options) : base(options)
        {

        }
        public virtual DbSet<Items> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemID);

                entity.Property(e => e.ItemID).HasColumnName("ItemID");

                entity.Property(e => e.MealType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(255);
            });
            OnModelCreatingPartial(modelBuilder);


        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
