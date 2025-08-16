using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Entidades
{
    public class Tarefa
    {
        [Key]
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

    public enum Status
    {
        Pendente,
        EmProgresso,
        Concluido
    }
    public enum Prioridade
    {
        Baixa,
        Media,
        Alta
    }
}