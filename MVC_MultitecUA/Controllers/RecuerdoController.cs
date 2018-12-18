using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using MVC_MultitecUA.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class RecuerdoController : BasicController
    {
        // GET: Recuerdo
        public ActionResult Index()
        {
            SessionInitialize();
            RecuerdoCAD cadRec = new RecuerdoCAD(session);
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN(cadRec);
            IList<RecuerdoEN> listaRecuerdosEn = recuerdoCEN.ReadAll(0, -1).ToList();
            IEnumerable<Recuerdo> listaRecuerdos = new AssemblerRecuerdo().ConvertListENToModel(listaRecuerdosEn).ToList();
            SessionClose();
            return View(listaRecuerdos);
        }

        // GET: Recuerdo/Details/5
        public ActionResult Details(int id)
        {
            Recuerdo rec = null;
            SessionInitialize();
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            SessionClose();
            return View(rec);
        }

        // GET: Recuerdo/Create
        public ActionResult Create(int id)
        {
            /*ArrayList listaEventosNombre = new ArrayList();
            ArrayList listaEventosId = new ArrayList();
            SessionInitialize();
            EventoCAD eventoCAD = new EventoCAD(session);
            EventoCEN eventoCEN = new EventoCEN(eventoCAD);
            IList<EventoEN> recuerdos = eventoCEN.ReadAll(0,-1).ToList();
            foreach (EventoEN elemento in recuerdos)
            {
                listaEventosNombre.Add(elemento.Nombre);
                listaEventosId.Add(elemento.Id);
            }
            ViewData["ListaEventosNombre"] = listaEventosNombre;
            ViewData["ListaEventosId"] = listaEventosId;*/
            Recuerdo rec = new Recuerdo();
            //SessionClose();
            return View(rec);
        }

        // POST: Recuerdo/Create
        [HttpPost]
        public ActionResult Create(int id, Recuerdo rec)
        {
            try
            {
                // TODO: Add insert logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                cen.New_(rec.Titulo, rec.Cuerpo, id,null);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recuerdo/Edit/5
        public ActionResult Edit(int id)
        {
            //Recuerdo rec = null;
            SessionInitialize();
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            //rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            SessionClose();
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Recuerdo rec)
        {
            try
            {
                // TODO: Add update logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                cen.Modify(id, rec.Titulo, rec.Cuerpo, null);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recuerdo/Delete/5
        public ActionResult Delete(int id)
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                recuerdoCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
