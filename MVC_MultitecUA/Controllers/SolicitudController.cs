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
            SolicitudCEN solicitudCEN = new SolicitudCEN();

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
            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
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
            try
            {
                
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadNick(solicitud.Nick_Solicitante);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                ProyectoEN proyectoEN = proyectoCEN.ReadNombre(solicitud.Nombre_Proyecto);

                SolicitudCEN solicitudCEN = new SolicitudCEN();
                int solicitudId =  solicitudCEN.New_(usuarioEN.Id, proyectoEN.Id);

                solicitudCEN.EnviarSolicitud(solicitudId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);
            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            ViewData["idSolicitud"] = id;
            return View(solicitud);
        }

        // POST: Usuario/Edit/5
      
        public ActionResult CambioEstado(int id, String cambioEstado)
        {
            try
            {
                SolicitudCEN solicitudCEN = new SolicitudCEN();
                if (cambioEstado == "Aceptar")                
                solicitudCEN.Aceptar(id);                
                else                
                solicitudCEN.Rechazar(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Solicitud/Delete/5
        public ActionResult Delete(int id)
        {

            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN solicitudEN = solicitudCEN.ReadOID(id);

            Solicitud solicitud = new AssemblerSolicitud().ConvertENToModelUI(solicitudEN);
            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SolicitudEN solicitudEN)
        {
            try
            {
                SolicitudCEN solicitudCEN = new SolicitudCEN();
                solicitudCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
