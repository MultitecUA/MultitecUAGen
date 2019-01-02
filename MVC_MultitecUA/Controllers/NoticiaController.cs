using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class NoticiaController : BasicController
    {
        // GET: Noticia
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            NoticiaCEN noticiaCEN = new NoticiaCEN();

            int tamPag = 10;

            int numPags = (noticiaCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<NoticiaEN> listaNoticias = noticiaCEN.ReadAll(inicio, tamPag).ToList();

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            return View(listaNoticias);
        }


        // GET: Noticia/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            ViewData["titulo"] = noticiaEN.Titulo;
            
            return View(noticiaEN);
        }

        // GET: Noticia/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");


            NoticiaEN noticiaEN = new NoticiaEN();
            return View(noticiaEN);
        }

        // POST: Noticia/Create
        [HttpPost]
        public ActionResult Create(NoticiaEN noticiaEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                //VALIDANDO TITULO
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{5,50}$");
                if (!pattern.IsMatch(noticiaEN.Titulo))
                {
                    ViewData["formatotitulonoticia"] = "mal";
                    return View();
                }

                //VALIDANDO CUERPO
                pattern = new Regex("^.{10,4000}$");
                if (!pattern.IsMatch(noticiaEN.Cuerpo))
                {
                    ViewData["formatocuerponoticia"] = "mal";
                    return View();
                }

                int OID = noticiaCEN.New_(noticiaEN.Titulo, noticiaEN.Cuerpo, noticiaEN.Foto);

                TempData["noticiacreada"] = "si";

                return RedirectToAction("Details/" + OID);
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            ViewData["titulo"] = noticiaEN.Titulo;

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            return View(noticiaEN);
        }

        // POST: Noticia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NoticiaEN noticiaEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                //VALIDANDO TITULO
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{5,50}$");
                if (!pattern.IsMatch(noticiaEN.Titulo))
                {
                    ViewData["formatotitulonoticia"] = "mal";
                    return View();
                }

                //VALIDANDO CUERPO
                pattern = new Regex("^.{10,4000}$");
                if (!pattern.IsMatch(noticiaEN.Cuerpo))
                {
                    ViewData["formatocuerponoticia"] = "mal";
                    return View();
                }

                noticiaCEN.Modify(id, noticiaEN.Titulo, noticiaEN.Cuerpo, noticiaEN.Foto);
                TempData["noticiaeditada"] = "si";

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            ViewData["titulo"] = noticiaEN.Titulo;
            return View(noticiaEN);
        }

        // POST: Noticia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NoticiaEN noticiaEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();
                noticiaCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
