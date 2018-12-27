using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class CategoriaProyectoController : BasicController
    {
        // GET: CategoriaProyecto
        public ActionResult Index(int? pag)
        {
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
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
            CategoriaProyectoEN categoriaProyectoEN = categoriaProyectoCEN.ReadOID(id);
            return View(categoriaProyectoEN);
        }

        // GET: CategoriaProyecto/Create
        public ActionResult Create()
        {
            CategoriaProyectoEN categoriaProyectoEN = new CategoriaProyectoEN();
            return View(categoriaProyectoEN);
        }

        // POST: CategoriaProyecto/Create
        [HttpPost]
        public ActionResult Create(CategoriaProyectoEN categoriaProyectoEN)
        {
            try
            {
                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
                categoriaProyectoCEN.New_(categoriaProyectoEN.Nombre);
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
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
            CategoriaProyectoEN categoriaProyectoEN = categoriaProyectoCEN.ReadOID(id);
            return View(categoriaProyectoEN);
        }

        // POST: CategoriaProyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaProyectoEN categoriaProyectoEN)
        {
            try
            {
                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
                categoriaProyectoCEN.Modify(id, categoriaProyectoEN.Nombre);
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
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();
            CategoriaProyectoEN categoriaProyectoEN = categoriaProyectoCEN.ReadOID(id);
            return View(categoriaProyectoEN);
        }

        // POST: CategoriaProyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaProyectoEN categoriaProyectoEN)
        {
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
