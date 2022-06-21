namespace MassCall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChangedd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonthlyEntries", "Member_id1", "dbo.Members");
            DropIndex("dbo.MonthlyEntries", new[] { "Member_id1" });
            RenameColumn(table: "dbo.MonthlyEntries", name: "Member_id1", newName: "Memberid");
            AlterColumn("dbo.MonthlyEntries", "Memberid", c => c.Int(nullable: false));
            CreateIndex("dbo.MonthlyEntries", "Memberid");
            AddForeignKey("dbo.MonthlyEntries", "Memberid", "dbo.Members", "id", cascadeDelete: true);
            DropColumn("dbo.MonthlyEntries", "Member_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonthlyEntries", "Member_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.MonthlyEntries", "Memberid", "dbo.Members");
            DropIndex("dbo.MonthlyEntries", new[] { "Memberid" });
            AlterColumn("dbo.MonthlyEntries", "Memberid", c => c.Int());
            RenameColumn(table: "dbo.MonthlyEntries", name: "Memberid", newName: "Member_id1");
            CreateIndex("dbo.MonthlyEntries", "Member_id1");
            AddForeignKey("dbo.MonthlyEntries", "Member_id1", "dbo.Members", "id");
        }
    }
}
