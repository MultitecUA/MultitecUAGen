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

        // GET: Solicitud/Details
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
                //No crear usuarios nuevos si ya existe una solicitud aceptada
                
                foreach (SolicitudEN e in solicitudCEN.DameSolicidudesPorUsuarioYProyecto(proyectoEN.Id, usuarioEN.Id) )
                {
                    if (e.Estado.ToString() == "Pendiente" || e.Estado.ToString() == "Aceptada")
                    {
                        denegar = true;
                        TempData["mal"] = "El proyecto " + proyectoEN.Nombre + " ya tiene una solicitud Pendiente o Aceptada del usuario " + usuarioEN.Nick;
                    }
                }
                //Denegar si alguno de los proyectos en los que participa ese usuario es el proyecto que esta solicitando participar
                foreach (UsuarioEN e in usuarioCEN.DameParticipantesProyecto(proyectoEN.Id))
                {
                    if (e.Id == usuarioEN.Id)
                    {
                        denegar = true;
                        TempData["mal"] = "El usuario "+ usuarioEN.Nick + " ya participa en el proyecto " + proyectoEN.Nombre;
                    }
                }

                if (denegar)
                {
                    
                    return RedirectToAction("Index");
                }
               if (!denegar)
                {
                    TempData["bien"] = "Se ha creado correctamente una solicitud del usuario " + usuarioEN.Nick + " al proyecto " + proyectoEN.Nombre;
                }

                int solicitudId = solicitudCEN.New_(usuarioEN.Id, proyectoEN.Id);
                solicitudCEN.EnviarSolicitud(solicitudId);

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar crear la solicitud ";
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

                TempData["bien"] = "Se a modificado correctamente el estado de la solicitud " + id;

                //return RedirectToAction("Index");
                return RedirectToAction("Details", new { id });
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar modificar la solicitud " + id;
                return RedirectToAction("Index");
            }
        }

        // GET: Solicitud/Delete
        public ActionResult Delete(int id)
        {

            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);

            //Cliente
            if (Session["modoAdmin"].ToString() == "false")
                return View("./VistaUsuario/DeleteCliente", solicitud);
            
            //Admin
            if (Session["esAdmin"].ToString() == "true")
            {
                if (Session["modoAdmin"].ToString() == "false")
                     Session["modoAdmin"] = "true";
            }
               
                return View(solicitud);

        }

        // POST: Solicitud/Delete
        [HttpPost]
        public ActionResult Delete(int id, Solicitud solicitud)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            try
            {
                           
          
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadOID(solicitudEN.UsuarioSolicitante.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                ProyectoEN proyectoEN = proyectoCEN.ReadOID(solicitudEN.ProyectoSolicitado.Id);

                TempData["bien"] = "Se ha borrado correctamente la solicitud del usuario " + usuarioEN.Nick + " en el proyecto " + proyectoEN.Nombre;
                
                solicitudCEN.Destroy(id);


                //Cliente
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("AdministrarSolicitudes", new { proyectoId = solicitudEN.ProyectoSolicitado.Id });

                //Admin
                if (Session["esAdmin"].ToString() == "true")
                {
                    if (Session["modoAdmin"].ToString() == "false")
                        Session["modoAdmin"] = "true";
                }
                return RedirectToAction("Index");


            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar borrar la solicitud";
                //Cliente
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("AdministrarSolicitudes", new { proyectoId = solicitudEN.ProyectoSolicitado.Id });

                //Admin
                if (Session["esAdmin"].ToString() == "true")
                {
                    if (Session["modoAdmin"].ToString() == "false")
                        Session["modoAdmin"] = "true";
                }
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
                    TempData["mal"] = "No existe ningún proyecto de nombre "+ filtro["proyecto"];
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
                    TempData["mal"] = "No existe ningún usuario con el Nick "+ filtro["usuario"];
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
            if (listaSolicitudes.Count <= 0)
            {
                TempData["mal"] = "No hay resultados con esos filtros";
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

        //*************************************
        //|||||||||||  VISTA CLIENTE  ||||||||
        //*************************************



        // GET: Solicitud/EnviarSolicitud/
        public ActionResult EnviarSolicitud(int proyectoId)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");


            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(proyectoId);

            //Comprobamos si ese usuario ya pertenece a ese proyecto
            bool pertenece = false;
            IList<ProyectoEN> proyectosALosQuePertenece = proyectoCEN.DameProyectosUsuarioPertenece(usuarioEN.Id);
            foreach (ProyectoEN e in proyectosALosQuePertenece)
            {   
                if(e.Id == proyectoId)
                {
                    pertenece = true;
                }
            }
            //Usuario pertenece al proyecto
            if (pertenece)
            {
                ViewData["titulo"] = "Ya perteneces al proyecto " + proyectoEN.Nombre;
                ViewData["esParticpante"] = "true";
            }
            //No pertenece al proyecto
            ViewData["titulo"] = "Desea participar en el proyecto "+proyectoEN.Nombre+" ?";

            //Comprobamos que no tenga una peticion pendiente en ese proyecto
            SolicitudCEN solicitudCEN = new SolicitudCEN();
            IList <SolicitudEN> solicitudesEN = solicitudCEN.DameSolicitudesPendientesPorProyectoDeUsuario(proyectoEN.Id,usuarioEN.Id);
            if (solicitudesEN.Count >=1)
            {
                ViewData["titulo"] = "Su solicitud esta pendiente, recibira una notificacion con la respuesta";
                ViewData["esParticpante"] = "true";
            }


            return View("./VistaUsuario/EnviarSolicitud", proyectoEN);
        }


        // POST: Solicitud/EnviarSolicitudPost/
        public ActionResult EnviarSolicitudPost(int proyectoId)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");


            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(proyectoId);

            SolicitudCEN solicitudCEN = new SolicitudCEN();

            try
            {
                SessionInitialize();
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                MensajeCAD solicitudCAD = new MensajeCAD(session);
               


                bool denegar = false;
                //No crear solicitud si ya existe una solicitud aceptada o pendiente
                foreach (SolicitudEN e in solicitudCEN.DameSolicidudesPorUsuarioYProyecto(proyectoEN.Id, usuarioEN.Id))
                {
                    if (e.Estado.ToString() == "Pendiente" || e.Estado.ToString() == "Aceptada")
                    {
                        denegar = true;
                    }
                }

                if (denegar)
                {
                    ViewData["mal"] = "El proyecto " + proyectoEN.Nombre + " ya tiene una solicitud Pendiente o Aceptada del usuario " + usuarioEN.Nick;
                    ViewData["esParticpante"] = "true";
                    SessionClose();
                    //return RedirectToAction("../Proyecto/Detalles", proyectoEN);
                    return View("./VistaUsuario/EnviarSolicitud", proyectoEN);
                }
                if (!denegar)
                {
                    ViewData["titulo"] = "Se envió correctamente una solicitud al proyecto " + proyectoEN.Nombre;
                    ViewData["esParticpante"] = "true";
                }
                //Creamos solicitud
                int solicitudId = solicitudCEN.New_(usuarioEN.Id, proyectoEN.Id);
                solicitudCEN.EnviarSolicitud(solicitudId);
                SessionClose();
                //return RedirectToAction("../Proyecto/Detalles", proyectoEN);
                return View("./VistaUsuario/EnviarSolicitud", proyectoEN);
            }
            catch
            {
                ViewData["mal"] = "Ocurrio un problema al intentar crear la solicitud ";
                SessionClose();
                //return RedirectToAction("../Proyecto/Detalles", proyectoEN);
                return View("./VistaUsuario/EnviarSolicitud", proyectoEN);
            }
                    
        }



        // GET: Solicitud/AdministrarSolicitudes       
        public ActionResult AdministrarSolicitudes(int proyectoId, int? pag)
        {
      
            
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            MensajeCAD solicitudCAD = new MensajeCAD(session);          
            SolicitudCEN solicitudCEN = new SolicitudCEN();

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(proyectoId);

          
            if (proyectoEN == null)
            {
                TempData["mal"] = "No existe ningún proyecto con la id "+proyectoId; 
                return RedirectToAction("../Proyecto/ProyectosPresentados");
            }

            ViewData["nombreProyecto"] = proyectoEN.Nombre;
            ViewData["proyectoId"] = proyectoId;
            

            IList<SolicitudEN> listaSolicitudes = new List<SolicitudEN>();
            IList<SolicitudEN> aux = new List<SolicitudEN>();

            listaSolicitudes = solicitudCEN.ReadAll(0, -1);
            aux = solicitudCEN.ReadAll(0, -1);

       
           
            //Eliminamos las solicitudes que no tengan ese proyecto
            foreach (SolicitudEN s in listaSolicitudes)
            {
                if (s.ProyectoSolicitado.Id != proyectoEN.Id)
                {
                    aux.Remove(s);
                }
            }
            ViewData["filtro"] = proyectoEN.Nombre + " (Proyecto) ";
            


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
            return View("./VistaUsuario/AdministrarSolicitudes", solicitudes);

        }



        // GET: Solicitud/DetailsCliente/5
        public ActionResult DetailsCliente(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
          
            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            return View("./VistaUsuario/DetailsCliente", solicitud);
        }



        // POST: Usuario/CambioEstadoCliente/
        public ActionResult CambioEstadoCliente(int id, String cambioEstado)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            /*if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";*/

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            try
            {
               
                if (cambioEstado == "Aceptar")
                    solicitudCEN.Aceptar(id);
                else
                    solicitudCEN.Rechazar(id);

                TempData["bien"] = "Se ha modificado correctamente el estado de la solicitud " + id;

                return RedirectToAction("AdministrarSolicitudes", new { proyectoId = solicitudEN.ProyectoSolicitado.Id });
            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar modificar la solicitud " + id;
                return RedirectToAction("AdministrarSolicitudes", new { proyectoId = solicitudEN.ProyectoSolicitado.Id });
            }
        }



        // POST: Usuario/CambioEstadoCliente2/
        public ActionResult CambioEstadoCliente2(int proyectoId, String cambioEstado)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ViewData["proyectoId"] = proyectoId;
            try
            {
               
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                ProyectoEN proyectoEN = proyectoCEN.ReadOID(proyectoId);

                if (proyectoEN == null)
                {
                    return RedirectToAction("./VistaUsuario/AdministrarSolicitudes", proyectoId);
                }

                SolicitudCEN solicitudCEN = new SolicitudCEN();
                SolicitudEN solicitudEN = new SolicitudEN();
                IList<SolicitudEN> listaSolicitudes = solicitudCEN.DameSolicitudesPendientesPorProyectoDeUsuario(proyectoId, usuarioEN.Id);

                if (listaSolicitudes.Count > 1)
                {
                    TempData["mal"] = "Ocurrió un problema al intentar modificar la solicitud";
                    return RedirectToAction("./VistaUsuario/AdministrarSolicitudes", proyectoId);
                }

                foreach (SolicitudEN e in listaSolicitudes){
                    solicitudEN = e;
                }
                

                if (cambioEstado == "Aceptar")
                    solicitudCEN.Aceptar(solicitudEN.Id);
                else
                    solicitudCEN.Rechazar(solicitudEN.Id);

                TempData["bien"] = "Se ha modificado correctamente el estado de la solicitud" + solicitudEN.Id;
                return RedirectToAction("./VistaUsuario/AdministrarSolicitudes", proyectoId);
            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar modificar la solicitud";
                return RedirectToAction("./VistaUsuario/AdministrarSolicitudes", new { proyectoId = proyectoId });
            }
        }














    }
}
