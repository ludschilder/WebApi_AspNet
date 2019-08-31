using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Loja.Areas.Loja.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Loja/Produtos
        public ActionResult Index()
        {
            return View();
        }
    }
}