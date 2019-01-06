using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class NotificacionUsuarioController : BasicController
    {
        // GET: NotificacionUsuario
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            return RedirectToAction("NoLeidas");
        }

        public ActionResult MisNotificaciones()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            int OIDusuario = usuarioCEN.ReadNick(Session["usuario"].ToString()).Id;

            IList<NotificacionUsuarioEN> misNotificaciones = notificacionUsuarioCEN.DameNotificacionesPorUsuario(OIDusuario);
            IList<NotificacionUsuarioEN> noLeidas = notificacionUsuarioCEN.DameNotificacionesNoLeidasPorUsuario(OIDusuario);

            ViewData["notificaciones"] = misNotificaciones.Count;
            ViewData["NoLeidas"] = noLeidas.Count;

            return View(misNotificaciones);
        }

        public ActionResult NoLeidas()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            int OIDusuario = usuarioCEN.ReadNick(Session["usuario"].ToString()).Id;

            IList<NotificacionUsuarioEN> misNotificaciones = notificacionUsuarioCEN.DameNotificacionesNoLeidasPorUsuario(OIDusuario);

            ViewData["NoLeidas"] = misNotificaciones.Count;

            return View(misNotificaciones);
        }

        public ActionResult LeerNotificacion(int? OID, string origen) // OID -> 0 = todas, 1 = una
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (origen != "MisNotificaciones" && origen != "NoLeidas")
                return View("../Shared/Error");

            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();

            if (OID != null)
            {
                notificacionUsuarioCEN.LeerNotificacion((int)OID);
            }
            else
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                int OIDusuario = usuarioCEN.ReadNick(Session["usuario"].ToString()).Id;

                IList<NotificacionUsuarioEN> notificaciones = notificacionUsuarioCEN.DameNotificacionesPorUsuario(OIDusuario);

                foreach(NotificacionUsuarioEN notificacion in notificaciones)
                {
                    notificacionUsuarioCEN.LeerNotificacion(notificacion.Id);
                }
            }

            return RedirectToAction(origen);
        }

        public ActionResult BorrarNotificacion(int? OID, string origen) // OID -> 0 = todas, 1 = una
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (origen != "MisNotificaciones")
                return View("../Shared/Error");

            NotificacionUsuarioCP CP = new NotificacionUsuarioCP();

            if (OID != null)
            {
                CP.Destroy((int)OID);
            }
            else
            {
                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                int OIDusuario = usuarioCEN.ReadNick(Session["usuario"].ToString()).Id;

                IList<NotificacionUsuarioEN> notificaciones = notificacionUsuarioCEN.DameNotificacionesPorUsuario(OIDusuario);

                foreach (NotificacionUsuarioEN notificacion in notificaciones)
                {
                    CP.Destroy(notificacion.Id);
                }
            }

            return RedirectToAction(origen);
        }
    }
}