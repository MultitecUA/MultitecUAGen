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
    public class CategoriaUsuarioController : BasicController
    {
        // GET: CategoriaUsuario
        public ActionResult Index(int? pag)
        {
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            int tamPag = 10;

            int numPags = (categoriaUsuarioCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<CategoriaUsuarioEN> listaCategoriasUsuarios = categoriaUsuarioCEN.ReadAll(inicio, tamPag).ToList();

            return View(listaCategoriasUsuarios);
        }

        // GET: CategoriaUsuario/Details/5
        public ActionResult Details(int id)
        {
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
            CategoriaUsuarioEN categoriaUsuarioEN = categoriaUsuarioCEN.ReadOID(id);
            ViewData["nombre"] = categoriaUsuarioEN.Nombre;
            return View(categoriaUsuarioEN);
        }

        // GET: CategoriaUsuario/Create
        public ActionResult Create()
        {
            CategoriaUsuarioEN categoriaUsuarioEN = new CategoriaUsuarioEN();
            return View(categoriaUsuarioEN);
        }

        // POST: CategoriaUsuario/Create
        [HttpPost]
        public ActionResult Create(CategoriaUsuarioEN categoriaUsuarioEN)
        {
            try
            {
                CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
                categoriaUsuarioCEN.New_(categoriaUsuarioEN.Nombre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
            CategoriaUsuarioEN categoriaUsuarioEN = categoriaUsuarioCEN.ReadOID(id);
            ViewData["nombre"] = categoriaUsuarioEN.Nombre;
            return View(categoriaUsuarioEN);
        }

        // POST: CategoriaUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoriaUsuarioEN categoriaUsuarioEN)
        {
            try
            {
                CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
                categoriaUsuarioCEN.Modify(id, categoriaUsuarioEN.Nombre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
            CategoriaUsuarioEN categoriaUsuarioEN = categoriaUsuarioCEN.ReadOID(id);
            ViewData["nombre"] = categoriaUsuarioEN.Nombre;
            return View(categoriaUsuarioEN);
        }

        // POST: CategoriaUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoriaUsuarioEN categoriaUsuarioEN)
        {
            try
            {
                CategoriaUsuarioCP categoriaUsuarioCP = new CategoriaUsuarioCP();
                categoriaUsuarioCP.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
