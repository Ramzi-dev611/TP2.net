namespace ShopingStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCategory_CategoryId = c.Int(),
                        ProductOrder_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.ProductCategory_CategoryId)
                .ForeignKey("dbo.Orders", t => t.ProductOrder_OrderId, cascadeDelete: true)
                .Index(t => t.ProductCategory_CategoryId)
                .Index(t => t.ProductOrder_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductOrder_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "ProductCategory_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ProductOrder_OrderId" });
            DropIndex("dbo.Products", new[] { "ProductCategory_CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
        }
    }
}
