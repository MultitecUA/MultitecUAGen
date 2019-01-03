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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

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

            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("nocreado"))
            {
                TempData.Remove("nocreado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }

            SessionClose();

            return View(listaRecuerdos);
        }

        // GET: Recuerdo/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            Recuerdo rec = null;
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            ViewData["recuerdo"] = recuerdoEN.Titulo;
            return View(rec);
        }

        // GET: Recuerdo/Create
        public ActionResult Create(int idEvento)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            Recuerdo rec = new Recuerdo();
            ViewData["idevento"] = idEvento;
            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }

            return View(rec);
        }


        public ActionResult CreateNoId()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            Recuerdo recuerdo = new Recuerdo();
            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }
            return View(recuerdo);
        }

        // POST: Recuerdo/Create/id
        [HttpPost]
        public ActionResult Create(int idEvento, Recuerdo rec)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                RecuerdoCEN cen = new RecuerdoCEN();
                EventoCEN eventoCEN = new EventoCEN();
                EventoEN evento = eventoCEN.ReadOID(idEvento);
                int id = cen.New_(rec.Titulo, rec.Cuerpo, idEvento,null);
                TempData["creado"] = "si";
                return Redirect("Details/"+id);
            }
            catch
            {
                TempData["nocreado"] = "Ha habido un error al crear el recuerdo";
                return View();
            }
        }


        // POST: Recuerdo/Create/id
        [HttpPost]
        public ActionResult CreateNoId(Recuerdo rec)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                // TODO: Add insert logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                EventoCEN eventoCEN = new EventoCEN();
                EventoEN evento = eventoCEN.ReadOID(rec.IdEvento);
                int id = cen.New_(rec.Titulo, rec.Cuerpo, rec.IdEvento, null);
                TempData["creado"] = "si";

                return Redirect("Details/" + id);
            }
            catch
            {
                TempData["nocreado"] = "si";
                return View();
            }
        }




        // GET: Recuerdo/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            //Recuerdo rec = null;
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            Recuerdo recuerdo = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            //rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("nocreado"))
            {
                TempData.Remove("nocreado");
            }
            ViewData["recuerdo"] = recuerdoEN.Titulo;
            return View(recuerdo);
        }

        // POST: Recuerdo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Recuerdo rec)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            try
            {
                // TODO: Add update logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                cen.Modify(id, rec.Titulo, rec.Cuerpo, null);
                TempData["editado"] = "si";
                return RedirectToAction("Details/"+id);
            }
            catch
            {
                //En teoría aquí no entra porque la validación ya la hace el modelo o el input
                return View();
            }
        }

        // GET: Recuerdo/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("nocreado"))
            {
                TempData.Remove("nocreado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }
            ViewData["recuerdo"] = recuerdoEN.Titulo;
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RecuerdoEN recuerdo)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            try
            {
                // TODO: Add delete logic here
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                recuerdoCEN.Destroy(id);

                TempData["bien"] = "Se a borrado correctamente el recuerdo " + recuerdo.Titulo;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar borrar el recuerdo";
                return RedirectToAction("Index");
            }
        }

        public ActionResult porEvento (int idEvento)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            IList<RecuerdoEN> recuerdo = recuerdoCEN.DameRecuerdosPorProyecto(idEvento);
            IEnumerable<Recuerdo> listaRecuerdos = new AssemblerRecuerdo().ConvertListENToModel(recuerdo).ToList();
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN evento = eventoCEN.ReadOID(idEvento);
            ViewData["idevento"] = idEvento;
            ViewData["nombreEvento"] = evento.Nombre;
            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("nocreado"))
            {
                TempData.Remove("nocreado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }
            return View(listaRecuerdos);
        }
    }
}
