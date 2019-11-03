using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tariff.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Book> Books { get; set; }
        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}