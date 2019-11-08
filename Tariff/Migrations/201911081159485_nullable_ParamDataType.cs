namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_ParamDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParamTypes", "ParamDataType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParamTypes", "ParamDataType", c => c.Int(nullable: false));
        }
    }
}
