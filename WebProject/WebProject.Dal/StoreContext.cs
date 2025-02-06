using System;
using System.Data.Entity;
using System.Data.SqlClient;
using WebProject.Core.Entities.Blog;
using WebProject.Core.Entities.Product;
using WebProject.Core.Entities.User;
using WebProject.Dal.Configurations;

namespace WebProject.Dal
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection")
        {
            if(!TestConnection("DefaultConnection"))
                CreateDatabase("MasterConnection", "Store");
            
            // if(!Database.Exists())
            //     Database.SetInitializer(new CreateDatabaseIfNotExists<StoreContext>());
        }
        public StoreContext(string connectionString) : base(connectionString)
        {
        }

        private void CreateDatabase(string masterConnectionString, string databaseName)
        {
            try
            {
                using (var connection =new SqlConnection(masterConnectionString))
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
                Console.WriteLine("Error: " + e.Message);
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
                    Console.WriteLine("Error: " + e.Message);
                    return false;
                }
            }
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
        public DbSet<BlogEf> Blogs { get; set; }
        public DbSet<MessageEf> Messages { get; set; }
        public DbSet<ContactUsEf> ContactUs { get; set; }
        
        

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
            modelBuilder.Configurations.Add(new RateItemEfConfiguration());
            modelBuilder.Configurations.Add(new BlogEfConfiguration());
            modelBuilder.Configurations.Add(new MessageEfConfiguration());
            modelBuilder.Configurations.Add(new ContactUsEfConfiguration());
            
            base.OnModelCreating(modelBuilder); // This line is important, so she makes sure that all configurations are applied
        }
    }
}