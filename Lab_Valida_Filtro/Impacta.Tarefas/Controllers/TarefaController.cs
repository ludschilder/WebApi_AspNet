using Impacta.MOD;
using Impacta.Tarefas.DAL;
using Impacta.Tarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Tarefas.Controllers
{
	public class TarefaController : Controller
	{

		// GET: Tarefa
		public ActionResult Index()
		{
			return View();
		}

		// GET: Tarefa
		public ActionResult NovaTarefa()
		{
			return View();
		}

		//Post: Tarefa
		[HttpPost]
		public ActionResult NovaTarefa(TarefaViewModel tarefaView)
		{
			if (ModelState.IsValid)
			{
				//Classe responsável pela comunicação com Banco de Dados
				Data objData = new Data();

				//Nossa Modelo de Dados a ser enviado ao BD TArefa
				TarefaMOD tarefaMOD = new TarefaMOD();


				//carregamos os valores
				tarefaMOD.Nome = tarefaView.Nome;
				tarefaMOD.Prioridade = tarefaView.Prioridade;
				tarefaMOD.Concluida = tarefaView.Concluida;
				tarefaMOD.Observacao = tarefaView.Observacao;

				var resultado = objData.CriarTarefa(tarefaMOD);

				//retonro para o início
				//return View("Index");

				return RedirectToAction("ListarNovasTarefas");
			}

			else
			{
				//aqui dentro da ActionResult, no HomeController.cs
				ViewBag.Alerta = "Por favor verificar os dados do formulario";

			}

			return View();
		}



		public ActionResult ListarNovasTarefas()
		{
			List<TarefaMOD> tarefas = null;

			try
			{
				Data data = new Data();

				tarefas = data.ListarTarefas();
			}
			catch (Exception ex)
			{
				ViewBag.Alerta = "Ops! Verifique: " + ex.Message;
			}


			return View(tarefas);
		}


		// GET: Tarefa/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Tarefa/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Tarefa/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Tarefa/Edit/5
		public ActionResult Edit(int id)
		{
			Data data = new Data();

			var tarefa = data.ConsultarTarefa(id);

			if (tarefa == null)
			{
				ViewBag.Alerta = "Não foi encontrado o registro desejado";

				return View("ListarNovasTarefas");
			}
		

			//retornamos o objeto para a view que será tipada
			return View(tarefa);
		}

		// POST: Tarefa/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, TarefaMOD collection)
		{
			try
			{
				Data data = new Data();



				var res = data.AtualizarTarefa(id, collection);

				if(res)
				{
					ViewBag.Alerta = string.Format("Registro {0}, atualizado com sucesso.", collection.Nome);
				}

				return RedirectToAction("ListarNovasTarefas");
			}
			catch
			{
				return View();
			}
		}

		// GET: Tarefa/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Tarefa/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				Data data = new Data();

				data.ExcluirTarefa(id);

				return RedirectToAction("ListarNovasTarefas");
			}
			catch
			{
				return View();
			}
		}
	}
}
