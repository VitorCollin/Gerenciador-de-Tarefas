using API_REST.Enums;
using System.ComponentModel.DataAnnotations;

namespace API_REST.DTOs.Tarefa
{
    public class TarefaUpdateDTO
    {
        [Required]
        [MinLength(3)]
        public string Titulo { get; set; } = null!;

        public string? Descricao { get; set; }

        [Required]
        public PrioridadeTarefa Prioridade { get; set; }

        [Required]
        public StatusTarefa Status { get; set; }
    }
}
