namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNameToRate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tariffs", newName: "Rates");
            RenameColumn(table: "dbo.Params", name: "Tariff_Id", newName: "Rate_Id");
            RenameIndex(table: "dbo.Params", name: "IX_Tariff_Id", newName: "IX_Rate_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Params", name: "IX_Rate_Id", newName: "IX_Tariff_Id");
            RenameColumn(table: "dbo.Params", name: "Rate_Id", newName: "Tariff_Id");
            RenameTable(name: "dbo.Rates", newName: "Tariffs");
        }
    }
}
