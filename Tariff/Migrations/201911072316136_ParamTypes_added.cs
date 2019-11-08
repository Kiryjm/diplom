namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParamTypes_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Params", "Rate_Id", "dbo.Rates");
            DropIndex("dbo.Params", new[] { "Rate_Id" });
            RenameColumn(table: "dbo.Params", name: "Rate_Id", newName: "RateId");
            CreateTable(
                "dbo.ParamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParamDataType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Params", "ParamTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Params", "RateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Params", "RateId");
            AddForeignKey("dbo.Params", "RateId", "dbo.Rates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Params", "RateId", "dbo.Rates");
            DropIndex("dbo.Params", new[] { "RateId" });
            AlterColumn("dbo.Params", "RateId", c => c.Int());
            DropColumn("dbo.Params", "ParamTypeId");
            DropTable("dbo.ParamTypes");
            RenameColumn(table: "dbo.Params", name: "RateId", newName: "Rate_Id");
            CreateIndex("dbo.Params", "Rate_Id");
            AddForeignKey("dbo.Params", "Rate_Id", "dbo.Rates", "Id");
        }
    }
}
