using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using API_REST.Enums;

namespace API_REST.DTOs.Tarefa
{
    public class TarefaCreateDTO
    {

        [Required(ErrorMessage = "Título é obrigatório")]
        [MinLength(3)]
        public string Titulo { get; set; } = null!;

        public string? Descricao { get; set; }

        [Required]
        public PrioridadeTarefa Prioridade { get; set; }
    }
}