using MultitecUAGenNHibernate.CAD.MultitecUA;
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
        public ActionResult Index(int? pag)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            ArrayList listaRoles = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(RolUsuarioEnum)))
                listaRoles.Add(a);

            ViewData["listaRoles"] = listaRoles;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))            
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasUsuarios"] = listaCategoriasUsuarios;

            int tamPag = 10;

            int numPags = (usuarioCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(inicio, tamPag).ToList();

            if (Session["usuario"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaUsuarios);
            else
                return View("./VistaUsuario/Listado", listaUsuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);

            ArrayList listaCatesE = new ArrayList();
            ArrayList listaCatesA = new ArrayList();
            CategoriaUsuarioCEN categorias = new CategoriaUsuarioCEN();
            List<CategoriaUsuarioEN> cat = categorias.ReadAll(0, -1).ToList();

            foreach (CategoriaUsuarioEN a in cat)
            {
                if (!usuarioEN.CategoriasUsuarios.Contains(a))
                {
                    listaCatesA.Add(a.Nombre);
                }
                else
                {
                    listaCatesE.Add(a.Nombre);
                }
            }
            ViewData["listaCategoriasAgregar"] = listaCatesA;
            ViewData["listaCategoriasEliminar"] = listaCatesE;
            ViewData["usuario"] = usuarioEN.Nick;

            return View(usuarioEN);
        }

        // GET: Usuario/Detalles/5
        public ActionResult Detalles(string nick)
        {
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(nick);

            ArrayList listaCatesE = new ArrayList();
            CategoriaUsuarioCEN categorias = new CategoriaUsuarioCEN();
            List<CategoriaUsuarioEN> cat = categorias.ReadAll(0, -1).ToList();

            foreach (CategoriaUsuarioEN a in cat)
            {
                if (usuarioEN.CategoriasUsuarios.Contains(a))
                {
                    listaCatesE.Add(a.Nombre);
                }
            }
            ViewData["listaCategoriasEliminar"] = listaCatesE;

            return View("./VistaUsuario/Detalles",usuarioEN);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioEN usuarioEN = new UsuarioEN();
            return View(usuarioEN);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioEN usuarioEN)
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
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            ViewData["usuario"] = usuarioEN.Nick;
            return View(usuarioEN);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioEN usuarioEN)
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
                if (usuarioEN.Password == null)
                    usuarioEN.Password = usuarioCEN.ReadOID(id).Password;
                usuarioCEN.Modify(id, usuarioEN.Nombre, usuarioEN.Password,usuarioEN.Email,usuarioEN.Nick,usuarioEN.Foto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Modificar/5
        public ActionResult Modificar()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());
            ViewData["usuario"] = usuarioEN.Nick;
            return View("./VistaUsuario/Modificar",usuarioEN);
        }

        // POST: Usuario/Modificar/5
        [HttpPost]
        public ActionResult Modificar(int id, FormCollection formCollection)
        {

            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
                UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);

                if (usuarioCEN.Login(id, formCollection["Password"]) != null)
                {

                    if (formCollection["newpass"] == "")
                    {
                        formCollection["newpass"] = formCollection["Password"];
                    }
                    usuarioCEN.Modify(id, formCollection["Nombre"], formCollection["newpass"], formCollection["Email"], formCollection["Nick"], formCollection["Foto"]);
                    if (formCollection["Nick"].ToString() != Session["usuario"].ToString())
                        Session["usuario"] = formCollection["Nick"];

                    ArrayList listaCatesE = new ArrayList();
                    CategoriaUsuarioCEN categorias = new CategoriaUsuarioCEN();
                    List<CategoriaUsuarioEN> cat = categorias.ReadAll(0, -1).ToList();

                    
                    foreach (CategoriaUsuarioEN a in cat)
                    {
                        if (usuarioEN.CategoriasUsuarios.Contains(a))
                        {
                            listaCatesE.Add(a.Nombre);
                        }
                    }
                    ViewData["listaCategoriasEliminar"] = listaCatesE;
                    return View("./VistaUsuario/Detalles", usuarioEN);
                }
                ViewData["error"] = "La contraseña introducida no es correcta";
                return View("./VistaUsuario/Modificar", usuarioEN);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/ChangeRol/5
        public ActionResult ChangeRol(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);

            ArrayList listaRoles = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(RolUsuarioEnum)))
                listaRoles.Add(a);

            ViewData["listaRoles"] = listaRoles;
            ViewData["usuario"] = usuarioEN.Nick;

            return View(usuarioEN);
        }

        // POST: Usuario/ChangeRol/5
        [HttpPost]
        public ActionResult ChangeRol(int id, UsuarioEN usuarioEN)
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

            ArrayList listaRoles = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(RolUsuarioEnum)))
                listaRoles.Add(a);

            ViewData["listaRoles"] = listaRoles;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasUsuarios"] = listaCategoriasUsuarios;
            ViewData["nick"] = usuarioEN.Nick;


            IList<UsuarioEN> listaUsuarios = usuarioCEN.DameUsuariosPorNick(usuarioEN.Nick);

            if (Session["usuario"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaUsuarios);
            else
                return View("VistaUsuario/ForNick", listaUsuarios);
        }

        //GET: Usuario/ForRol/5
        public ActionResult ForRol(UsuarioEN usuarioEN)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            ArrayList listaRoles = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(RolUsuarioEnum)))
                listaRoles.Add(a);

            ViewData["listaRoles"] = listaRoles;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasUsuarios"] = listaCategoriasUsuarios;
            ViewData["rol"] = usuarioEN.Rol;

            IList<UsuarioEN> listaUsuarios = usuarioCEN.DameUsuariosPorRol(usuarioEN.Rol);
            if (Session["usuario"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaUsuarios);
            else
                return View("./VistaUsuario/ForRol", listaUsuarios);
        }

        //GET: Usuario/ForCategoria/5
        public ActionResult ForCategoria(FormCollection formCollection)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            ArrayList listaRoles = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(RolUsuarioEnum)))
                listaRoles.Add(a);

            ViewData["listaRoles"] = listaRoles;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasUsuarios"] = listaCategoriasUsuarios;

            string nombre = formCollection["categoria"];

            int id = categoriaUsuarioCEN.ReadNombre(nombre).Id;
            ViewData["categoria"] = nombre;

            IList<UsuarioEN> listaUsuarios = usuarioCEN.DameUsuariosPorCategoria(id);
            if (Session["usuario"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaUsuarios);
            else
                return View("./VistaUsuario/ForCategoria", listaUsuarios);
        }

        // POST: Usuario/AgregarCat
        [HttpPost]
        public ActionResult AgregarCat(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (formCollection["Categoria"] != "")
            {
                int num = id;
                CategoriaUsuarioCEN categoria = new CategoriaUsuarioCEN();
                CategoriaUsuarioEN categoriaEN = categoria.ReadNombre(formCollection["Categoria"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.AgregaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });
        }

        // POST: Usuario/EliminarCat
        [HttpPost]
        public ActionResult EliminarCat(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (formCollection["Categoria"] != "")
            {
                int num = id;
                CategoriaUsuarioCEN categoria = new CategoriaUsuarioCEN();
                CategoriaUsuarioEN categoriaEN = categoria.ReadNombre(formCollection["Categoria"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.EliminaCategorias(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });
        }

        // GET: Solicitud/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            ViewData["usuario"] = usuarioEN.Nick;
            return View(usuarioEN);
        }

        // POST: Solicitud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SolicitudEN solicitudEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

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

        // GET: Usuario/UsuariosParticipantes/5
        public ActionResult UsuariosParticipantes(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCEN usuarioCEN = new UsuarioCEN();

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            ViewData["proyecto"] = proyectoEN.Nombre;

            IList<UsuarioEN> listaUsuarios = usuarioCEN.DameParticipantesProyecto(id);

            return View(listaUsuarios);
        }

        // GET: Usuario/UsuariosModeradores/5
        public ActionResult UsuariosModeradores(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            UsuarioCEN usuarioCEN = new UsuarioCEN();

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            ViewData["proyecto"] = proyectoEN.Nombre;

            IList<UsuarioEN> listaUsuarios = usuarioCEN.DameModeradoresProyecto(id);

            return View(listaUsuarios);
        }
    }
}
