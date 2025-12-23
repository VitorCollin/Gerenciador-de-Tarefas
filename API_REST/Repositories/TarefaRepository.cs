using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Data;
using API_REST.Entities;
using API_REST.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
            => await _context.Tarefas.ToListAsync();

        public async Task<Tarefa?> GetByIdAsync(int id)
            => await _context.Tarefas.FindAsync(id);

        public async Task AddAsync(Tarefa tarefa)
            => await _context.Tarefas.AddAsync(tarefa);

        public void Update(Tarefa tarefa)
            => _context.Tarefas.Update(tarefa);

        public void Delete(Tarefa tarefa)
            => _context.Tarefas.Remove(tarefa);
    }
}