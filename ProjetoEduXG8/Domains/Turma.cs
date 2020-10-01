using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Domains
{
    public class Turma
    {
        [Key]
        public Guid IdTurma { get; set; }
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public Turma()
        {
            IdUsuario = Guid.NewGuid();
            IdTurma = Guid.NewGuid();
        }
    }
}