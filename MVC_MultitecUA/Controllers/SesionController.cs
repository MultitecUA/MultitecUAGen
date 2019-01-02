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
            // Mira si hay campos vacios
            if (formCollection["nick"] == "" || formCollection["pass"] == "")
            {
                ViewData["camposvacios"] = "vacios";
                return View();
            }

            //Si existia la clave, la quita para que no salga de nuevo
            //if (ViewData.ContainsKey("camposvacios"))
                //ViewData.Remove("composvacios");

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(formCollection["nick"]);

            //Mira si el nick existe
            if (usuarioEN == null)
            {
                ViewData["nonick"] = "mal";
                return View();
            }

            //Borro el tempdata porque el usuario existe
            //if (TempData.ContainsKey("nonick"))
                //TempData.Remove("noncik");

            int id = usuarioEN.Id;
            string token = usuarioCEN.Login(id, formCollection["pass"]);
            if ( token == null)
            {
                ViewData["contrasena"] = "mal";
                return View();
            }
            //if (TempData.ContainsKey("contrasena"))
                //TempData.Remove("contrasena");

            Session["usuario"] = formCollection["nick"];

            if (usuarioEN.Rol == RolUsuarioEnum.Administrador)
                Session["esAdmin"] = "true";
            else
                Session["esAdmin"] = "false";

            Session["modoAdmin"] = "false";
                
            
            //Esto redirige al inicio de usuario
            return RedirectToAction("Index","Home");
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
            return RedirectToAction("Index", "Home");
        }

        // GET: Sesion/Adminout
        public ActionResult Adminout()
        {
            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() == "true")
                Session["modoAdmin"] = "false";
            return RedirectToAction("Index", "Home");
        }
    }
}