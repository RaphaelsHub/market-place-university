using System.Data.Entity;
using WebProject.Core.Entities.User;

namespace WebProject.Dal
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext") { }
        public StoreContext(string connectionString) : base(connectionString) { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            #region Configuring the UserEf entity.
            
            modelBuilder.Entity<UserEf>().ToTable("Users");
            modelBuilder.Entity<UserEf>().HasKey(x => x.UserId);
            
            modelBuilder.Entity<UserEf>().
                HasMany(x=>x.Addresses).
                WithRequired(x=>x.User);
            
            modelBuilder.Entity<UserEf>().
                HasMany(x=>x.Orders).
                WithRequired(x=>x.User);
            
            modelBuilder.Entity<UserEf>().
                HasMany(x=>x.CartItems).
                WithRequired(x=>x.User);
            
            #endregion
            
            #region Configuring the AddressEf entity.

            modelBuilder.Entity<AddressEf>().ToTable("Addresses");
            modelBuilder.Entity<AddressEf>().HasKey(x => x.AddressId);
            
            modelBuilder.Entity<AddressEf>().
                HasRequired(x => x.User).
                WithMany(x => x.Addresses).
                HasForeignKey(x => x.UserId);

            #endregion
            
            #region Configuring the CartItemEf entity.
            
            modelBuilder.Entity<CartItemEf>().ToTable("CartItems");

            modelBuilder.Entity<CartItemEf>().
                HasKey(x => new {x.ProductId, x.UserId});
            
            modelBuilder.Entity<CartItemEf>().
                HasRequired(x=>x.Product).
                WithMany().
                HasForeignKey(x=>x.ProductId);
            
            modelBuilder.Entity<CartItemEf>().
                HasRequired(x=>x.User).
                WithMany(x=>x.CartItems).
                HasForeignKey(x=>x.UserId);
            
            #endregion 
            
            #region Configuring the OrderEf entity.
            
            modelBuilder.Entity<OrderEf>().ToTable("Orders");
            modelBuilder.Entity<OrderEf>().HasKey(x => x.OrderId);
            
            modelBuilder.Entity<OrderEf>().
                HasRequired(x=>x.User).
                WithMany(x=>x.Orders).
                HasForeignKey(x=>x.UserId);
            
            modelBuilder.Entity<OrderEf>().
                HasRequired(x=>x.Address).
                WithMany().
                HasForeignKey(x=>x.AddressId);
            
            modelBuilder.Entity<OrderEf>().
                HasMany(x=>x.OrderItems).
                WithRequired(x=>x.Order)
                .HasForeignKey(x=>x.OrderId);
            
           #endregion 
            
           #region Configuring the OrderItemEf entity.
           
           modelBuilder.Entity<OrderItemEf>().ToTable("OrderItems");
           
           modelBuilder.Entity<OrderItemEf>().
               HasKey(x => x.OrderItemId);
           
           modelBuilder.Entity<OrderItemEf>().
               HasRequired(x=>x.Product).
                WithMany().
               HasForeignKey(x=>x.ProductId);
           
           modelBuilder.Entity<OrderItemEf>().
               HasRequired(x=>x.Order).
               WithMany(x=>x.OrderItems).
               HasForeignKey(x=>x.OrderId);
           
           modelBuilder.Entity<OrderItemEf>().
               HasRequired(x=>x.User).
               WithMany().
               HasForeignKey(x=>x.UserId);
           
           #endregion
            
            
        }
    }
}