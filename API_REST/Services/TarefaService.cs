using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Data;
using API_REST.DTOs.Tarefa;
using API_REST.Entities;
using API_REST.Enums;
using API_REST.Repositories.Interfaces;

namespace API_REST.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly AppDbContext _context;

        public TarefaService(
            ITarefaRepository repository,
            AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }



        public async Task<Tarefa> CriarAsync(Tarefa tarefa)
        {
            if (string.IsNullOrWhiteSpace(tarefa.Titulo))

                throw new Exception("Título é obrigatorio");


            tarefa.Status = StatusTarefa.Pendente;
            tarefa.DataCriacao = DateTime.Now;

            await _repository.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }
        public async Task<bool> AtualizarAsync(int id, TarefaUpdateDTO dto)
        {
            var tarefa = await _repository.GetByIdAsync(id);
            if (tarefa == null) return false;

            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.Prioridade = dto.Prioridade;
            tarefa.Status = dto.Status;

            _repository.Update(tarefa);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var tarefa = await _repository.GetByIdAsync(id);
            if (tarefa == null)
                return false;

            _repository.Delete(tarefa);
            await _context.SaveChangesAsync();

            return true;
        }

        internal async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

    }
}