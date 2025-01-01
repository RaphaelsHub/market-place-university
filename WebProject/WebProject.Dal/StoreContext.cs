using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WebProject.Dal
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext") { }
        public StoreContext(string connectionString) : base(connectionString) { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}