using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.MOD
{

    public class TarefaMOD
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Prioridade { get; set; }
		public bool Concluida { get; set; }
		public string Observacao { get; set; }
	}
}
