using CrudEnfermeiros.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEnfermeiros.Data
{
    public class CrudEnfermeirosContext : DbContext
    {
        public CrudEnfermeirosContext(DbContextOptions<CrudEnfermeirosContext> options) : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
    }
}
