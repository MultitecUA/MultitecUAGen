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
    public class ProyectoController : BasicController
    {
        // GET: Proyecto
        public ActionResult Index(int? pag)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            int tamPag = 10;

            int numPags = (proyectoCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<ProyectoEN> listaProyectos = proyectoCEN.ReadAll(inicio, tamPag).ToList();

            return View(listaProyectos);
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            return View(proyectoEN);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            ProyectoEN proyectoEN = new ProyectoEN();
            return View(proyectoEN);
        }

        // POST: Proyecto/Create
        [HttpPost]
        public ActionResult Create(ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.New_(proyectoEN.Nombre, proyectoEN.Descripcion, proyectoEN.UsuarioCreador.Id, proyectoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            return View(proyectoEN);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                proyectoCP.Modify(id, proyectoEN.Nombre, proyectoEN.Descripcion, proyectoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            return View(proyectoEN);
        }

        // POST: Proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                proyectoCP.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Delete/5
        public ActionResult ProyectosPorEvento(int id)
        {
            /*
             * TODO
             */
            return null;
        }
    }
}
