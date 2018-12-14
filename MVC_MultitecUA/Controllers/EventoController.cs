using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections;
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
            SessionInitialize();
            EventoCAD cadEven = new EventoCAD(session);
            EventoCEN eventoCEN = new EventoCEN(cadEven);
            IList<EventoEN> listaEventoEn = eventoCEN.ReadAll(0, -1).ToList();
            //IEnumerable<Servicio> listaServicios = new AssemblerServicio().ConvertListENToModel(listaServiciosEn).ToList();
            SessionClose();
            return View(listaEventoEn);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ArrayList listaCates = new ArrayList();
            CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
            List<CategoriaProyectoEN> cat = categoriasP.ReadAll(0, -1).ToList();
            foreach (CategoriaProyectoEN a in cat)
            {
                listaCates.Add(a.Id);
            }
            ViewData["listaCategoriasP"] = listaCates;
            EventoCAD servicioCAD = new EventoCAD(session);
            EventoCEN eventoCEN = new EventoCEN(servicioCAD);
            EventoEN eventoEN = new EventoCEN().ReadOID(id);
            ViewData["NombreEvento"] = eventoEN.Nombre;
            ViewData["IdEvento"] = id;
            SessionClose();
            return View(eventoEN);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            EventoEN evento = new EventoEN();
            return View(evento);
        }

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Create(EventoEN evento)
        {
            try
            {
                // TODO: Add insert logic here
                EventoCEN eventoCEN = new EventoCEN();
                int OIDEvento = eventoCEN.New_(evento.Nombre, evento.Descripcion, evento.FechaInicio, evento.FechaFin, evento.FechaInicioInscripcion, evento.FechaTopeInscripcion, null);
                eventoCEN.PublicaEvento(OIDEvento);
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
            SessionInitialize();
            EventoEN eventoEN = new EventoCAD(session).ReadOID(id);
            SessionClose();
            return View(eventoEN);
        }

        // POST: Evento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventoEN evento)
        {
            try
            {
                // TODO: Add update logic here
                SessionInitialize();
                EventoCP eve = new EventoCP(session);
                eve.Modify(id, evento.Nombre, evento.Descripcion, evento.FechaInicio, evento.FechaFin, evento.FechaInicioInscripcion, evento.FechaTopeInscripcion, null);
                ViewData["NombreEvento"] = evento.Nombre;
                SessionClose();
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
            ViewData["NombreEvento"] = eventoEN.Nombre;
            SessionClose();
            return View(eventoEN);
        }

        // POST: Evento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventoEN evento)
        {
            try
            {
                // TODO: Add delete logic here
                SessionInitialize();
                EventoCP eventoCP = new EventoCP(session);
                eventoCP.Destroy(id);
                SessionClose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PorFiltro()
        {
            SessionInitialize();
            EventoEN evento = new EventoEN();
            //CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
            //IList<CategoriaProyectoEN> categoriasProyecto = categoriasP.ReadAll(0, -1).ToList();
            //List<string> listaCateP = new List<string>();
            //foreach (CategoriaProyectoEN a in categoriasProyecto)
            //{
            //listaCateP.Add(a.Nombre);
            //}
            //ViewData["listaCateP"] = listaCateP;
            SessionClose();
            return View(evento);
        }

        public ActionResult Filtrar(FormCollection f)
        {
            SessionInitialize();
            //if (f["categoria"] != null)
            //{
            /*string[] ps = f["categoria"].Split(',');
            List<string> a = new List<string>();
            for (byte i = 0; i < ps.Length; i++)
            {
                a.Add(ps[i]);
            }*/

            //}
            EventoCAD eventoCAD = new EventoCAD(session);
            EventoCEN evento = new EventoCEN(eventoCAD);
            int num = int.Parse(f["Categoria"]);
            IList<EventoEN> listaEventos;

            if (f["FechaAnterior"] == "" && f["FechaFinal"] == "")
            {
                listaEventos = evento.DameEventosFiltrados(num, null, null);
            }
            else if (f["FechaAnterior"] == "")
            {
                DateTime ff = DateTime.Parse(f["FechaFinal"]);
                listaEventos = evento.DameEventosFiltrados(num, null, ff);
            }
            else if (f["FechaFinal"] == "")
            {
                DateTime fa = DateTime.Parse(f["FechaAnterior"]);
                listaEventos = evento.DameEventosFiltrados(num, fa, null);
            }
            else
            {
                DateTime ff = DateTime.Parse(f["FechaFinal"]);
                DateTime fa = DateTime.Parse(f["FechaAnterior"]);
                listaEventos = evento.DameEventosFiltrados(num, fa, null);
            }

            SessionClose();
            return View(listaEventos);
        }


        [HttpPost]
        public ActionResult AgregarCat(int id, FormCollection f)
        {
            SessionInitialize();
            if (f["Categoria"] != "")
            {
                int num = id;//int.Parse(f["IdEvento"]);
                List<int> categorias = new List<int>();
                categorias.Add(int.Parse(f["Categoria"]));
                EventoCAD eventoCAD = new EventoCAD(session);
                EventoCEN evento = new EventoCEN(eventoCAD);
                evento.AgregaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }
            SessionClose();
            return RedirectToAction("Details", new { id });


        }


        [HttpPost]
        public ActionResult EliminarCat(int id, FormCollection f)
        {
            SessionInitialize();
            if (f["Categoria"] != "")
            {
                int num = id;//int.Parse(f["IdEvento"]);
                List<int> categorias = new List<int>();
                categorias.Add(int.Parse(f["Categoria"]));
                EventoCAD eventoCAD = new EventoCAD(session);
                EventoCEN evento = new EventoCEN(eventoCAD);
                evento.EliminaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }
            SessionClose();
            return RedirectToAction("Details", new { id });


        }



    }
}