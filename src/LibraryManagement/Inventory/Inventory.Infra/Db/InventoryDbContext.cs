using Inventory.Infra.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infra.Db
{
    public class InventoryDbContext : DbContext
    {

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookModel>()
              .HasKey(p => new { p.Id });
        }

        public DbSet<BookModel> Books { get; set; }
    }
}
