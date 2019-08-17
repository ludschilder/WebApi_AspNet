using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.MOD
{
	public class Editora
	{
		[Display(Name = "Código da editora")]
		public int EditoraId { get; set; }

		[Display(Name = "Razão Social")]
		[Required(ErrorMessage = "Razão social deve ser informada")]
		public string Nome { get; set; }

		[EmailAddress] //se o formato não for de email emitiria uma message
		[Required(ErrorMessage = "E-mail de contato não está sendo informado")]
		public string Email { get; set; }

		[Required]
		public string Cnpj { get; set; }

		[Phone]
		public string Telefone { get; set; }

		public Endereco Endereco { get; set; }




	}
}
