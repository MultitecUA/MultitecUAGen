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
        public ActionResult Index()
        {
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
            IList<CategoriaUsuarioEN> listaCategoriasUsuarios = categoriaUsuarioCEN.ReadAll(0, -1).ToList();
            return View(listaCategoriasUsuarios);
        }

        // GET: CategoriaUsuario/Details/5
        public ActionResult Details(int id)
        {
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();
            CategoriaUsuarioEN categoriaUsuarioEN = categoriaUsuarioCEN.ReadOID(id);
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
            return View(categoriaUsuarioEN);
        }

        // POST: CategoriaUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
