using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ubrania_Nowy
{

    public class ERPDbContext : DbContext
    {
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Cloth> Clothes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agreement>()
                
                .HasMany(a => a.Clothes)
                .WithRequired(c => c.Agreement)
                .HasForeignKey(c => c.Agreement_Id);              
                
        }
    }

    
}
