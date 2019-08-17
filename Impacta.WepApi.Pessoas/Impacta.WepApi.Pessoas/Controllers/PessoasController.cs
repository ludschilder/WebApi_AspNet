using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Impacta.WepApi.Pessoas.Models;

namespace Impacta.WepApi.Pessoas.Controllers
{
    public class PessoasController : ApiController
    {
		//como ainda não temos o BD, vamos simular uma lista
		// do tipo Static
		static List<Pessoa> pessoas = new List<Pessoa>();

		public PessoasController()
		{
			//**********
		}

		[HttpGet]
		public List<Pessoa> RetornarNome()
		{
			return pessoas;
		}

		public void Post(string nomeDaPessoa)
		{
			if (!string.IsNullOrEmpty(nomeDaPessoa))
			{
				pessoas.Add(new Pessoa { Nome = nomeDaPessoa });
			}
		}

		public void Post(Pessoa pessoa)
		{
			if (pessoa != null)
			{
				pessoas.Add(pessoa);
			}
		}
    }
}
