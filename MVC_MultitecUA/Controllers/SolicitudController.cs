using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
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

            return View(listaSolicitudes);
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int id)
        {
            SolicitudCEN solicitudCEN = new SolicitudCEN();
            SolicitudEN SolicitudEN = solicitudCEN.ReadOID(id);
            return View(SolicitudEN);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
            SolicitudEN solicitudEN = new SolicitudEN();
            return View(solicitudEN);
        }

        // POST: Solicitud/Create
        [HttpPost]
        public ActionResult Create(SolicitudEN solicitudEN)
        {
            try
            {
                SolicitudCEN solicitudCEN = new SolicitudCEN();
                solicitudCEN.New_(solicitudEN.UsuarioSolicitante.Id, solicitudEN.ProyectoSolicitado.Id);
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
            return View(solicitudEN);
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
