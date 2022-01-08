using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonASP.Models;

namespace SalonASP.Data
{
    public class SalonASPContext : DbContext
    {
        public SalonASPContext (DbContextOptions<SalonASPContext> options)
            : base(options)
        {
        }

        public DbSet<SalonASP.Models.Programari> Programari { get; set; }

        public DbSet<SalonASP.Models.Clienti> Clienti { get; set; }

        public DbSet<SalonASP.Models.Angajati> Angajati { get; set; }

        public DbSet<SalonASP.Models.Servicii> Servicii { get; set; }
    }
}
