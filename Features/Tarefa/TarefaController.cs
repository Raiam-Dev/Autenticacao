using Microsoft.AspNetCore.Mvc;
using MediatR;
using Aplicacao.Entidades;
using Aplicacao.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Aplicacao.PadraoResposta;

namespace Aplicacao.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TarefaController(IMediator mediatR)
        {
            _mediator = mediatR;
        }

        [HttpGet("buscar-pendencias")]
        [SwaggerOperation(
            Summary = "Busca todas as tarefas pendentes",
            Description = "Retorna uma lista de pendencias"
        )]
        public async Task<IActionResult> BuscarPendencia(
            [FromServices] DbContextMemory _dbContext)
        {
            return Ok(ApiResponse.Success(
                await _dbContext.Tarefas.Where(
                    t => t.Status == Status.Pendente)
                    .ToListAsync()
            ));
        }
        [HttpGet("buscar-prioritarias")]
        public async Task<IActionResult> BuscarPrioritarias(
            [FromServices] DbContextMemory _dbContext)
        {
            return Ok(ApiResponse.Success(
                await _dbContext.Tarefas.Where(
                    t => t.Prioridade == Prioridade.Alta)
                    .ToListAsync()
            ));
        }
        [HttpGet]
        public async Task<IActionResult> ListarTarefas(
            [FromServices] DbContextMemory _dbContext)
        {
            return Ok(ApiResponse.Success(
                await _dbContext.Tarefas.ToListAsync()
            ));
        }

        [HttpPost]
        public async Task<IActionResult> CreatedTarefa(AdicionarTarefa tarefa)
        {
            if (!ModelState.IsValid) return BadRequest(ApiResponse.Fail(tarefa, "Dados invalidos"));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTarefa(AtualizarTarefa tarefa)
        {
            if (!ModelState.IsValid) return BadRequest(ApiResponse.Fail(tarefa, "Dados invalidos"));

            var resposta = await _mediator.Send(tarefa);
            if (!resposta) return NotFound(ApiResponse.Fail(tarefa, "Tarefa não existe"));

            return Ok(ApiResponse.Success(tarefa));
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirTarefa(
            [FromServices] DbContextMemory _dbContext,
            Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ApiResponse.Fail(null,"Dados invalidos"));
            var tarefa = await _dbContext.Tarefas.FindAsync(id);
            _dbContext.Tarefas.Remove(tarefa!);
            await _dbContext.SaveChangesAsync();
            return Ok(ApiResponse.Success(null));
        }
    }
}