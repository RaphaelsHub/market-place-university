namespace WebProject.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        PostalCode = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                        UserType = c.Int(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        IsVerified = c.Int(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                        IsSignUpForNewsletter = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.UserId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        FullDescription = c.String(),
                        DatePost = c.DateTime(nullable: false),
                        ProductSellType = c.Int(nullable: false),
                        ProductVisibilityStatus = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ParentCategoryId = c.Int(nullable: false, identity: true),
                        ChildCategoryId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Filters",
                c => new
                    {
                        FilterId = c.Int(nullable: false, identity: true),
                        FilterName = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilterId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.FilterValues",
                c => new
                    {
                        FilterValueId = c.Int(nullable: false, identity: true),
                        FilterValueName = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        FilterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilterValueId)
                .ForeignKey("dbo.Filters", t => t.FilterId, cascadeDelete: true)
                .Index(t => t.FilterId);
            
            CreateTable(
                "dbo.RateItems",
                c => new
                    {
                        RateItemId = c.Int(nullable: false, identity: true),
                        Rate = c.Single(nullable: false),
                        FullName = c.String(),
                        Comment = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RateItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        SubTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Single(nullable: false),
                        DateOrdered = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateSent = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IsReplied = c.Boolean(nullable: false),
                        BlogId = c.Int(nullable: false),
                        UserSenderId = c.Int(nullable: false),
                        UserReceiverId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.UserSenderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserReceiverId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.UserSenderId)
                .Index(t => t.UserReceiverId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        CreatedRequest = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Messages", "UserReceiverId", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserSenderId", "dbo.Users");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.CartItems", "UserId", "dbo.Users");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.RateItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Filters", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.FilterValues", "FilterId", "dbo.Filters");
            DropIndex("dbo.Messages", new[] { "UserReceiverId" });
            DropIndex("dbo.Messages", new[] { "UserSenderId" });
            DropIndex("dbo.Messages", new[] { "BlogId" });
            DropIndex("dbo.OrderItems", new[] { "UserId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.RateItems", new[] { "ProductId" });
            DropIndex("dbo.FilterValues", new[] { "FilterId" });
            DropIndex("dbo.Filters", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.CartItems", new[] { "UserId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.ContactUs");
            DropTable("dbo.Messages");
            DropTable("dbo.Blogs");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.RateItems");
            DropTable("dbo.FilterValues");
            DropTable("dbo.Filters");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.CartItems");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
