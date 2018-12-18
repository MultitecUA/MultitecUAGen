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
           
           
            EventoCEN eventoCEN = new EventoCEN();
            IList<EventoEN> listaEventoEn = eventoCEN.ReadAll(0, -1).ToList();
            //IEnumerable<Servicio> listaServicios = new AssemblerServicio().ConvertListENToModel(listaServiciosEn).ToList();
           
            return View(listaEventoEn);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            
            ArrayList listaCates = new ArrayList();
            CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
            List<CategoriaProyectoEN> cat = categoriasP.ReadAll(0, -1).ToList();
            foreach (CategoriaProyectoEN a in cat)
            {
                listaCates.Add(a.Id);
            }
            ViewData["listaCategoriasP"] = listaCates;
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = new EventoCEN().ReadOID(id);
            ViewData["NombreEvento"] = eventoEN.Nombre;
            ViewData["IdEvento"] = id;
            
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
            EventoEN eventoEN = new EventoCEN().ReadOID(id);
            return View(eventoEN);
        }

        // POST: Evento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventoEN evento)
        {
            try
            {
                // TODO: Add update logic here
                EventoCP eve = new EventoCP();
                eve.Modify(id, evento.Nombre, evento.Descripcion, evento.FechaInicio, evento.FechaFin, evento.FechaInicioInscripcion, evento.FechaTopeInscripcion, null);
                ViewData["NombreEvento"] = evento.Nombre;
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
            return View(eventoEN);
        }

        // POST: Evento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventoEN evento)
        {
            try
            {
                // TODO: Add delete logic here
                EventoCP eventoCP = new EventoCP();
                eventoCP.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PorFiltro()
        {
            
            EventoEN evento = new EventoEN();
            //CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
            //IList<CategoriaProyectoEN> categoriasProyecto = categoriasP.ReadAll(0, -1).ToList();
            //List<string> listaCateP = new List<string>();
            //foreach (CategoriaProyectoEN a in categoriasProyecto)
            //{
            //listaCateP.Add(a.Nombre);
            //}
            //ViewData["listaCateP"] = listaCateP;
            
            return View(evento);
        }

        public ActionResult Filtrar(FormCollection f)
        {
           
            //if (f["categoria"] != null)
            //{
            /*string[] ps = f["categoria"].Split(',');
            List<string> a = new List<string>();
            for (byte i = 0; i < ps.Length; i++)
            {
                a.Add(ps[i]);
            }*/

            //}
           
            EventoCEN evento = new EventoCEN();
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

            
            return View(listaEventos);
        }


        [HttpPost]
        public ActionResult AgregarCat(int id, FormCollection f)
        {

            if (f["Categoria"] != "")
            {
                int num = id;//int.Parse(f["IdEvento"]);
                List<int> categorias = new List<int>();
                categorias.Add(int.Parse(f["Categoria"]));
                EventoCEN evento = new EventoCEN();
                evento.AgregaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });


        }


        [HttpPost]
        public ActionResult EliminarCat(int id, FormCollection f)
        {
            if (f["Categoria"] != "")
            {
                int num = id;//int.Parse(f["IdEvento"]);
                List<int> categorias = new List<int>();
                categorias.Add(int.Parse(f["Categoria"]));
                EventoCEN evento = new EventoCEN();
                evento.EliminaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }
            return RedirectToAction("Details", new { id });


        }



    }
}
