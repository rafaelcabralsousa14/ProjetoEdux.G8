using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Domains
{
	public class ObjetivoAluno
	{
		[Key]
		public Guid IdObjetivoAluno { get; set; }
		public float Nota { get; set; }
		public DateTime DataEntrega { get; set; }

		public Guid IdObjetivo { get; set; }
		[ForeignKey("IdObjetivo")]
		public Objetivo Objetivo { get; set; }

		public Guid IdAlunoTurma { get; set; }
		[ForeignKey("IdAlunoTurma")]
		public AlunoTurma AlunoTurma { get; set; }

		public ObjetivoAluno()
		{
			IdObjetivoAluno = Guid.NewGuid();
			IdObjetivo = Guid.NewGuid();
			IdAlunoTurma = Guid.NewGuid();
		}

	}
}