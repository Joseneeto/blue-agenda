using AgendaBlue.Data.Map;
using AgendaBlue.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaBlue.Data
{
    public class AgendaDBContex : DbContext
    {
        public AgendaDBContex(DbContextOptions<AgendaDBContex> options) : base(options) { }

        public DbSet<ContatoModel> Contato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
