using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class SesionController : Controller
    {
        // GET: Sesion/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Sesion/Login
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(formCollection["nick"]);
            if (usuarioEN != null)
            {
                int id = usuarioEN.Id;

                if (usuarioCEN.Login(id, formCollection["pass"]) != "")
                {
                    Session["usuario"] = formCollection["nick"];

                    if (usuarioEN.Rol == RolUsuarioEnum.Administrador)
                        Session["esAdmin"] = "true";
                    else
                        Session["esAdmin"] = "false";

                    Session["modoAdmin"] = "false";
                }
            }
            return View();
        }

        // GET: Sesion/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return View();
        }

        // GET: Sesion/Adminin
        public ActionResult Adminin()
        {
            if (Session["esAdmin"] != null && Session["esAdmin"].ToString() == "true")
                Session["modoAdmin"] = "true";
            return View();
        }

        // GET: Sesion/Adminout
        public ActionResult Adminout()
        {
            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() == "true")
                Session["modoAdmin"] = "false";
            return View();
        }
    }
}