﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tariff.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DBConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Rate> Rates { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<RateType> RateTypes { get; set; }



        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Tariff.Models.ParamType> ParamTypes { get; set; }
    }
}