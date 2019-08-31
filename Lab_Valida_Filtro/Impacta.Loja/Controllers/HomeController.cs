using Impacta.Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Loja.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult QuemSomos()
		{
			return View();
		}
		public ActionResult Contato()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Contato(ContatoViewModel contato)
		{
			if (string.IsNullOrEmpty(contato.Nome))
			{
				ModelState.AddModelError("", "O nome deve ser preechido");
			}
			if (ModelState.IsValid)
			{
				RotinasWeb.ContatoGravar(contato);
				return View("ContatoGravarOK");
			}
			else
			{
				return View(contato);
			}
		}


	}
}