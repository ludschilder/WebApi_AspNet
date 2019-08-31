using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Impacta.MOD
{
	public class Usuario
	{
		[Required(ErrorMessage ="Nome do usuário é obrigatório")]
		[Display(Name = "USUARIO")]
		[StringLength(10,MinimumLength = 5, ErrorMessage =("Usuário deve conter entre 5 e 8 caracteres"))]
		public string Username { get; set; }

		[Display(Name ="SENHA")]
		[Required(ErrorMessage = "Senha é obrigatória")]
		public string Password { get; set; }
	}
}


