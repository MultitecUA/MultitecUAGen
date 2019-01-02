using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class CategoriaProyectoController : BasicController
    {
        // GET: CategoriaProyecto
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            int tamPag = 10;

            int numPags = (categoriaProyectoCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<CategoriaProyectoEN> listaCategoriasProyectos = categoriaProyectoCEN.ReadAll(inicio, tamPag).ToList();

            return View(listaCategoriasProyectos);
        }

        // GET: CategoriaProyecto/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
            CategoriaProyectoEN categoriaProyectoEN = categoriaProyectoCEN.ReadOID(id);
            ViewData["nombre"] = categoriaProyectoEN.Nombre;
            return View(categoriaProyectoEN);
        }

        // GET: CategoriaProyecto/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            CategoriaProyectoEN categoriaProyectoEN = new CategoriaProyectoEN();
            return View(categoriaProyectoEN);
        }

        // POST: CategoriaProyecto/Create
        [HttpPost]
        public ActionResult Create(CategoriaProyectoEN categoriaProyectoEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z áéíóúñç]{1,30}$");
                if (!pattern.IsMatch(categoriaProyectoEN.Nombre))
                {
                    ViewData["nombreCP"] = "mal";
                    return View();
                }

                categoriaProyectoCEN.New_(categoriaProyectoEN.Nombre);
                TempData["CPcreada"] = categoriaProyectoEN.Nombre;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaProyecto/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
            CategoriaProyectoEN categoriaProyectoEN = categoriaProyectoCEN.ReadOID(id);
            ViewData["nombre"] = categoriaProyectoEN.Nombre;
            return View(categoriaProyectoEN);
        }

        // POST: CategoriaProyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaProyectoEN categoriaProyectoEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z áéíóúñç]{1,30}$");
                if (!pattern.IsMatch(categoriaProyectoEN.Nombre))
                {
                    ViewData["nombreCP"] = "mal";
                    return View();
                }

                categoriaProyectoCEN.Modify(id, categoriaProyectoEN.Nombre);
                TempData["CPeditada"] = categoriaProyectoEN.Nombre;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaProyecto/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
            CategoriaProyectoEN categoriaProyectoEN = categoriaProyectoCEN.ReadOID(id);
            ViewData["nombre"] = categoriaProyectoEN.Nombre;
            return View(categoriaProyectoEN);
        }

        // POST: CategoriaProyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaProyectoEN categoriaProyectoEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                CategoriaProyectoCP categoriaProyectoCP = new CategoriaProyectoCP();
                categoriaProyectoCP.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
