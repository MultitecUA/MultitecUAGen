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
    public class EventoController : BasicController
    {
        // GET: Evento
        public ActionResult Index()
        {
            EventoCEN eventoCEN = new EventoCEN();
            IList<EventoEN> listaEventos = eventoCEN.ReadAll(0, -1).ToList();
            return View(listaEventos);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(id);
            return View(eventoEN);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            EventoEN eventoEN = new EventoEN();
            return View(eventoEN);
        }

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Create(EventoEN eventoEN)
        {
            try
            {
                EventoCEN eventoCEN = new EventoCEN();
                eventoCEN.New_(eventoEN.Nombre, eventoEN.Descripcion, eventoEN.FechaInicio, eventoEN.FechaFin, eventoEN.FechaInicioInscripcion, eventoEN.FechaTopeInscripcion, eventoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int id)
        {
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(id);
            return View(eventoEN);
        }

        // POST: Evento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventoEN eventoEN)
        {
            try
            {
                EventoCP eventoCP = new EventoCP();
                eventoCP.Modify(id, eventoEN.Nombre, eventoEN.Descripcion, eventoEN.FechaInicio, eventoEN.FechaFin, eventoEN.FechaInicioInscripcion, eventoEN.FechaTopeInscripcion, eventoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int id)
        {
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(id);
            return View(eventoEN);
        }

        // POST: Evento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventoEN eventoEN)
        {
            try
            {
                EventoCP eventoCP = new EventoCP();
                eventoCP.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
