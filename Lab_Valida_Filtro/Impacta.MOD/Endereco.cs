using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.MOD
{
	public class Endereco
	{
		public int Id { get; set; }
		public string Logradouro { get; set; }
		public int Numero { get; set; }
		public string Complemento { get; set; }

		[Required(ErrorMessage ="oBRIGATORIO")]
		public string Cep { get; set; }
		public string Municipio { get; set; }
		public string Uf { get; set; }
	}
}
