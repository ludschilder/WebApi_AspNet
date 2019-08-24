using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Impacta.MOD;

namespace Impacta.Tarefas.ClientAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			
			//executa o método assíncrono para a chamada da API
			RunAsync().Wait();

			//wait solicita que aguarde até que o processamento da API retorne valor
		}

		static async Task RunAsync()
		{
			//definido para oHEADER da chamada http qual tipo de CONTENT-Type
			//se realizará na comunicação: Text, XML, JSON e etc ...
			var formato = new MediaTypeWithQualityHeaderValue("application/json");

			using (var client = new HttpClient())
			{
				//pegar o localhost ao executar
				client.BaseAddress = new Uri("http://localhost:52001/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(formato);

				//o método GEtAsync() vai solicitar a execução da Sua API
				//e obter um valor de resposta, armazenando na variável Resposta
				var resposta = await client.GetAsync("api/WebApiEditora");

				//Nós precisamos definir qual tipo de retorno iremos obter
				//nesse caso podemos definir de duas maneiras
				//1) Definimos um objeto de retorno similar ao da assinatura da API
				//2) OU defini-se uma modelagem de uma classe igual a retornada pela API
				//var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<object>>();
				var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<Editora>>();

				//na segunda forma seria assim
				//var conteudo = await resposta.Content.ReadAsAsync<string>();
				
				//Console.WriteLine(conteudo);
				foreach (var item in conteudo)
				{
					Console.WriteLine(string.Format("EditoraId: {0}, Nome: {1}", item.EditoraId, item.Nome));
				}
			}

			Console.ReadLine();

		}
	}
}