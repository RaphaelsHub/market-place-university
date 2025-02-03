using System.Data.Entity;
using WebProject.Core.Entities;
using WebProject.Core.Entities.Product;
using WebProject.Core.Entities.User;

namespace WebProject.Dal
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext")
        {
        }

        public StoreContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<UserEf> Users { get; set; }
        public DbSet<OrderEf> Orders { get; set; }
        public DbSet<OrderItemEf> OrderItems { get; set; }
        public DbSet<AddressEf> Addresses { get; set; }
        public DbSet<CartItemEf> CartItems { get; set; }
        public DbSet<ProductEf> Products { get; set; }
        public DbSet<RateItemEf> RateItems { get; set; }
        public DbSet<CategoryEf> Categories { get; set; }
        public DbSet<FilterEf> Filters { get; set; }
        public DbSet<FilterValueEf> FilterValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Configuring the UserEf entity.

            modelBuilder.Entity<UserEf>().ToTable("Users");
            modelBuilder.Entity<UserEf>().HasKey(x => x.UserId);

            modelBuilder.Entity<UserEf>().HasMany(x => x.Addresses).WithRequired(x => x.User);

            modelBuilder.Entity<UserEf>().HasMany(x => x.Orders).WithRequired(x => x.User);

            modelBuilder.Entity<UserEf>().HasMany(x => x.CartItems).WithRequired(x => x.User);

            #endregion

            #region Configuring the AddressEf entity.

            modelBuilder.Entity<AddressEf>().ToTable("Addresses");
            modelBuilder.Entity<AddressEf>().HasKey(x => x.AddressId);

            modelBuilder.Entity<AddressEf>().HasRequired(x => x.User).WithMany(x => x.Addresses)
                .HasForeignKey(x => x.UserId);

            #endregion

            #region Configuring the CartItemEf entity.

            modelBuilder.Entity<CartItemEf>().ToTable("CartItems");

            modelBuilder.Entity<CartItemEf>().HasKey(x => new { x.ProductId, x.UserId });

            modelBuilder.Entity<CartItemEf>().HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<CartItemEf>().HasRequired(x => x.User).WithMany(x => x.CartItems)
                .HasForeignKey(x => x.UserId);

            #endregion

            #region Configuring the OrderEf entity.

            modelBuilder.Entity<OrderEf>().ToTable("Orders");
            modelBuilder.Entity<OrderEf>().HasKey(x => x.OrderId);

            modelBuilder.Entity<OrderEf>().HasRequired(x => x.User).WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<OrderEf>().HasRequired(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);

            modelBuilder.Entity<OrderEf>().HasMany(x => x.OrderItems).WithRequired(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            #endregion

            #region Configuring the OrderItemEf entity.

            modelBuilder.Entity<OrderItemEf>().ToTable("OrderItems");

            modelBuilder.Entity<OrderItemEf>().HasKey(x => x.OrderItemId);

            modelBuilder.Entity<OrderItemEf>().HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<OrderItemEf>().HasRequired(x => x.Order).WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderItemEf>().HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            #endregion

            #region Configuring the ProductEf entity.

            modelBuilder.Entity<ProductEf>().ToTable("Products");

            modelBuilder.Entity<ProductEf>().HasKey(x => x.ProductId);

            modelBuilder.Entity<ProductEf>().HasRequired(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<ProductEf>().HasMany(x => x.RateItems).WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            #endregion

            #region Configuring the RateItemEf entity.

            modelBuilder.Entity<RateItemEf>().ToTable("RateItems");

            modelBuilder.Entity<RateItemEf>().HasKey(x => x.RateItemId);

            modelBuilder.Entity<RateItemEf>().HasRequired(x => x.Product)
                .WithMany(x => x.RateItems)
                .HasForeignKey(x => x.ProductId);

            #endregion

            #region Configuring the CategoryEf entity.

            modelBuilder.Entity<CategoryEf>().ToTable("Categories");

            modelBuilder.Entity<CategoryEf>().HasKey(x => x.ParentCategoryId);

            modelBuilder.Entity<CategoryEf>().HasMany(x => x.Filters).WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            #endregion

            #region Configuring the FilterEf entity.

            modelBuilder.Entity<FilterEf>().ToTable("Filters");

            modelBuilder.Entity<FilterEf>().HasKey(x => x.FilterId);

            modelBuilder.Entity<FilterEf>().HasRequired(x => x.Category).WithMany(x => x.Filters)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<FilterEf>().HasMany(x => x.FilterValues).WithRequired(x => x.Filter)
                .HasForeignKey(x => x.FilterId);

            #endregion

            #region Configuring the FilterValueEf entity.

            modelBuilder.Entity<FilterValueEf>().ToTable("FilterValues");

            modelBuilder.Entity<FilterValueEf>().HasKey(x => x.FilterValueId);

            modelBuilder.Entity<FilterValueEf>().HasRequired(x => x.Filter).WithMany(x => x.FilterValues)
                .HasForeignKey(x => x.FilterId);

            #endregion
        }
    }
}