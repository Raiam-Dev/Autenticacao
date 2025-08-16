using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Entidades
{
    public class AtualizarTarefa : IRequest<bool>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(100)]
        public string Descricao { get; set; } 

        public DateTime DataCriacao { get; set; }
        public DateTime Vencimento { get; set; }
        public Status Status { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}