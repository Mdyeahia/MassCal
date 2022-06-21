namespace MassCall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChangeddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonthPays", "Member_id1", "dbo.Members");
            DropIndex("dbo.MonthPays", new[] { "Member_id1" });
            RenameColumn(table: "dbo.MonthPays", name: "Member_id1", newName: "Memberid");
            AlterColumn("dbo.MonthPays", "Memberid", c => c.Int(nullable: false));
            CreateIndex("dbo.MonthPays", "Memberid");
            AddForeignKey("dbo.MonthPays", "Memberid", "dbo.Members", "id", cascadeDelete: true);
            DropColumn("dbo.MonthPays", "Member_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonthPays", "Member_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.MonthPays", "Memberid", "dbo.Members");
            DropIndex("dbo.MonthPays", new[] { "Memberid" });
            AlterColumn("dbo.MonthPays", "Memberid", c => c.Int());
            RenameColumn(table: "dbo.MonthPays", name: "Memberid", newName: "Member_id1");
            CreateIndex("dbo.MonthPays", "Member_id1");
            AddForeignKey("dbo.MonthPays", "Member_id1", "dbo.Members", "id");
        }
    }
}
