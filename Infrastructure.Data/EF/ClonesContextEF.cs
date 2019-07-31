using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.EF
{
    public class ClonesContextEF : DbContext
    {
        public ClonesContextEF(DbContextOptions<ClonesContextEF> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ProfileEF> Profiles { get; set; }
        public DbSet<AccountEF> Accounts { get; set; }
        public DbSet<StockEF> Stocks { get; set; }
        public DbSet<ResourceEF> Resources { get; set; }
        public DbSet<CurrencyEF> Currencies { get; set; }
        public DbSet<CurrencyExchangeRateEF> CurrencyExchanges { get; set; }
        public DbSet<CloneEF> Clones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyExchangeRateEF>().HasKey(u => new { u.CurrencyId, u.CurrencyPairId });

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal)))
                        {
                            property.Relational().ColumnType = "decimal(18, 4)";
                        }
        }
    }
}
