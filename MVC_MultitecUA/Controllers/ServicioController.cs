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
    public class ServicioController : BasicController
    {
        // GET: Servicio
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            SessionInitialize();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoServicioEnum)))  
                listaEstados.Add(a);
          
            ViewData["listaEstadosServicio"] = listaEstados;

            ServicioCAD cadServ = new ServicioCAD(session);
            ServicioCEN servicioCEN = new ServicioCEN(cadServ);

            int tamPag = 10;

            int numPags = (servicioCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<ServicioEN> listaServiciosEN = servicioCEN.ReadAll(inicio, tamPag).ToList();

            IEnumerable<Servicio> listaServicios = new AssemblerServicio().ConvertListENToModel(listaServiciosEN).ToList();

            SessionClose();

            return View(listaServicios);
        }

        //POST: Servicio/PorEstado
        [HttpPost]
        public ActionResult PorEstado(FormCollection f)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (f == null)
                return RedirectToAction("Index");
            
            SessionInitialize();

            ArrayList listaEstados = new ArrayList();

            foreach (var cosa in Enum.GetNames(typeof(EstadoServicioEnum)))
                listaEstados.Add(cosa);

            ViewData["listaEstadosServicio"] = listaEstados;

            ServicioCAD cadServ = new ServicioCAD(session);
            ServicioCEN servicioCEN = new ServicioCEN(cadServ);

            var a = Enum.Parse(typeof(EstadoServicioEnum), f["Estados"]);

            ViewData["filtroEstado"] = f["Estados"];

            IList<ServicioEN> lista = servicioCEN.DameServiciosPorEstado((EstadoServicioEnum)a);

            IEnumerable<Servicio> listaServiciosEstados = new AssemblerServicio().ConvertListENToModel(lista).ToList();
            SessionClose();

            return View(listaServiciosEstados);
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            Servicio serv = null;
            ServicioEN servicioEN = new ServicioCAD(session).ReadOID(id);
            serv = new AssemblerServicio().ConvertENToModelUI(servicioEN);
            ViewData["servicio"] = servicioEN.Nombre;
            return View(serv);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            ArrayList listaEstados = new ArrayList();
            foreach (var a in Enum.GetNames(typeof(EstadoServicioEnum)))
            {
                listaEstados.Add(a);
            }
            ViewData["listaEstadosServicio"] = listaEstados;
            Servicio serv = new Servicio();
            return View(serv);
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(Servicio serv)
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
                ServicioCEN cen = new ServicioCEN();
                int id = cen.New_(serv.Nombre, serv.Descripcion, serv.Estado,null);
                TempData["serviciocreado"] = "si";
                return Redirect("Details/"+id);
            }
            catch
            {
                TempData["servicionocreado"] = "si";
                return View();
            }
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            Servicio serv = null;
            SessionInitialize();
            ArrayList listaEstados = new ArrayList();
            foreach (var a in Enum.GetNames(typeof(EstadoServicioEnum)))
            {
                listaEstados.Add(a);
            }
            ViewData["listaEstadosServicio"] = listaEstados;
            ServicioEN servicioEN = new ServicioCAD(session).ReadOID(id);
            serv = new AssemblerServicio().ConvertENToModelUI(servicioEN);
            ViewData["servicio"] = servicioEN.Nombre;
            SessionClose();
            return View(serv);
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Servicio serv)
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
                ServicioCEN cen = new ServicioCEN();
                cen.Modify(id, serv.Nombre, serv.Descripcion,serv.Estado,null);
                TempData["servicioeditado"] = "si";
                return RedirectToAction("Details/" + id);
            }
            catch
            {
                TempData["servicionoeditado"] = "si";
                return View();
            }
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            ServicioCEN servicioCEN = new ServicioCEN();
            ServicioEN servicioEN = servicioCEN.ReadOID(id);
            ViewData["servicio"] = servicioEN.Nombre;
            return View(servicioEN);
        }

        // POST: Servicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ServicioEN ser)
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
                ServicioCEN servicioCEN = new ServicioCEN();
                servicioCEN.Destroy(id);

                TempData["bien"] = "Se a borrado correctamente el servicio " + ser.Nombre;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar borrar el servicio";
                return RedirectToAction("Index");
            }
        }
    }
}
