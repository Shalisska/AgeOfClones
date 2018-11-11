using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.EF
{
    public class ClonesContextEF : DbContext
    {
        public ClonesContextEF(DbContextOptions<ClonesContextEF> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
