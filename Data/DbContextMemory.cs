using Aplicacao.Dispositivos;
using Aplicacao.Models.Temeperatura;
using Aplicacao.ValvulasAcionamentos;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Data
{
    public class  DbContextMemory : DbContext
    {
        public DbContextMemory (DbContextOptions<DbContextMemory> config) : base(config) {}
        public DbSet<Dispositivo> Dispositivos { get; set; } = null!;
        public DbSet<ValvulasAcionamento> ValvulasAcionamentos { get; set; } = null!;
        public DbSet<Temperatura> Temperaturas { get; set; } = null!;
    }
}