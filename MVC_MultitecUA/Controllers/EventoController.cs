using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class EventoController : BasicController
    {
        // GET: Evento
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            EventoCEN eventoCEN = new EventoCEN();

            int tamPag = 10;
            int numPags = (eventoCEN.ReadAll(0, -1).Count - 1) / tamPag;
            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;
            ViewData["numeroPaginas"] = numPags;
            int inicio = (int)pag * tamPag;

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");
            
            IList<EventoEN> listaEventoEn = eventoCEN.ReadAll(inicio, tamPag).ToList();

            return View(listaEventoEn);

        }

        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            SessionInitialize();
            ArrayList listaCatesE = new ArrayList();
            ArrayList listaCatesA = new ArrayList();
            CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
            List<CategoriaProyectoEN> cat = categoriasP.ReadAll(0, -1).ToList();

            EventoCAD eventoCAD = new EventoCAD(session);
            EventoCEN eventoCEN = new EventoCEN(eventoCAD);
            EventoEN evento = eventoCEN.ReadOID(id);
            foreach (CategoriaProyectoEN a in cat)
            {
                if (!evento.CategoriasEventos.Contains(a))
                    listaCatesA.Add(a.Nombre);
                else
                    listaCatesE.Add(a.Nombre);
            }
            ViewData["listaCategoriasAgregar"] = listaCatesA;
            ViewData["listaCategoriasEliminar"] = listaCatesE;
            ViewData["NombreEvento"] = evento.Nombre;
            ViewData["IdEvento"] = id;
            SessionClose();

            return View(evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            EventoEN evento = new EventoEN();

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");

            return View(evento);
        }

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Create(EventoEN evento)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try{

                EventoCEN eventoCEN = new EventoCEN();

                if(evento.Nombre == null || evento.Descripcion == null || evento.FechaInicio == null || evento.FechaFin == null || evento.FechaInicioInscripcion == null || evento.FechaTopeInscripcion == null){
                    ViewData["eventovacio"] = "vacio";
                    return View();
                }
                
                //VALIDANDO NOMBRE
                    Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                    if (!pattern.IsMatch(evento.Nombre))
                    {
                        ViewData["formatonombreevento"] = "mal";
                        return View();
                    }

                    if(eventoCEN.ReadNombre(evento.Nombre) != null)
                    {
                        ViewData["nombreevento"] = "existe";
                        return View();
                    }

                //VALIDANDO DESCRIPCRION
                    pattern = new Regex("^.{5,200}$");
                    if (!pattern.IsMatch(evento.Descripcion))
                    {
                        ViewData["formatodescripvento"] = "mal";
                        return View();
                    }

                //VALIDANDO FECHAS  
                    if(evento.FechaInicio > evento.FechaFin)
                    {
                        ViewData["FIMayorFF"] = "mal";
                        return View();
                    }
                    if (evento.FechaInicioInscripcion > evento.FechaTopeInscripcion)
                    {
                        ViewData["FIIMayorFTI"] = "mal";
                        return View();
                    }
                    if(evento.FechaInicioInscripcion > evento.FechaFin)
                    {
                        ViewData["FIIMayorFF"] = "mal";
                        return View();
                    }
                    if(evento.FechaTopeInscripcion > evento.FechaFin)
                    {
                        ViewData["FTIMayorFF"] = "mal";
                        return View();
                    }
                
                int OIDEvento = eventoCEN.New_(evento.Nombre, evento.Descripcion, evento.FechaInicio, evento.FechaFin, evento.FechaInicioInscripcion, evento.FechaTopeInscripcion, null);
                eventoCEN.PublicaEvento(OIDEvento);
                TempData["eventocreado"] = "si";
                if (TempData.ContainsKey("eventoeditado"))
                    TempData.Remove("eventoeditado");

                return RedirectToAction("Details/" + OIDEvento);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            EventoEN eventoEN = new EventoCEN().ReadOID(id);
            ViewData["evento"] = eventoEN.Nombre;

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");
            
            return View(eventoEN);
        }

        // POST: Evento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventoEN evento)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            try{
                
                EventoCP eve = new EventoCP();
                EventoCEN eventoCEN = new EventoCEN();
                
                if (evento.Nombre == null || evento.Descripcion == null || evento.FechaInicio == null || evento.FechaFin == null || evento.FechaInicioInscripcion == null || evento.FechaTopeInscripcion == null)
                {
                    ViewData["eventovacio"] = "vacio";
                    return View();
                }

                //VALIDANDO NOMBRE
                    Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                    if (!pattern.IsMatch(evento.Nombre))
                    {
                        ViewData["formatonombreevento"] = "mal";
                        return View();
                    }

                    if (eventoCEN.ReadNombre(evento.Nombre) != null)
                    {
                        ViewData["nombreevento"] = "existe";
                        return View();
                    }

                //VALIDANDO DESCRIPCRION
                    pattern = new Regex("^.{5,200}$");
                    if (!pattern.IsMatch(evento.Descripcion))
                    {
                        ViewData["formatodescripvento"] = "mal";
                        return View();
                    }

                //VALIDANDO FECHAS  
                    if (evento.FechaInicio > evento.FechaFin)
                    {
                        ViewData["FIMayorFF"] = "mal";
                        return View();
                    }
                    if (evento.FechaInicioInscripcion > evento.FechaTopeInscripcion)
                    {
                        ViewData["FIIMayorFTI"] = "mal";
                        return View();
                    }
                    if (evento.FechaInicioInscripcion > evento.FechaFin)
                    {
                        ViewData["FIIMayorFF"] = "mal";
                        return View();
                    }
                    if (evento.FechaTopeInscripcion > evento.FechaFin)
                    {
                        ViewData["FTIMayorFF"] = "mal";
                        return View();
                    }
                    
                eve.Modify(id, evento.Nombre, evento.Descripcion, evento.FechaInicio, evento.FechaFin, evento.FechaInicioInscripcion, evento.FechaTopeInscripcion, null);
                ViewData["NombreEvento"] = evento.Nombre;
                TempData["eventoeditado"] = "si";

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(id);
            ViewData["NombreEvento"] = eventoEN.Nombre;

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");

            return View(eventoEN);
        }






        // POST: Evento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventoEN evento)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            try{

                EventoCP eventoCP = new EventoCP();
                eventoCP.Destroy(id);

                if (TempData.ContainsKey("eventoeditado"))
                    TempData.Remove("eventoeditado");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        public ActionResult PorFiltro()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            EventoEN evento = new EventoEN();
            CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
            IList<CategoriaProyectoEN> categoriasProyecto = categoriasP.ReadAll(0, -1).ToList();
            ArrayList categorias = new ArrayList();

            foreach (CategoriaProyectoEN a in categoriasProyecto)
                categorias.Add(a.Nombre);

            ViewData["listacategorias"] = categorias;
            
            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");

            return View(evento);
        }



        [HttpPost]
        public ActionResult Filtrar(FormCollection f)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
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
            IList<EventoEN> listaEventos = new List<EventoEN>();

            CategoriaProyectoCEN categoriaCEN = new CategoriaProyectoCEN();
            if (f["Categoria"] != "")
            {
                CategoriaProyectoEN categoria = categoriaCEN.ReadNombre(f["Categoria"]);
                if(categoria != null)
                {
                    int num = categoria.Id;
                    
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
                        if (ff>=fa)
                        {
                            CategoriaProyectoCEN categoriasP = new CategoriaProyectoCEN();
                            IList<CategoriaProyectoEN> categoriasProyecto = categoriasP.ReadAll(0, -1).ToList();
                            ArrayList categorias = new ArrayList();
                            foreach (CategoriaProyectoEN a in categoriasProyecto)
                            {
                                categorias.Add(a.Nombre);
                            }
                            ViewData["listacategorias"] = categorias;
                            ViewData["fechamal"] = "si";
                            return View("PorFiltro");
                        }
                        listaEventos = evento.DameEventosFiltrados(num, fa, ff);
                    }
                }
            }

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");
            
            return View(listaEventos);
        }




        [HttpPost]
        public ActionResult AgregarCat(int id, FormCollection f)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            if (f["Categoria"] != "")
            {
                int num = id;//int.Parse(f["IdEvento"]);
                CategoriaProyectoCEN categoria = new CategoriaProyectoCEN();
                CategoriaProyectoEN categoriaEN = categoria.ReadNombre(f["Categoria"]);
                List<int> categorias = new List<int>();
                categorias.Add(categoriaEN.Id);

                EventoCEN eventoCEN = new EventoCEN();
                eventoCEN.AgregaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");

            return RedirectToAction("Details", new { id });
        }


        [HttpPost]
        public ActionResult EliminarCat(int id, FormCollection f)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            if (f["Categoria"] != "")
            {
                int num = id;//int.Parse(f["IdEvento"]);
                CategoriaProyectoCEN categoria = new CategoriaProyectoCEN();
                CategoriaProyectoEN categoriaEN = categoria.ReadNombre(f["Categoria"]);
                List<int> categorias = new List<int>();
                categorias.Add(categoriaEN.Id);

                EventoCEN eventoCEN = new EventoCEN();
                eventoCEN.EliminaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");

            return RedirectToAction("Details", new { id });
        }


        //GET
        public ActionResult porProyecto(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            EventoCEN eventoCEN = new EventoCEN();
            IList<EventoEN> eventos = eventoCEN.DameEventosPorProyecto(id);
            ViewData["idProyecto"] = id;

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");
            
            return View(eventos);
        }

  
        //GET
        public ActionResult eliminandoRelacion(int idP, int idE)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyecto = proyectoCEN.ReadOID(idP);
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN evento = eventoCEN.ReadOID(idE);
            ViewData["idEvento"] = idE;
            ViewData["nombreEvento"] = evento.Nombre;

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");
            
            return View(proyecto);
        }



        //POST
        [HttpPost]
        public ActionResult ForNombre(FormCollection f)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            EventoCEN eventoCEN = new EventoCEN();
            IList<EventoEN> listaEventos = eventoCEN.DameEventosPorNombre(f["nombre"]);
            ViewData["Buscando"] = f["nombre"];

            if (TempData.ContainsKey("eventocreado"))
                TempData.Remove("eventocreado");
            if (TempData.ContainsKey("eventoeditado"))
                TempData.Remove("eventoeditado");
            
            return View(listaEventos);
        }



    }
}
