namespace byggemarked.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hardwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Deposit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HardwareId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Status = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Hardwares", t => t.HardwareId, cascadeDelete: true)
                .Index(t => t.HardwareId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "HardwareId", "dbo.Hardwares");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.Rentals", new[] { "HardwareId" });
            DropTable("dbo.Rentals");
            DropTable("dbo.Hardwares");
            DropTable("dbo.Customers");
        }
    }
}
