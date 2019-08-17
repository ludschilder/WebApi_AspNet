using Impacta.MOD;
using Impacta.Tarefas.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.Business
{
	public class EditoraBUS
	{
		public List<Editora> ListarEditoras ()
		{
			//instacioamos o objeto que se comunica com o Banco de Dados
			EditoraEF editoraEF = new EditoraEF();

			//executa o método listar Editoras (Faz Select)
			//var ed = editoraEF.ListarEditoras();
			List<Editora> ed;

			try
			{
				ed = editoraEF.ListarEditoras();
			}
			catch (Exception ex)
			{

				throw new Exception("Falha ao tentar validar a busca das Editoras. Erro: \n"
					+ ex.Message);
			}

			return ed;
		}

		public void Salvar(Editora editora)
		{
			try
			{
				if(string.IsNullOrEmpty(editora.Nome))
				{
					throw new Exception("Nome inválido");
				}

				if(string.IsNullOrEmpty(editora.Email))
				{
					throw new Exception("E-mail inválido");
				}

				EditoraEF editoraEF = new EditoraEF();

				editoraEF.Salvar(editora);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		public Editora BuscarEditora(int id)
		{

			EditoraEF editoraEF = new EditoraEF();

			Editora ed;

			try
			{
				ed = editoraEF.BuscarEditora(id);
			}
			catch (Exception ex)
			{

				throw new Exception("Falha ao tentar validar a busca das Editoras. Erro : \n" + ex.Message);
			}

			return ed;
		}

		public void Excluir(int id)
		{
			EditoraEF edEF = new EditoraEF();

			edEF.Excluir(id);
		}
	}
}
