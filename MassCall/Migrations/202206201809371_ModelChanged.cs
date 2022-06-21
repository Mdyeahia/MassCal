namespace MassCall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonthlyEntries", "Member_id", "dbo.Members");
            DropForeignKey("dbo.MonthPays", "Member_id", "dbo.Members");
            DropIndex("dbo.MonthlyEntries", new[] { "Member_id" });
            DropIndex("dbo.MonthPays", new[] { "Member_id" });
            AddColumn("dbo.MonthlyEntries", "Member_id1", c => c.Int());
            AddColumn("dbo.MonthPays", "Member_id1", c => c.Int());
            AlterColumn("dbo.MonthlyEntries", "Member_id", c => c.Int(nullable: false));
            AlterColumn("dbo.MonthPays", "Member_id", c => c.Int(nullable: false));
            CreateIndex("dbo.MonthlyEntries", "Member_id1");
            CreateIndex("dbo.MonthPays", "Member_id1");
            AddForeignKey("dbo.MonthlyEntries", "Member_id1", "dbo.Members", "id");
            AddForeignKey("dbo.MonthPays", "Member_id1", "dbo.Members", "id");
            DropColumn("dbo.MonthlyEntries", "UserId");
            DropColumn("dbo.MonthPays", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonthPays", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.MonthlyEntries", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MonthPays", "Member_id1", "dbo.Members");
            DropForeignKey("dbo.MonthlyEntries", "Member_id1", "dbo.Members");
            DropIndex("dbo.MonthPays", new[] { "Member_id1" });
            DropIndex("dbo.MonthlyEntries", new[] { "Member_id1" });
            AlterColumn("dbo.MonthPays", "Member_id", c => c.Int());
            AlterColumn("dbo.MonthlyEntries", "Member_id", c => c.Int());
            DropColumn("dbo.MonthPays", "Member_id1");
            DropColumn("dbo.MonthlyEntries", "Member_id1");
            CreateIndex("dbo.MonthPays", "Member_id");
            CreateIndex("dbo.MonthlyEntries", "Member_id");
            AddForeignKey("dbo.MonthPays", "Member_id", "dbo.Members", "id");
            AddForeignKey("dbo.MonthlyEntries", "Member_id", "dbo.Members", "id");
        }
    }
}
