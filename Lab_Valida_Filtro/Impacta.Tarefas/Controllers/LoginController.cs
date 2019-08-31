using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Impacta.MOD;
using System.Web.Security;

namespace Impacta.Tarefas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Autenticacao()
        {
			Usuario usuario = null;

            return View(usuario);

			//já criar a view
        }

		[HttpPost]
		public ActionResult AutenticarLogin (Usuario usuario)
		{
			//segundo parâmetro é relativo ao COOKIE,
			//é para persistir o usuário, caso seja true,
			//ele sempre irá considerar que o usuário já está autenticado
			FormsAuthentication.SetAuthCookie(usuario.Username, false);
			
			return RedirectToAction("Index", "RealBooks");
		}

		public ActionResult Logout()
		{
			//Remove o FormsAuthentication do Browser;
			FormsAuthentication.SignOut();

			//retorna para a View de Login
			return View("Autenticacao");
		}
	}
}