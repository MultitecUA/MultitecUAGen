using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MVC_MultitecUA.Models;
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
        public ActionResult Index()
        {
            SessionInitialize();
            ProyectoCAD cadPro = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(cadPro);
            IList<ProyectoEN> listaProyectosEn = proyectoCEN.ReadAll(0, -1).ToList();
            IEnumerable<ProyectoModel> listaProyectos = new AssemblerProyecto().ConvertListENToModel(listaProyectosEn).ToList();
            SessionClose();
            return View(listaProyectos);
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int id)
        {
            ProyectoModel proy = null;
            SessionInitialize();
            ProyectoEN proyectoEN = new ProyectoCAD(session).ReadOID(id);
            proy = new AssemblerProyecto().ConvertENToModelUI(proyectoEN);
            SessionClose();
            return View(proy);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            ProyectoModel proyectoM = new ProyectoModel();
            return View(proyectoM);
        }

        // POST: Proyecto/Create
        [HttpPost]
        public ActionResult Create(ProyectoModel proyectoModel)
        {
            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();

                proyectoCEN.New_(proyectoModel.Nombre, proyectoModel.Descripcion, proyectoModel.usuarioId, null);

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
            return View();
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
