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
        public ActionResult Index(int? pag)
        {
            SessionInitialize();

            RecuerdoCAD cadRec = new RecuerdoCAD(session);
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN(cadRec);

            int tamPag = 10;

            int numPags = (recuerdoCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<RecuerdoEN> listaRecuerdosEn = recuerdoCEN.ReadAll(inicio, tamPag).ToList();

            IEnumerable<Recuerdo> listaRecuerdos = new AssemblerRecuerdo().ConvertListENToModel(listaRecuerdosEn).ToList();

            SessionClose();

            return View(listaRecuerdos);
        }

        // GET: Recuerdo/Details/5
        public ActionResult Details(int id, string url)
        {
            Recuerdo rec = null;
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            ViewData["urlVolver"] = url;
            return View(rec);
        }

        // GET: Recuerdo/Create
        public ActionResult Create(int idEvento)
        {
            Recuerdo rec = new Recuerdo();
            ViewData["idevento"] = idEvento;
            return View(rec);
        }


        public ActionResult CreateNoId()
        {
            Recuerdo recuerdo = new Recuerdo();
            return View(recuerdo);
        }

        // POST: Recuerdo/Create/id
        [HttpPost]
        public ActionResult Create(int idEvento, Recuerdo rec)
        {
            try
            {
                // TODO: Add insert logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                EventoCEN eventoCEN = new EventoCEN();
                EventoEN evento = eventoCEN.ReadOID(idEvento);
                cen.New_(rec.Titulo, rec.Cuerpo, idEvento,null);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: Recuerdo/Create/id
        [HttpPost]
        public ActionResult CreateNoId(Recuerdo rec)
        {
            try
            {
                // TODO: Add insert logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                EventoCEN eventoCEN = new EventoCEN();
                EventoEN evento = eventoCEN.ReadOID(rec.IdEvento);
                cen.New_(rec.Titulo, rec.Cuerpo, rec.IdEvento, null);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // GET: Recuerdo/Edit/5
        public ActionResult Edit(int id, string url)
        {
            //Recuerdo rec = null;
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            //rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            ViewData["urlVolver"] = url;
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string url, Recuerdo rec)
        {
            try
            {
                // TODO: Add update logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                cen.Modify(id, rec.Titulo, rec.Cuerpo, null);
                return Redirect(url);
            }
            catch
            {
                return View();
            }
        }

        // GET: Recuerdo/Delete/5
        public ActionResult Delete(int id, string url)
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            ViewData["urlVolver"] = url;
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string url, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                recuerdoCEN.Destroy(id);
                return Redirect(url);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult porEvento (int idEvento)
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            IList<RecuerdoEN> recuerdo = recuerdoCEN.DameRecuerdosPorProyecto(idEvento);
            IEnumerable<Recuerdo> listaRecuerdos = new AssemblerRecuerdo().ConvertListENToModel(recuerdo).ToList();
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN evento = eventoCEN.ReadOID(idEvento);
            ViewData["idevento"] = idEvento;
            ViewData["nombreEvento"] = evento.Nombre;
            return View(listaRecuerdos);
        }
    }
}
