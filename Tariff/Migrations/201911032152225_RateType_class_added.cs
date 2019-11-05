namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RateType_class_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rates", "RateType_Id", c => c.Int());
            CreateIndex("dbo.Rates", "RateType_Id");
            AddForeignKey("dbo.Rates", "RateType_Id", "dbo.RateTypes", "Id");
            DropColumn("dbo.Rates", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rates", "Type", c => c.String());
            DropForeignKey("dbo.Rates", "RateType_Id", "dbo.RateTypes");
            DropIndex("dbo.Rates", new[] { "RateType_Id" });
            DropColumn("dbo.Rates", "RateType_Id");
            DropTable("dbo.RateTypes");
        }
    }
}
