using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class MensajeController : BasicController
    {
        // GET: Mensaje
        public ActionResult Index()
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            IList<MensajeEN> listaMensajes = mensajeCEN.ReadAll(0, -1).ToList();
            return View(listaMensajes);
        }

        // GET: Mensaje/Details/5
        public ActionResult Details(int id)
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            return View(mensajeEN);
        }

        // GET: Mensaje/Create
        public ActionResult Create()
        {
            MensajeEN mensajeEN = new MensajeEN();
            return View(mensajeEN);
        }

        // POST: Mensaje/Create
        [HttpPost]
        public ActionResult Create(MensajeEN mensajeEN)
        {
            try
            {
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.New_(mensajeEN.Titulo, mensajeEN.Cuerpo, mensajeEN.UsuarioAutor.Id, mensajeEN.UsuarioReceptor.Id, mensajeEN.ArchivosAdjuntos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mensaje/Delete/5
        public ActionResult Delete(int id)
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            return View(mensajeEN);
        }

        // POST: Mensaje/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MensajeEN mensajeEN)
        {
            try
            {
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
