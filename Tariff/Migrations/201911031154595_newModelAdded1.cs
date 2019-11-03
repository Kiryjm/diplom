namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModelAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Params",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Tariff_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tariffs", t => t.Tariff_Id)
                .Index(t => t.Tariff_Id);
            
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Operator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operators", t => t.Operator_Id)
                .Index(t => t.Operator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Params", "Tariff_Id", "dbo.Tariffs");
            DropForeignKey("dbo.Tariffs", "Operator_Id", "dbo.Operators");
            DropIndex("dbo.Tariffs", new[] { "Operator_Id" });
            DropIndex("dbo.Params", new[] { "Tariff_Id" });
            DropTable("dbo.Tariffs");
            DropTable("dbo.Params");
            DropTable("dbo.Operators");
        }
    }
}
