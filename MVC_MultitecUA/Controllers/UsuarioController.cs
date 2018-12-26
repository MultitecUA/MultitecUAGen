using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1).ToList();
            return View(listaUsuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            return View(usuarioEN);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            UsuarioEN usuarioEN = new UsuarioEN();
            return View(usuarioEN);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioEN usuarioEN)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.New_(usuarioEN.Nombre,usuarioEN.Password,usuarioEN.Foto,usuarioEN.Email,usuarioEN.Nick);
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
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            return View(usuarioEN);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioEN usuarioEN)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.Modify(id, usuarioEN.Nombre, usuarioEN.Password,usuarioEN.Email,usuarioEN.Nick,usuarioEN.Foto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult ChangeRol(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            return View(usuarioEN);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult ChangeRol(int id, UsuarioEN usuarioEN)
        {
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.CambiarRol(id, usuarioEN.Rol);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Usuario/ForNick/5
        public ActionResult ForNick(UsuarioEN usuarioEN)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> listaUsuarios = usuarioCEN.DameUsuariosPorNick(usuarioEN.Nick);
            return View(listaUsuarios);
        }

        public ActionResult Delete(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            return View(usuarioEN);
        }

        // POST: Solicitud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SolicitudEN solicitudEN)
        {
            try
            {
                UsuarioCP usuarioCP = new UsuarioCP();
                usuarioCP.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
