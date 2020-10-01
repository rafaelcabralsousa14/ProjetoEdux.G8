using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoEduXG8.Domains
{
	public class Dica
	{
		[Key]
		public Guid IdDica { get; set; }
		public string Texto { get; set; }
		[NotMapped]
		[JsonIgnore]
		public IFormFile Imagem { get; set; }
		public string UrlImagem { get; set; }

		public Guid IdUsuario { get; set; }
		[ForeignKey("IdUsuario")]
		public Usuario Usuario { get; set; }

		public Dica()
		{
			IdDica = Guid.NewGuid();
			IdUsuario = Guid.NewGuid();
		}
	}
}