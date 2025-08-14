using System.Text.Json.Serialization;
using Aplicacao.Dispositivos;

namespace Aplicacao.Models.Temeperatura
{
    public class Temperatura
    {
        public Guid Id {get;set;}
        public float TemperaturaValor { get; set; }
        public Guid DispositivoId { get; set; } 
    }
}
