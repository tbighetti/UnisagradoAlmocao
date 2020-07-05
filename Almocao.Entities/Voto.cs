using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Almocao.Entities
{
    public class Voto
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        [Required]
        public DateTime Dia { get; set; }

        [Required]
        [ForeignKey("RestauranteId")]
        public Restaurante Restaurante { get; set; }

    }
}
