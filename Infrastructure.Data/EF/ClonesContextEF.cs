using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EF
{
    public class ClonesContextEF : DbContext
    {
        public ClonesContextEF(DbContextOptions<ClonesContextEF> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyExchangeRate> CurrencyExchanges { get; set; }
        public DbSet<Clone> Clones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyExchangeRate>().HasKey(u => new { u.CurrencyId, u.CurrencyPairId });
        }
    }
}
