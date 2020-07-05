using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almocao.Entities
{
    public class Restaurante
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Nome { get; set; }

        public string Endereco { get; set; }
    }
}
