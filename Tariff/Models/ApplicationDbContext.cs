using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tariff.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DBConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Param> Params { get; set; }



        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}