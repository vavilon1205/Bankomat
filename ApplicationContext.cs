using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Rub> Rub => Set<Rub>();
        public DbSet<Usd> Usd => Set<Usd>();
        public DbSet<Eur> Eur => Set<Eur>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bankomat.db");
        }
    }
}
