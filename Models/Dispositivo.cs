using Aplicacao.ValvulasAcionamentos;
using Aplicacao.Models.Temeperatura;
using System.Text.Json.Serialization;

namespace Aplicacao.Dispositivos
{
    public class Dispositivo
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; } = null!;
        public float Temperatura { get; set; }
        public float Bateria { get; set; } 
        public ICollection<ValvulasAcionamento> ValvulasAcionamentos { get; set; } = null!;
        public List<Temperatura> Temperaturas { get; set; } = null!;
    }
}