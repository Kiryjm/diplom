namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParamType_object_in_Param_added : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Params", "ParamTypeId");
            AddForeignKey("dbo.Params", "ParamTypeId", "dbo.ParamTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Params", "ParamTypeId", "dbo.ParamTypes");
            DropIndex("dbo.Params", new[] { "ParamTypeId" });
        }
    }
}
