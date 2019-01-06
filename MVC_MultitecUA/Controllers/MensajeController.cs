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

            foreach (var a in Enum.GetNames(typeof(EstadoLecturaEnum)))
                listaEstados.Add(a);

            /*ArrayList listaBandeja = new ArrayList();
            listaBandeja.Add("");

            foreach (var a in Enum.GetNames(typeof(EstadoLecturaEnum)))
                listaBandeja.Add(a);*/

            ViewData["listaEstados"] = listaEstados;
            /*ViewData["listaBandejaAutor"] = listaBandeja;
            ViewData["listaBandejaReceptor"] = listaBandeja;*/

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

                TempData["bien"] = "El mensaje " + mensaje.Titulo + " se ha enviado correctamente.";
                return RedirectToAction("Details", new {id = mensajeId });
            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar crear el mensaje " + mensaje.Id;
                return RedirectToAction("Index");
            }
        }

        // GET: Mensaje/Create
        public ActionResult Crear()
        {
            MensajeModel mensajeModel = new MensajeModel();
            return View("./VistaUsuario/Crear", mensajeModel);
        }

        // POST: Mensaje/Create
        [HttpPost]
        public ActionResult Crear(MensajeModel mensaje, int id)
        {
            
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioENAutor = usuarioCEN.ReadNick(Session["usuario"].ToString());
                UsuarioEN usuarioENReceptor = usuarioCEN.ReadOID(id);

                MensajeCEN mensajeCEN = new MensajeCEN();
                int mensajeId = mensajeCEN.New_(mensaje.Titulo, mensaje.Cuerpo, usuarioENAutor.Id, usuarioENReceptor.Id, null);
                mensajeCEN.EnviarMensaje(mensajeId);
                MensajeEN mensajeEN = mensajeCEN.ReadOID(mensajeId);
                MensajeModel mensajeNuevo = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);

                TempData["bien"] = "El mensaje " + mensaje.Titulo + " se ha enviado correctamente.";
                return View("./VistaUsuario/Detalles", mensajeNuevo);
            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar crear el mensaje " + mensaje.Id;
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

            var estado = Enum.Parse(typeof(EstadoLecturaEnum), cambioEstado);
            MensajeCEN mensajeCEN = new MensajeCEN();
            mensajeCEN.CambiarEstado(id, (EstadoLecturaEnum)estado);

            if (Session["modoAdmin"]!=null && Session["modoAdmin"].ToString() != "" && Session["modoAdmin"].ToString() == "true")
            {

                try
                {
                    TempData["bien"] = "Se ha modificado correctamente el estado del mensaje " + id;
                    return RedirectToAction("Details", new { id = id });
                }
                catch
                {
                    TempData["mal"] = "Ocurrió un problema al intentar modificar el mensaje " + id;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                try
                {
                    TempData["bien2"] = "Se ha modificado correctamente el estado del mensaje";
                    return RedirectToAction("DetalleMensajeRecibido", new { id = id });
                }
                catch
                {
                    TempData["mal2"] = "Ocurrió un problema al intentar modificar el mensaje";
                    return RedirectToAction("DetalleMensajeRecibido", new { id = id });
                }
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

            var bandeja = Enum.Parse(typeof(BandejaMensajeEnum), cambioBandejaAutor);
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensaje = mensajeCEN.ReadOID(id);
            mensajeCEN.CambiarBandejaAutor(id, (BandejaMensajeEnum)bandeja);


            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() != "" && Session["modoAdmin"].ToString() == "true")
            {
                try
                {
                    if (cambioBandejaAutor != mensaje.BandejaAutor.ToString())
                    {
                        mensajeCEN.CambiarBandejaAutor(id, (BandejaMensajeEnum)bandeja);
                        TempData["bien"] = "Se ha movido correctamente el mensaje " + id + " a la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("Details", new { id = id });
                    }
                    else
                    {
                        TempData["regular"] = "El mensaje " + id + " ya está en la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("Index");

                    }
                }
                catch
                {
                    TempData["mal"] = "Ocurrió un problema al intentar mover el mensaje " + id + " de bandeja";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                try
                {
                    if (cambioBandejaAutor != mensaje.BandejaAutor.ToString())
                    {
                        mensajeCEN.CambiarBandejaAutor(id, (BandejaMensajeEnum)bandeja);
                        TempData["bien2"] = "Se ha movido correctamente el mensaje a la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("DetalleMensajeEnviado", new { id = id });
                    }
                    else
                    {
                        TempData["regular2"] = "El mensaje ya está en la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("DetalleMensajeEnviado", new { id = id });

                    }
                }
                catch
                {
                    TempData["mal2"] = "Ocurrió un problema al intentar mover el mensaje " + id + " de bandeja";
                    return RedirectToAction("MisMensajes");
                }

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

            var bandeja = Enum.Parse(typeof(BandejaMensajeEnum), cambioBandejaReceptor);
            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensaje = mensajeCEN.ReadOID(id);
            mensajeCEN.CambiarBandejaReceptor(id, (BandejaMensajeEnum)bandeja);


            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() != "" && Session["modoAdmin"].ToString() == "true")
            {
                try
                {
                    if (cambioBandejaReceptor != mensaje.BandejaReceptor.ToString())
                    {
                        mensajeCEN.CambiarBandejaReceptor(id, (BandejaMensajeEnum)bandeja);
                        TempData["bien"] = "Se ha movido correctamente el mensaje " + id + " a la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("Details", new { id = id });
                    }
                    else
                    {
                        TempData["regular"] = "El mensaje " + id + " ya está en la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("Index");

                    }
                }
                catch
                {
                    TempData["mal"] = "Ocurrió un problema al intentar mover el mensaje " + id + " de bandeja";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                try
                {
                    if (cambioBandejaReceptor != mensaje.BandejaReceptor.ToString())
                    {
                        mensajeCEN.CambiarBandejaReceptor(id, (BandejaMensajeEnum)bandeja);
                        TempData["bien2"] = "Se ha movido correctamente el mensaje a la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("DetalleMensajeRecibido", new { id = id });
                    }
                    else
                    {
                        TempData["regular2"] = "El mensaje ya está en la bandeja " + (BandejaMensajeEnum)bandeja;
                        return RedirectToAction("DetalleMensajeRecibido", new { id = id });

                    }
                }
                catch
                {
                    TempData["mal2"] = "Ocurrió un problema al intentar mover el mensaje " + id + " de bandeja";
                    return RedirectToAction("MisMensajes");
                }

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
                TempData["bien"] = "Se ha eliminado correctamente el mensaje " + id;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mal"] = "Ocurrió un problema al intentar eliminar el mensaje " + id;
                return RedirectToAction("Index");
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

            foreach (var a in Enum.GetNames(typeof(EstadoLecturaEnum)))
                listaEstados.Add(a);

            /*ArrayList listaBandeja = new ArrayList();
            listaBandeja.Add("");
            listaBandeja.Add("Activo");
            listaBandeja.Add("Archivado");
            listaBandeja.Add("Borrado");*/



            ViewData["listaEstados"] = listaEstados;
           /* ViewData["listaBandejaAutor"] = listaBandeja;
            ViewData["listaBandejaReceptor"] = listaBandeja;*/



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

                if (mensajesFiltrados.Count()==0)
                {
                    TempData["mal"] = "No existe ningún mensaje de título " + nombres["titulo"];
                    return RedirectToAction("Index");
                }

                ViewData["filtro"] = nombres["titulo"] + " (Proyecto) ";

            }

            if (nombres["NickAutor"] != "")
            {
               
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioAutor.Nick != nombres["NickAutor"])
                        mensajesFiltrados.Remove(mensaje);
                }

                if (mensajesFiltrados.Count() == 0)
                {
                    TempData["mal"] = "El usuario " + nombres["NickAutor"] + " no existe o no ha enviado ningún mensaje";
                    return RedirectToAction("Index");
                }

                ViewData["filtro"] = ViewData["filtro"] + nombres["NickAutor"] + " (Autor) ";
            }



            if (nombres["NickReceptor"] != "")
            {

                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioReceptor.Nick != nombres["NickReceptor"])
                        mensajesFiltrados.Remove(mensaje);
                }

                if (mensajesFiltrados.Count() == 0)
                {
                    TempData["mal"] = "El usuario " + nombres["NickReceptor"] + " no existe o no ha recibido ningún mensaje";
                    return RedirectToAction("Index");
                }

                ViewData["filtro"] = ViewData["filtro"] + nombres["NickReceptor"] + " (Receptor) ";
            }
            if (nombres["EstadoLectura"] != "")
            {
                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.EstadoLecutra.ToString() != nombres["EstadoLectura"])
                        mensajesFiltrados.Remove(mensaje);
                }

                if (mensajesFiltrados.Count() == 0)
                {
                    TempData["mal"] = "No hay ningún mensaje con el estado " + nombres["EstadoLectura"];
                    return RedirectToAction("Index");
                }

                ViewData["filtro"] = ViewData["filtro"] + nombres["EstadoLectura"] + " (Estado) ";
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

            IEnumerable<MensajeModel> mensajesConvertidos = new AssemblerMensajeModel().ConvertListENToModel(mensajesFiltrados).ToList();
            SessionClose();
            return View(mensajesConvertidos);

        }

        // GET: Mensaje/VistaUsuario/MisMensajes
        public ActionResult MisMensajes(int? pag)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            ArrayList Bandejas = new ArrayList();
            Bandejas.Add("Recibidos");
            Bandejas.Add("Enviados");

            ViewData["Bandejas"] = Bandejas;

            IList<MensajeEN> mensajesFiltrados = new List<MensajeEN>();
            IList<MensajeEN> aux = new List<MensajeEN>();
            mensajesFiltrados = mensajeCEN.ReadAll(0, -1);
            aux = mensajeCEN.ReadAll(0, -1);


            if (Session["usuario"].ToString() != "")
            {

                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioReceptor.Nick != Session["usuario"].ToString())
                        mensajesFiltrados.Remove(mensaje);
                }

                if (mensajesFiltrados.Count() == 0)
                    TempData["mal"] = "¡No tienes ningún mensaje!";

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

            IEnumerable<MensajeModel> mensajesConvertidos = new AssemblerMensajeModel().ConvertListENToModel(mensajesFiltrados).ToList();
            SessionClose();
            return View("./VistaUsuario/MisMensajes", mensajesConvertidos);
        }

        [HttpPost]
        public ActionResult FiltroUsuario(FormCollection nombres, int? pag)
        {

            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            String vista = "";

            ArrayList Bandejas = new ArrayList();
            

            IList<MensajeEN> mensajesFiltrados = new List<MensajeEN>();
            IList<MensajeEN> aux = new List<MensajeEN>();
            mensajesFiltrados = mensajeCEN.ReadAll(0, -1);
            aux = mensajeCEN.ReadAll(0, -1);


            if (nombres["Bandeja"] != "" && nombres["Bandeja"] == "Recibidos")
            {
                vista = "Recibidos";
                Bandejas.Add("Recibidos");
                Bandejas.Add("Enviados");

                ViewData["Bandejas"] = Bandejas;

                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioReceptor.Nick != Session["usuario"].ToString())
                        mensajesFiltrados.Remove(mensaje);
                }

                if (mensajesFiltrados.Count() == 0)
                {
                    TempData["mal"] = "¡No tienes ningún mensaje!";
                    return View("./VistaUsuario/MisMensajes"+vista);
                }

                if (nombres["titulo"] != "")
                {
                    foreach(MensajeEN mensaje in aux)
                    {
                        if (mensaje.Titulo != nombres["titulo"])
                            mensajesFiltrados.Remove(mensaje);
                    }
                    if (mensajesFiltrados.Count() == 0)
                    {
                        TempData["mal"] = "No se ha encontrado ningún mensaje recibido con ese título.";
                        return View("./VistaUsuario/MisMensajes"+vista);
                    }
                }
            }

            if (nombres["Bandeja"] != "" && nombres["Bandeja"] == "Enviados")
            {
                vista = "Enviados";
                Bandejas.Add("Enviados");
                Bandejas.Add("Recibidos");

                ViewData["Bandejas"] = Bandejas;

                foreach (MensajeEN mensaje in aux)
                {
                    if (mensaje.UsuarioAutor.Nick != Session["usuario"].ToString())
                        mensajesFiltrados.Remove(mensaje);
                }

                if (mensajesFiltrados.Count() == 0)
                {
                    TempData["mal"] = "¡No has enviado ningún mensaje!";
                    return View("./VistaUsuario/MisMensajes"+vista);
                }

                if (nombres["titulo"] != "")
                {
                    foreach (MensajeEN mensaje in aux)
                    {
                        if (mensaje.Titulo != nombres["titulo"])
                            mensajesFiltrados.Remove(mensaje);
                    }
                    if (mensajesFiltrados.Count() == 0)
                    {
                        TempData["mal"] = "No se ha encontrado ningún mensaje enviado con ese título.";
                        return View("./VistaUsuario/MisMensajes"+vista);
                    }
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


            IEnumerable<MensajeModel> mensajesConvertidos = new AssemblerMensajeModel().ConvertListENToModel(mensajesFiltrados).ToList();
            SessionClose();
            return View("./VistaUsuario/MisMensajes"+vista,mensajesConvertidos);

        }
        // GET: Solicitud/Details/5
        public ActionResult DetalleMensajeRecibido(int id)
        {

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            String cambioEstado = "Leido";
            var estado = Enum.Parse(typeof(EstadoLecturaEnum), cambioEstado);
            mensajeCEN.CambiarEstado(id, (EstadoLecturaEnum)estado);

            ArrayList listaBandeja = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(BandejaMensajeEnum)))
                listaBandeja.Add(a);

            ViewData["listaBandeja"] = listaBandeja;

            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            return View("./VistaUsuario/DetalleMensajeRecibido",mensaje);
        }
        // GET: Solicitud/Details/5
        public ActionResult DetalleMensajeEnviado(int id)
        {

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);

            ArrayList listaBandeja = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(BandejaMensajeEnum)))
                listaBandeja.Add(a);

            ViewData["listaBandeja"] = listaBandeja;

            MensajeModel mensaje = new AssemblerMensajeModel().ConvertENToModelUI(mensajeEN);
            return View("./VistaUsuario/DetalleMensajeEnviado", mensaje);
        }
    }
}