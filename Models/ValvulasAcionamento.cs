using System.Text.Json.Serialization;
using Aplicacao.Dispositivos;

namespace Aplicacao.ValvulasAcionamentos
{
    public class ValvulasAcionamento
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Porta { get; set; } = null!;
        public Guid DispositivoId { get; set; } 
    }
}