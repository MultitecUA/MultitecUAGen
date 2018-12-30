using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using MVC_MultitecUA.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class MensajeController : BasicController
    {
        // GET: Mensaje
        public ActionResult Index(int? pag)
        {
            MensajeCEN mensajeCEN = new MensajeCEN();

            int tamPag = 10;

            int numPags = (mensajeCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<MensajeEN> listaMensajes = mensajeCEN.ReadAll(inicio, tamPag).ToList();
            IEnumerable<MensajeModel> mensajes = new AssemblerMensajeModel().ConvertListENToModel(listaMensajes).ToList();

            return View(mensajes);
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int id)
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);

            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            return View(mensaje);
        }

        // GET: Mensaje/Create
        public ActionResult Create()
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1).ToList();
            ArrayList listaNicks = new ArrayList();
            foreach (var e in listaUsuarios)
            {
                listaNicks.Add(e.Nick);
            }

            ViewData["listaNicks"] = listaNicks;

            MensajeModel mensajeModel = new MensajeModel();
            return View(mensajeModel);
        }

        // POST: Mensaje/Create
        [HttpPost]
        public ActionResult Create(MensajeModel mensaje)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioENAutor = usuarioCEN.ReadNick(mensaje.NickAutor);
                UsuarioEN usuarioENReceptor = usuarioCEN.ReadNick(mensaje.NickReceptor);

                MensajeCEN mensajeCEN = new MensajeCEN();
                int mensajeId = mensajeCEN.New_(mensaje.Titulo, mensaje.Cuerpo, usuarioENAutor.Id, usuarioENReceptor.Id, null);
                mensajeCEN.EnviarMensaje(mensajeId);
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
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            ViewData["idMensaje"] = id;
            return View(mensaje);
        }

        // POST: Usuario/Edit/5
        public ActionResult CambioEstado(int id, String cambioEstado)
        {
            try
            {
                var estado = Enum.Parse(typeof(EstadoLecturaEnum), cambioEstado);
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.CambiarEstado(id,(EstadoLecturaEnum)estado);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult EditAutor(int id)
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            ViewData["idMensaje"] = id;
            return View(mensaje);
        }

        // POST: Usuario/Edit/5
        public ActionResult CambioBandejaAutor(int id, String cambioBandejaAutor)
        {
            try
            {
                var bandeja = Enum.Parse(typeof(BandejaMensajeEnum), cambioBandejaAutor);
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.CambiarBandejaAutor(id, (BandejaMensajeEnum)bandeja);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Usuario/Edit/5
        public ActionResult EditReceptor(int id)
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            ViewData["idMensaje"] = id;
            return View(mensaje);
        }
        // POST: Usuario/Edit/5
        public ActionResult CambioBandejaReceptor(int id, String cambioBandejaReceptor)
        {
            try
            {
                var bandeja = Enum.Parse(typeof(BandejaMensajeEnum), cambioBandejaReceptor);
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.CambiarBandejaReceptor(id, (BandejaMensajeEnum)bandeja);

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
