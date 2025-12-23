using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Entities;

namespace API_REST.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa?> GetByIdAsync(int id);
        Task AddAsync(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);

    }
}