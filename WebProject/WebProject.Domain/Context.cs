using System.Data.Entity;
using WebProject.Domain.DB;


namespace WebProject.Domain
{
    public class Context : DbContext
    {
        public DbSet<UserDataEF> Users { get; set; }
        public DbSet<CartItemDataEF> CartItems { get; set; }
        public DbSet<OrderDataEF> Orders { get; set; }
        public DbSet<ProductDataEF> Products { get; set; }
        public DbSet<CategoryDataEF> Category { get; set; }

        public Context() : base("Base") //подключение к mdl3.bayracraft.co.in
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
