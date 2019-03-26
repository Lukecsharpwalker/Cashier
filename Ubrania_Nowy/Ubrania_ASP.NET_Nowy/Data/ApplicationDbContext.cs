using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ubrania_ASP.NET_Nowy.Models;

namespace Ubrania_ASP.NET_Nowy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Cloth> Clothes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<Agreement>()
            //    .HasMany(a => a.Clothes)
            //    .WithOne(c => c.Agreement)
            //    .HasForeignKey(c => c.Agreement_Id);

        }

    }
}
