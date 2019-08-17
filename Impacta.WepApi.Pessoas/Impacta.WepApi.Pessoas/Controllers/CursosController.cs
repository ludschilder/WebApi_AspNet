using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Impacta.WepApi.Pessoas.Models;

namespace Impacta.WepApi.Pessoas.Controllers
{
	public class CursosController : ApiController
	{
		//como ainda não temos o BD, vamos simular uma lista
		// do tipo Static
		static List<Curso> listaDeCursos = new List<Curso>();

		//public CursosController()
		//{

		//}

		[HttpGet]
		public List<Curso> RetornarCursos()
		{
			return listaDeCursos;
		}

		// quando o início do nome do método possui Get, não é necessário declarar o comando [HttpGet]
		public Curso GetCurso(int Id)
		{
			//LINQ para percorrer a lista e encotrar o curso
			var consultaCurso = from c in listaDeCursos
								where c.Id.Equals(Id)
								select c;

			//Busca o curso dentro da lista de curso com LAMBDA Expression
			//Faz a Mesma coisa que a consulta LINQ
			//var res = cursos.Where(x => x.Id.Equals(Id)).FirstOrDefault();

			if (consultaCurso.Count() <= 0)
			{
				return null;
			}
			else
			{
				return consultaCurso.First();
			}
		}


		public void PostCurso(Curso curso)
		{
			if (curso != null)
			{
				listaDeCursos.Add(curso);
			}
		}

		public void PutCurso(int id, Curso curso)
		{
			if (curso != null && id >= 0)
			//if (curso != null && curso.Id >=0)
			{
				var result = listaDeCursos.Where(x => x.Id.Equals(id)).FirstOrDefault();

				//var result = listaDeCursos.Where(x => x.Id.Equals(curso.Id)).FirstOrDefault();

				result.Nome = curso.Nome;
				result.CargaHoraria = curso.CargaHoraria;

				int posicao = listaDeCursos.IndexOf(result);

				listaDeCursos.RemoveAt(posicao);
				listaDeCursos.Insert(posicao, curso);
			}
		}

		public List<Curso> DeleteCurso(int id)
		{
			if (id > 0)
			{
				listaDeCursos.RemoveAt(
					listaDeCursos.IndexOf(
									listaDeCursos.Where(x => x.Id.Equals(id)).FirstOrDefault()
								   )
							   );
			}

			return listaDeCursos;
		}
	}
}
