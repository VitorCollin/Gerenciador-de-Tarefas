using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.DTOs.Tarefa
{
    public class TarefaResponseDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descricao { get; set; }
        public string Status { get; set; } = null!;
        public string Prioridade { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
    }
}