namespace Tariff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_model_was_deleted : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Books");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
    }
}
