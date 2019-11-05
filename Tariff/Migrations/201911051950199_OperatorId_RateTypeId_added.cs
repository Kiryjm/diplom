namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OperatorId_RateTypeId_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rates", "Operator_Id", "dbo.Operators");
            DropForeignKey("dbo.Rates", "RateType_Id", "dbo.RateTypes");
            DropIndex("dbo.Rates", new[] { "Operator_Id" });
            DropIndex("dbo.Rates", new[] { "RateType_Id" });
            RenameColumn(table: "dbo.Rates", name: "Operator_Id", newName: "OperatorId");
            RenameColumn(table: "dbo.Rates", name: "RateType_Id", newName: "RateTypeId");
            AlterColumn("dbo.Rates", "OperatorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rates", "RateTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rates", "OperatorId");
            CreateIndex("dbo.Rates", "RateTypeId");
            AddForeignKey("dbo.Rates", "OperatorId", "dbo.Operators", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rates", "RateTypeId", "dbo.RateTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "RateTypeId", "dbo.RateTypes");
            DropForeignKey("dbo.Rates", "OperatorId", "dbo.Operators");
            DropIndex("dbo.Rates", new[] { "RateTypeId" });
            DropIndex("dbo.Rates", new[] { "OperatorId" });
            AlterColumn("dbo.Rates", "RateTypeId", c => c.Int());
            AlterColumn("dbo.Rates", "OperatorId", c => c.Int());
            RenameColumn(table: "dbo.Rates", name: "RateTypeId", newName: "RateType_Id");
            RenameColumn(table: "dbo.Rates", name: "OperatorId", newName: "Operator_Id");
            CreateIndex("dbo.Rates", "RateType_Id");
            CreateIndex("dbo.Rates", "Operator_Id");
            AddForeignKey("dbo.Rates", "RateType_Id", "dbo.RateTypes", "Id");
            AddForeignKey("dbo.Rates", "Operator_Id", "dbo.Operators", "Id");
        }
    }
}
