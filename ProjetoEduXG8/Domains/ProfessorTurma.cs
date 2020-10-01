using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Domains
{
    public class ProfessorTurma
    {
        [Key]
        public Guid IdProfessorTurma { get; set; }
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }

        public ProfessorTurma()
        {
            IdUsuario = Guid.NewGuid();
            IdTurma = Guid.NewGuid();
            IdProfessorTurma = Guid.NewGuid();

        }
    }
}