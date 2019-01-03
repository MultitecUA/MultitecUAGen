using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MVC_MultitecUA.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class SolicitudController : BasicController
    {
        // GET: Solicitud
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1).ToList();
            ArrayList listaNicks = new ArrayList();

            foreach (var e in listaUsuarios)
            {
                listaNicks.Add(e.Nick);
            }

            ViewData["ListaNicks"] = listaNicks;

            ArrayList listaEstados = new ArrayList();
            listaEstados.Add("Todos");
            listaEstados.Add("Pendiente");
            listaEstados.Add("Aceptada");
            listaEstados.Add("Rechazada");
            ViewData["estados"] = listaEstados;


            //Paginacion
            int tamPag = 10;
            int numPags = (solicitudCEN.ReadAll(0, -1).Count - 1) / tamPag;
            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;
            ViewData["pag"] = pag;
            ViewData["numeroPaginas"] = numPags;
            int inicio = (int)pag * tamPag;

            IList<SolicitudEN> listaSolicitudes = solicitudCEN.ReadAll(inicio, tamPag).ToList();
            IEnumerable<Solicitud> solicitudes = new AssemblerSolicitud().ConvertListENToModel(listaSolicitudes).ToList();

            return View(solicitudes);
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1).ToList();

            ArrayList listaNicks = new ArrayList();

            foreach (var e in listaUsuarios)
            {
                listaNicks.Add(e.Nick);
            }

            ViewData["ListaNicks"] = listaNicks;


            ProyectoCEN proyectoCEN = new ProyectoCEN();
            IList<ProyectoEN> listaProyectos = proyectoCEN.ReadAll(0, -1).ToList();

            ArrayList listaNombres = new ArrayList();

            foreach (var e in listaProyectos)
            {
                listaNombres.Add(e.Nombre);
            }

            ViewData["listaNombreProyectos"] = listaNombres;



            Solicitud solicitud = new Solicitud();

            return View(solicitud);
        }

        // POST: Solicitud/Create
        [HttpPost]
        public ActionResult Create(Solicitud solicitud)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {

                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadNick(solicitud.Nick_Solicitante);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                ProyectoEN proyectoEN = proyectoCEN.ReadNombre(solicitud.Nombre_Proyecto);

                SolicitudCEN solicitudCEN = new SolicitudCEN();


                bool denegar = false;
                //No crear usuarios nuevos si ya existe una solicitud aceptada o pendiente
                foreach (SolicitudEN e in solicitudCEN.DameSolicidudesPorUsuarioYProyecto(proyectoEN.Id, usuarioEN.Id) )
                {
                    if (e.Estado.ToString() == "Pendiente" || e.Estado.ToString() == "Aceptada")
                    {
                        denegar = true;
                    }
                }

                if (denegar)
                {
                    TempData["mal"] = "El proyecto "+proyectoEN.Nombre+" ya tiene una solicitud Pendiente o Aceptada del usuario "+usuarioEN.Nick;
                    return RedirectToAction("Index");
                }
               if (!denegar)
                {
                    TempData["bien"] = "Se creo correctamente una solicitud del usuario " + usuarioEN.Nick + " al proyecto " + proyectoEN.Nombre;
                }

                int solicitudId = solicitudCEN.New_(usuarioEN.Id, proyectoEN.Id);
                solicitudCEN.EnviarSolicitud(solicitudId);

                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = solicitudId });
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar crear la solicitud " + solicitud.Id;
                return RedirectToAction("Index");
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);
            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            ViewData["idSolicitud"] = id;
            return View(solicitud);
        }

        // POST: Usuario/Edit/5

        public ActionResult CambioEstado(int id, String cambioEstado)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                SolicitudCEN solicitudCEN = new SolicitudCEN();
                if (cambioEstado == "Aceptar")
                    solicitudCEN.Aceptar(id);
                else
                    solicitudCEN.Rechazar(id);

                TempData["bien"] = "Se a modificado correctamente el estado de la solicitud "+id;

                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id });
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar modificar la solicitud " + id;
                return RedirectToAction("Index");
            }
        }

        // GET: Solicitud/Delete/5
        public ActionResult Delete(int id)
        {

            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Solicitud solicitud)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                SolicitudCEN solicitudCEN = new SolicitudCEN();
                SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);            
          
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadOID(solicitudEN.UsuarioSolicitante.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                ProyectoEN proyectoEN = proyectoCEN.ReadOID(solicitudEN.ProyectoSolicitado.Id);

                TempData["bien"] = "Se a borrado correctamente la solicitud del usuario " + usuarioEN.Nick + " en el proyecto " + proyectoEN.Nombre;
                
                solicitudCEN.Destroy(id);                
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar borrar la solicitud";
                return RedirectToAction("Index"); 
            }
        }

        // GET: Solicitud/Filtro
        public ActionResult FiltroUsuarioProyecto(int? pag)
        {
            return RedirectToAction("Index");
        }
        // POST: Solicitud/Filtro
        [HttpPost]
        public ActionResult FiltroUsuarioProyectoEstado(int? pag, FormCollection filtro)
        {

            if (filtro == null)
            {   
                //Falta el mensajito de pagina no encontraada
                return RedirectToAction("Index");
            }

            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            MensajeCAD solicitudCAD = new MensajeCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            SolicitudCEN solicitudCEN = new SolicitudCEN();

            ArrayList listaEstados = new ArrayList();
            listaEstados.Add("Todos");
            listaEstados.Add("Pendiente");
            listaEstados.Add("Aceptada");
            listaEstados.Add("Rechazada");
            ViewData["estados"] = listaEstados;

            IList<SolicitudEN> listaSolicitudes = new List<SolicitudEN>();
            IList<SolicitudEN> aux = new List<SolicitudEN>();

            listaSolicitudes = solicitudCEN.ReadAll(0, -1);
            aux = solicitudCEN.ReadAll(0, -1);

            if (filtro["proyecto"] != "")
            {
                //Optenemos el Id del proyecto por el que queremos filtrar               
                ProyectoEN proyectoEN = proyectoCEN.ReadNombre(filtro["proyecto"]);
                if (proyectoEN == null)
                {
                    TempData["mal"] = "No existe ningun proyecto de nombre "+ filtro["proyecto"];
                    return RedirectToAction("Index");
                }
                //Eliminamos las solicitudes que no tengan ese proyecto
                foreach (SolicitudEN s in listaSolicitudes)
                {
                    if (s.ProyectoSolicitado.Id != proyectoEN.Id)
                    {
                        aux.Remove(s);
                    }
                }
                ViewData["filtro"] = filtro["proyecto"] + " (Proyecto) ";
            }
 
            if (filtro["usuario"] != "")
            {              
                //Optenemos el Id del usuario por el que queremos filtrar               
                UsuarioEN usuarioEN = usuarioCEN.ReadNick(filtro["usuario"]);
                //Eliminamos las solicitudes que no tengan ese usuario
                if (usuarioEN == null)
                {
                    TempData["mal"] = "No existe ningun usuario con el Nick "+ filtro["usuario"];
                    return RedirectToAction("Index");                   
                }
                foreach (SolicitudEN s in listaSolicitudes)
                {
                    if (s.UsuarioSolicitante.Id != usuarioEN.Id)
                    {
                        aux.Remove(s);
                    }
                }
                ViewData["filtro"] = ViewData["filtro"] + filtro["usuario"] + " (Usuario) ";
            }

            if (filtro["estado"] != "" && filtro["estado"] != "Todos")
            {
                //Eliminamos las solicitudes que no tengan ese estado
                foreach (SolicitudEN s in listaSolicitudes)
                {
                    if (s.Estado.ToString() != filtro["estado"])
                    {
                        aux.Remove(s);
                    }
                }
                ViewData["filtro"] = ViewData["filtro"] + filtro["estado"] + " (Estado) ";
            }

            listaSolicitudes = aux;

            //Paginacion
            int tamPag = 10;
            int numPags = (listaSolicitudes.Count - 1) / tamPag;
            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            int inicio = (int)pag * tamPag;
            numPags = (listaSolicitudes.Count - 1) / tamPag;
            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;
            ViewData["numeroPaginas"] = numPags;

            IEnumerable<Solicitud> solicitudes = new AssemblerSolicitud().ConvertListENToModel(listaSolicitudes).ToList();
            SessionClose();
            return View(solicitudes);

        }
    }
}
