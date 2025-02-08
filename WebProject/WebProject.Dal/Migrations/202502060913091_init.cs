namespace WebProject.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            AddForeignKey("dbo.CartItems", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            DropColumn("dbo.CartItems", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.CartItems", "UserId", "dbo.Users");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Orders", "AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.CartItems", "UserId", "dbo.Users", "UserId");
        }
    }
}
