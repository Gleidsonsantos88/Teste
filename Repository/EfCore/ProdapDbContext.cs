using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository.EfCore
{
    public class ProdapDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProdapDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
               .HasOne(p => p.Usuario)
               .WithMany(x => x.Tarefas)
               .HasForeignKey(p => p.UsuarioId);
        }
    }
}
