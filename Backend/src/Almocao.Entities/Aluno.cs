using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Almocao.Entities
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

    }
}