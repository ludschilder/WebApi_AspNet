using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Impacta.MOD;
using Impacta.Tarefas.Business;

namespace Impacta.Tarefas.Controllers
{
    public class RealBooksController : Controller
    {
		//teste

		// GET: RealBooks
		public ActionResult Index()
		{

			////criar um objeot do tipo business
			//EditoraBUS editoraBUS = new EditoraBUS();

			//var listaEditora = editoraBUS.ListarEditoras();

			////retornamos a lista para a View que estará tipada para
			////receber uma lista de Editoras
			//return View(listaEditora);

			return View();
		}

		public ActionResult ListarNovasEditoras()
		{

			try
			{
				EditoraBUS objEditora = new EditoraBUS();

				var lst = objEditora.ListarEditoras();

				return View(lst);

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}


		// GET: RealBooks/Create
		public ActionResult Create()
		{

			return View();
		}



		// POST: RealBooks/Create
		[HttpPost]
		public ActionResult Create(Editora collection)
		{
			try
			{
				//Invocando na camada de negócio
				//o método para salvar os dados da Editora
				EditoraBUS editoraBUS = new EditoraBUS();

				//Enviamos para a camada de negócio os dados da Editora
				editoraBUS.Salvar(collection);

				return RedirectToAction("Index");
			}
			catch
			{
				//ViewBag.
				return View();
			}
		}


		// GET: RealBooks/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError("Editora", "Editora inválida.");
				}

				EditoraBUS objEditora = new EditoraBUS();

				var lst = objEditora.BuscarEditora(id);

				return View(lst);
			}
			catch
			{
				return View();
			}
		}

		// POST: RealBooks/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Editora editora)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError("Editora", "Editora inválida.");
				}

				EditoraBUS editoraBUS = new EditoraBUS();

				editoraBUS.Salvar(editora);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}



		//// GET: RealBooks/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: RealBooks/Edit/5
		//[HttpPost]
		//public ActionResult Edit(int id, FormCollection collection)
		//{
		//	try
		//	{
		//		// TODO: Add update logic here

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}


		// GET: RealBooks/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				EditoraBUS editoraBUS = new EditoraBUS();

				editoraBUS.Excluir(id);
			}
			catch (Exception)
			{

				throw;
			}
			return View();
		}

		// POST: RealBooks/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
