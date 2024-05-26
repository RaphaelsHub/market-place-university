using System.Data.Entity;
using WebProject.Domain.Entities.DBModels;
using WebProject.Domain.Entities.User;

namespace WebProject.Domain
{
    public class Context : DbContext
    {
        public DbSet<UserEF> Users { get; set; }
        public DbSet<AdminEF> Admins { get; set; }
        public DbSet<OrderEF> Orders { get; set; }
        public DbSet<CartItemEF> CartItems { get; set; }
        public DbSet<ProductDataEF> Products { get; set; }
        public DbSet<CategoryTypeEF> CategoryTypes { get; set; }
        public Context() : base("AzureDB") //подключение к mdl3.bayracraft.co.in
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // базовый OnModelCreating

            // добавить методы для инициилизации SuperAdmin

            //ProductDataEF
            modelBuilder.Entity<ProductDataEF>()
                .HasRequired(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false); // Отключаем каскадное удаление для категории

            modelBuilder.Entity<ProductDataEF>()
                .HasRequired(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.AdminId)
                .WillCascadeOnDelete(false); // Отключаем каскадное удаление для админа

            //OrderEF
            modelBuilder.Entity<OrderEF>()
                .HasRequired(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .WillCascadeOnDelete(false); // Отключаем каскадное удаление для пользователя

            modelBuilder.Entity<OrderEF>()
                .HasRequired(o => o.Admin)
                .WithMany()
                .HasForeignKey(o => o.AdminId)
                .WillCascadeOnDelete(false); // Отключаем каскадное удаление для админа

        }

    }
}
