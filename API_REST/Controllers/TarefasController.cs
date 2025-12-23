using System;
using System.Linq;
using System.Threading.Tasks;
using API_REST.DTOs.Tarefa;
using API_REST.Entities;
using API_REST.Enums;
using API_REST.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _service;

        public TarefasController(TarefaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tarefas = await _service.GetAllAsync();

            var response = tarefas.Select(t => new TarefaResponseDTO
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                Status = t.Status.ToString(),
                Prioridade = t.Prioridade.ToString(),
                DataCriacao = t.DataCriacao
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarefa = await _service.GetByIdAsync(id);

            if (tarefa == null)
                return NotFound();

            var response = new TarefaResponseDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status.ToString(),
                Prioridade = tarefa.Prioridade.ToString(),
                DataCriacao = tarefa.DataCriacao
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarefaCreateDTO dto)
        {
            var tarefa = new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Prioridade = dto.Prioridade,
                Status = StatusTarefa.Pendente,
                DataCriacao = DateTime.Now
            };

            var criada = await _service.CriarAsync(tarefa);

            return CreatedAtAction(nameof(GetById), new { id = criada.Id }, new TarefaResponseDTO
            {
                Id = criada.Id,
                Titulo = criada.Titulo,
                Descricao = criada.Descricao,
                Status = criada.Status.ToString(),
                Prioridade = criada.Prioridade.ToString(),
                DataCriacao = criada.DataCriacao
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarefaUpdateDTO dto)
        {
            var sucesso = await _service.AtualizarAsync(id, dto);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.ExcluirAsync(id);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
