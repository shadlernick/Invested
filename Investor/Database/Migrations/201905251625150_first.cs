namespace Investor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Info = c.String(),
                        Card = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DealClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealSubs = c.String(),
                        ClientName = c.String(),
                        SumIn = c.Int(nullable: false),
                        Info = c.String(),
                        DealId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Subscription = c.String(),
                        Sum = c.Int(nullable: false),
                        Profit = c.String(),
                        DateIn = c.DateTime(nullable: false),
                        DateOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Deals");
            DropTable("dbo.DealClients");
            DropTable("dbo.Clients");
        }
    }
}
