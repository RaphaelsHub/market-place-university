using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Entities.User;
using ECommerce.Dal.Configurations;

namespace ECommerce.Dal
{
    public class StoreContext : DbContext
    {
        public DbSet<UserEf> Users { get; set; }
        public DbSet<OrderEf> Orders { get; set; }
        public DbSet<ContactUsEf> ContactUs { get; set; }
        public DbSet<BlogEf> Blogs { get; set; }
        public DbSet<ProductEf> Products { get; set; }
        public DbSet<CategoryEf> Categories { get; set; }
        public DbSet<FilterEf> Filters { get; set; }
        public DbSet<FilterValueEf> FilterValues { get; set; }
        
        public StoreContext() : 
            base("DefaultConnection") => Connect(); 
        
        public StoreContext(string connectionStringOrName) : 
            base(connectionStringOrName) => Connect(); 

        private void Connect()
        {
            var connectionString = Database.Connection.ConnectionString;
            
            if(string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string is empty");
            
            var masterConnectionString = ConfigurationManager.ConnectionStrings["MasterConnectionString"]?.ConnectionString;
            if (string.IsNullOrEmpty(masterConnectionString))
                throw new Exception("Master connection string is empty");
            
            if(!TestConnection(connectionString))
                CreateDatabase(masterConnectionString, "Store");
        }
        
        private void CreateDatabase(string masterConnectionString, string databaseName)
        {
            try
            {
                using (var connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();
                    
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"CREATE DATABASE {databaseName}";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
        
        private bool TestConnection(string defaultConnection)
        {
            using (var connection = new SqlConnection(defaultConnection))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEfConfiguration());
            modelBuilder.Configurations.Add(new AddressEfConfiguration());
            modelBuilder.Configurations.Add(new CartItemEfConfiguration());
            modelBuilder.Configurations.Add(new OrderEfConfiguration());
            modelBuilder.Configurations.Add(new OrderItemEfConfiguration());
            modelBuilder.Configurations.Add(new ProductEfConfiguration());
            modelBuilder.Configurations.Add(new CategoryEfConfiguration());
            modelBuilder.Configurations.Add(new FilterEfConfiguration());
            modelBuilder.Configurations.Add(new FilterValueEfConfiguration());
            modelBuilder.Configurations.Add(new BlogEfConfiguration());
            modelBuilder.Configurations.Add(new MessageEfConfiguration());
            modelBuilder.Configurations.Add(new ContactUsEfConfiguration());
            
            base.OnModelCreating(modelBuilder); // This line is important, so she makes sure that all configurations are applied
        }
    }
}
