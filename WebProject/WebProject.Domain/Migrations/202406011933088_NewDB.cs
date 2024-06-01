namespace WebProject.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItemDataEFs",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UserDataId = c.Int(nullable: false),
                        OrderDataEF_OrderDataId = c.Int(),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.UserDataEFs", t => t.UserDataId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDataEFs", t => t.OrderDataEF_OrderDataId)
                .Index(t => t.UserDataId)
                .Index(t => t.OrderDataEF_OrderDataId);
            
            CreateTable(
                "dbo.UserDataEFs",
                c => new
                    {
                        UserDataId = c.Int(nullable: false, identity: true),
                        StatusUser = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Password = c.String(),
                        LogTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RegTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UserDataId);
            
            CreateTable(
                "dbo.OrderDataEFs",
                c => new
                    {
                        OrderDataId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Comment = c.String(),
                        OrderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StatusDelivery = c.Int(nullable: false),
                        UserDataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDataId)
                .ForeignKey("dbo.UserDataEFs", t => t.UserDataId, cascadeDelete: true)
                .Index(t => t.UserDataId);
            
            CreateTable(
                "dbo.CategoryDataEFs",
                c => new
                    {
                        CategoryDataId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ParentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryDataId)
                .ForeignKey("dbo.CategoryDataEFs", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.ProductDataEFs",
                c => new
                    {
                        ProductDataId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShortDescription = c.String(),
                        FullDescription = c.String(),
                        PhotoUrls = c.String(),
                        CategoryDataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDataId)
                .ForeignKey("dbo.CategoryDataEFs", t => t.CategoryDataId, cascadeDelete: true)
                .Index(t => t.CategoryDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDataEFs", "CategoryDataId", "dbo.CategoryDataEFs");
            DropForeignKey("dbo.CategoryDataEFs", "ParentCategoryId", "dbo.CategoryDataEFs");
            DropForeignKey("dbo.OrderDataEFs", "UserDataId", "dbo.UserDataEFs");
            DropForeignKey("dbo.CartItemDataEFs", "OrderDataEF_OrderDataId", "dbo.OrderDataEFs");
            DropForeignKey("dbo.CartItemDataEFs", "UserDataId", "dbo.UserDataEFs");
            DropIndex("dbo.ProductDataEFs", new[] { "CategoryDataId" });
            DropIndex("dbo.CategoryDataEFs", new[] { "ParentCategoryId" });
            DropIndex("dbo.OrderDataEFs", new[] { "UserDataId" });
            DropIndex("dbo.CartItemDataEFs", new[] { "OrderDataEF_OrderDataId" });
            DropIndex("dbo.CartItemDataEFs", new[] { "UserDataId" });
            DropTable("dbo.ProductDataEFs");
            DropTable("dbo.CategoryDataEFs");
            DropTable("dbo.OrderDataEFs");
            DropTable("dbo.UserDataEFs");
            DropTable("dbo.CartItemDataEFs");
        }
    }
}
