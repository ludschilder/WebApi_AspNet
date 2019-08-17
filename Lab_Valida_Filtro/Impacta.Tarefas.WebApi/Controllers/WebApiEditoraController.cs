using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Impacta.Tarefas.Business;
using Impacta.MOD;

namespace Impacta.Tarefas.WebApi.Controllers
{
    public class WebApiEditoraController : ApiController
    {
		EditoraBUS editora;

		// GET: api/WebApiEditora
		public IEnumerable<Editora> Get()
        {
			editora = new EditoraBUS();

			// retorna uma lista de editoras
			var lista = editora.ListarEditoras();

			return lista;
		}

        // GET: api/WebApiEditora/5
        public Editora Get(int id)
        {
			editora = new EditoraBUS();
			var result = editora.BuscarEditora(id);
            return result;
        }

        // POST: api/WebApiEditora
        public void Post(Editora objEditora)
        {
			editora = new EditoraBUS();

			//vamos chamar o método para salvar no banco de dados
			editora.Salvar(objEditora);
        }

        // PUT: api/WebApiEditora/5
        public void Put(int id, Editora objEditora)
        {
			editora = new EditoraBUS();

			editora.Salvar(objEditora);
        }

        // DELETE: api/WebApiEditora/5
        public void Delete(int id)
        {
			editora = new EditoraBUS();

			//Remove pelo ID
			editora.Excluir(id);
        }
    }
}
