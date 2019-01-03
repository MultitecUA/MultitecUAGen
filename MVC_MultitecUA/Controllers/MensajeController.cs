using MultitecUAGenNHibernate.CAD.MultitecUA;
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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

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

            ArrayList listaEstados = new ArrayList();
            listaEstados.Add("");
            listaEstados.Add("Leido");
            listaEstados.Add("NoLeido");

            ArrayList listaBandeja = new ArrayList();
            listaBandeja.Add("");
            listaBandeja.Add("Activo");
            listaBandeja.Add("Archivado");
            listaBandeja.Add("Borrado");

            ViewData["listaEstados"] = listaEstados;
            ViewData["listaBandejaAutor"] = listaBandeja;
            ViewData["listaBandejaReceptor"] = listaBandeja;

            IList<MensajeEN> listaMensajes = mensajeCEN.ReadAll(inicio, tamPag).ToList();
            IEnumerable<MensajeModel> mensajes = new AssemblerMensajeModel().ConvertListENToModel(listaMensajes).ToList();

            return View(mensajes);
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

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);

            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            return View(mensaje);
        }

        // GET: Mensaje/Create
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

            ViewData["listaNicks"] = listaNicks;

            MensajeModel mensajeModel = new MensajeModel();
            return View(mensajeModel);
        }

        // POST: Mensaje/Create
        [HttpPost]
        public ActionResult Create(MensajeModel mensaje)
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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            ViewData["idMensaje"] = id;
            return View(mensaje);
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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            ViewData["idMensaje"] = id;
            return View(mensaje);
        }

        // POST: Usuario/Edit/5
        public ActionResult CambioBandejaAutor(int id, String cambioBandejaAutor)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            ViewData["idMensaje"] = id;
            return View(mensaje);
        }


        // POST: Usuario/Edit/5
        public ActionResult CambioBandejaReceptor(int id, String cambioBandejaReceptor)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            return View(mensajeEN);
        }

        // POST: Mensaje/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MensajeEN mensajeEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

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

        [HttpPost]
        public ActionResult FiltroAutorReceptor(FormCollection nombres, int? pag)
        {
        
        if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
                
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            ArrayList listaEstados = new ArrayList();
            listaEstados.Add("");
            listaEstados.Add("Leido");
            listaEstados.Add("NoLeido");

            ArrayList listaBandeja = new ArrayList();
            listaBandeja.Add("");
            listaBandeja.Add("Activo");
            listaBandeja.Add("Archivado");
            listaBandeja.Add("Borrado");

            
            
            ViewData["listaEstados"] = listaEstados;
            ViewData["listaBandejaAutor"] = listaBandeja;
            ViewData["listaBandejaReceptor"] = listaBandeja;

            

            IList<MensajeEN> mensajesFiltrados = new List<MensajeEN>();
            IList<MensajeEN> aux = new List<MensajeEN>();
            mensajesFiltrados = mensajeCEN.ReadAll(0, -1);
            aux = mensajeCEN.ReadAll(0, -1);


            if (nombres["Titulo"] != "")
            {
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.Titulo != nombres["Titulo"])
                        mensajesFiltrados.Remove(mensaje);
                }
            }

            if (nombres["NickAutor"] != "")
            {
                foreach(MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioAutor.Nick != nombres["NickAutor"])
                        mensajesFiltrados.Remove(mensaje);
                }
            }
            if (nombres["NickReceptor"] != "")
            {
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioReceptor.Nick != nombres["NickReceptor"])
                        mensajesFiltrados.Remove(mensaje);
                }

            }
            if (nombres["EstadoLectura"] != "")
            {
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.EstadoLecutra.ToString() != nombres["EstadoLectura"])
                        mensajesFiltrados.Remove(mensaje);
                }

            }
            if (nombres["BandejaAutor"] != "")
            {
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.BandejaAutor.ToString() != nombres["BandejaAutor"])
                        mensajesFiltrados.Remove(mensaje);
                }

            }
            if (nombres["BandejaReceptor"] != "")
            {
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.BandejaReceptor.ToString() != nombres["BandejaReceptor"])
                        mensajesFiltrados.Remove(mensaje);
                }

            }
            
            int tamPag = 10;

            int numPags = (mensajesFiltrados.Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            /* if (nombres["NickAutor"] != "" && nombres["NickReceptor"] != "")
             {

                 UsuarioEN usuarioAutor = usuarioCEN.ReadNick(nombres["NickAutor"]);
                 //UsuarioEN usuarioReceptor = usuarioCEN.ReadNick(nombres["NickReceptor"]);

                 mensajesFiltrados = mensajeCEN.DameMensajesPorAutor(usuarioAutor.Id);

                 foreach(MensajeEN mensaje in mensajesFiltrados)
                 {
                     if(mensaje.UsuarioReceptor.Nick != nombres["NickReceptor"])
                     {
                         mensajesFiltrados.Remove(mensaje);
                     }

                 }
             }else if (nombres["NickAutor"] != "")
             {
                 UsuarioEN usuarioAutor = usuarioCEN.ReadNick(nombres["NickAutor"]);
                 mensajesFiltrados = mensajeCEN.DameMensajesPorAutor(usuarioAutor.Id);

             }else if (nombres["NickReceptor"] != "")
             {
                 UsuarioEN usuarioReceptor = usuarioCEN.ReadNick(nombres["NickReceptor"]);
                 mensajesFiltrados = mensajeCEN.DameMensajesPorReceptor(usuarioReceptor.Id);
             }
             else
                 mensajesFiltrados = mensajeCEN.ReadAll(0, -1);*/

            IEnumerable<MensajeModel> mensajesConvertidos = new AssemblerMensajeModel().ConvertListENToModel(mensajesFiltrados).ToList();
            SessionClose();
            return View(mensajesConvertidos);

        }
    }
}
