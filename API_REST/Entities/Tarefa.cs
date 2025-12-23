using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API_REST.Enums;

namespace API_REST.Entities
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Titulo { get; set; } = null!;

        [MaxLength(500)]
        public string? Descricao { get; set; }

        [Required]
        public StatusTarefa Status { get; set; }

        [Required]
        public PrioridadeTarefa Prioridade { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }
    }
}