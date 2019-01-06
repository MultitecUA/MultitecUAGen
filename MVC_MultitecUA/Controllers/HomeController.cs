using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["usuario"] != null && Session["modoAdmin"].ToString() == "true")
                return View("Index_Administrador");

            int numeroNoticias = 3;

            ViewData["numeroNoticias"] = numeroNoticias;

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            IList<NoticiaEN> listaNoticias = noticiaCEN.DameNUltimasNoticias(numeroNoticias);

            return View(listaNoticias);
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            if (Session["usuario"] != null && Session["modoAdmin"].ToString() == "true")
                return View("Index_Administrador");

            int numeroNoticias = int.Parse(f["numeroNoticias"]);

            ViewData["numeroNoticias"] = numeroNoticias;

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            IList<NoticiaEN> listaNoticias = noticiaCEN.DameNUltimasNoticias(numeroNoticias);

            return View(listaNoticias);
        }

        public ActionResult Index_Administrador()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}