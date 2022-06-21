namespace MassCall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelAddeded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MonthlyEntries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Member_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Members", t => t.Member_id)
                .Index(t => t.Member_id);
            
            CreateTable(
                "dbo.MonthPays",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MonthCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Member_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Members", t => t.Member_id)
                .Index(t => t.Member_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthPays", "Member_id", "dbo.Members");
            DropForeignKey("dbo.MonthlyEntries", "Member_id", "dbo.Members");
            DropIndex("dbo.MonthPays", new[] { "Member_id" });
            DropIndex("dbo.MonthlyEntries", new[] { "Member_id" });
            DropTable("dbo.MonthPays");
            DropTable("dbo.MonthlyEntries");
            DropTable("dbo.Members");
        }
    }
}
