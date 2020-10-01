using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Domains
{
    public class Curso
    {

        [Key]
        public Guid IdCurso { get; set; }
        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao Instituicao { get; set; }

        public string Titulo { get; set; }

        public Curso()
        {
            IdCurso = Guid.NewGuid();
            IdInstituicao = Guid.NewGuid();
        }

    }
}