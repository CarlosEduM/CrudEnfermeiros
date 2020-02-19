using CrudEnfermeiros.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEnfermeiros.Data
{
    public class CrudEnfermeirosContext : DbContext
    {
        public CrudEnfermeirosContext(DbContextOptions<CrudEnfermeirosContext> options) : base(options)
        {
        }

        DbSet<Hospital> Hospitals { get; set; }
        DbSet<Enfermeiro> Enfermeiros { get; set; }
    }
}
