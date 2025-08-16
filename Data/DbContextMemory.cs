using Microsoft.EntityFrameworkCore;
using Aplicacao.Entidades;

namespace Aplicacao.Data
{
    public class DbContextMemory : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        public DbContextMemory(DbContextOptions<DbContextMemory> config) : base(config) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Prioridade)
                .HasConversion<string>();
        }
    }
}