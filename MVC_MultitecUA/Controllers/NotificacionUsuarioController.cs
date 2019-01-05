using MultitecUAGenNHibernate.CEN.MultitecUA;
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

        public ActionResult LeerNotificacion(int OID, string origen)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (origen != "MisNotificaciones" && origen != "NoLeidas")
                return View("../Shared/Error");

            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
            notificacionUsuarioCEN.LeerNotificacion(OID);

            return RedirectToAction(origen);
        }
    }
}