using System.Data.Entity.Migrations;

namespace Tariff.Migrations
{
    public partial class MergeDbContext : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
