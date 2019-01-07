using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult Create(UsuarioEN usuarioEN, HttpPostedFileBase file)
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


                string fileName = "", path = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    path = Path.Combine(Server.MapPath("~/Imagenes"), fileName);
                    if (!System.IO.File.Exists(path))
                        file.SaveAs(path);
                    file.SaveAs(path);
                    fileName = "/Imagenes/" + fileName;
                }



                if (usuarioEN.Nombre == null || usuarioEN.Nick == null || usuarioEN.Password == null || usuarioEN.Email == null)
                {
                    ViewData["CamposVacios"] = "No pueden haber campos vacíos, excepto por la foto.";
                    View();
                }


                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z áéíóúñç]{1,50}$");
                if (!pattern.IsMatch(usuarioEN.Nombre))
                {
                    ViewData["FormatoNombreUsuario"] = "mal";
                    return View();
                }

                //VALIDANDO CONTRASENA
                pattern = new Regex("^[A-Za-z.-_0-9]{4,15}$");
                if (!pattern.IsMatch(usuarioEN.Password))
                {
                    ViewData["FormatoContrasenaUsuario"] = "De 4 a 15 caracteres. Letras del alfabeto inglés, números y símbolos . - _";
                    return View();
                }


                //VALIDANDO EMAIL
                pattern = new Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$");
                if (!pattern.IsMatch(usuarioEN.Email))
                {
                    ViewData["FormatoEmailUsuario"] = "El formato del email no es correcto. Ej: ejemplo@gmail.com";
                    return View();
                }

                //VALIDANDO NICK
                pattern = new Regex("^[A-Za-z.-_]{4,15}$");
                if (!pattern.IsMatch(usuarioEN.Nick))
                {
                    ViewData["FormatoNickUsuario"] = "De 4 a 15 caracteres. Solo letras del alfabeto inglés. Se aceptan los simbolos .-_";
                    return View();
                }
                if (usuarioCEN.ReadNick(usuarioEN.Nick) != null)
                {
                    ViewData["NickExiste"] = "Este nick ya existe";
                    return View();
                }



                int idU;
                if (fileName != "")
                {
                    idU = usuarioCEN.New_(usuarioEN.Nombre, usuarioEN.Password, fileName, usuarioEN.Email, usuarioEN.Nick);
                }
                else
                {
                    idU = usuarioCEN.New_(usuarioEN.Nombre, usuarioEN.Password, "/Imagenes/NoFoto.png", usuarioEN.Email, usuarioEN.Nick);
                }
                TempData["usuariocreado"] = "si";
                return RedirectToAction("Details/" + idU);
            }
            catch
            {
                ViewData["error"] = "Ha ocurrido un error y no se ha podido crear el usuario";
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
        public ActionResult Edit(int id, UsuarioEN usuarioEN, HttpPostedFileBase file)
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

                string fileName = "", path = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    path = Path.Combine(Server.MapPath("~/Imagenes"), fileName);
                    if (!System.IO.File.Exists(path))
                        file.SaveAs(path);
                    file.SaveAs(path);
                    fileName = "/Imagenes/" + fileName;
                }

                if (usuarioEN.Nombre == null || usuarioEN.Nick == null || usuarioEN.Email == null)
                {
                    ViewData["CamposVacios"] = "El nombre, nick o email no pueden ser vacíos.";
                    View();
                }


                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z áéíóúñç]{1,50}$");
                if (!pattern.IsMatch(usuarioEN.Nombre))
                {
                    ViewData["FormatoNombreUsuario"] = "mal";
                    return View();
                }

                //VALIDANDO CONTRASENA
                pattern = new Regex("^[A-Za-z.-_0-9]{4,15}$");
                if (usuarioEN.Password != null && !pattern.IsMatch(usuarioEN.Password))
                {
                    ViewData["FormatoContrasenaUsuario"] = "De 4 a 15 caracteres. Letras del alfabeto inglés, números y símbolos . - _";
                    return View();
                }


                //VALIDANDO EMAIL
                pattern = new Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$");
                if (!pattern.IsMatch(usuarioEN.Email))
                {
                    ViewData["FormatoEmailUsuario"] = "El formato del email no es correcto. Ej: ejemplo@gmail.com";
                    return View();
                }

                //VALIDANDO NICK
                pattern = new Regex("^[A-Za-z.-_]{4,15}$");
                UsuarioEN validando = usuarioCEN.ReadNick(usuarioEN.Nick);
                if (validando == null)
                {
                    if (!pattern.IsMatch(usuarioEN.Nick))
                    {
                        ViewData["FormatoNickUsuario"] = "De 4 a 15 caracteres. Solo letras del alfabeto inglés. Se aceptan los simbolos .-_";
                        return View();
                    }
                    if (usuarioCEN.ReadNick(usuarioEN.Nick) != null)
                    {
                        ViewData["NickExiste"] = "Este nick ya existe";
                        return View();
                    }
                    Session["usuario"] = usuarioEN.Nick;
                }

                if (usuarioEN.Password == null)
                    usuarioEN.Password = usuarioCEN.ReadOID(id).Password;

                TempData["usuarioeditado"] = "si";
                if (fileName != "")
                {
                    usuarioCEN.Modify(id, usuarioEN.Nombre, usuarioEN.Password, usuarioEN.Email, usuarioEN.Nick, fileName);
                }
                else
                {
                    usuarioCEN.Modify(id, usuarioEN.Nombre, usuarioEN.Password, usuarioEN.Email, usuarioEN.Nick, "/Imagenes/NoFoto.png");
                }

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                ViewData["error"] = "Ha ocurrido un error y no se ha podido editar el usuario.";
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
        public ActionResult Modificar(int id, FormCollection formCollection, HttpPostedFileBase file)
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

                    string fileName = "", path = "";
                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        path = Path.Combine(Server.MapPath("~/Imagenes"), fileName);
                        if (!System.IO.File.Exists(path))
                            file.SaveAs(path);
                        file.SaveAs(path);
                        fileName = "/Imagenes/" + fileName;
                    }

                    if (formCollection["Nombre"] == "" || formCollection["Nick"] == "" || formCollection["Email"] == "")
                    {
                        ViewData["CamposVacios"] = "El nombre, nick o email no pueden ser vacíos.";
                        return View("./VistaUsuario/Modificar", usuarioEN);
                    }


                    //VALIDANDO NOMBRE
                    Regex pattern = new Regex("^[A-Za-z áéíóúñç]{1,50}$");
                    if (!pattern.IsMatch(formCollection["Nombre"]))
                    {
                        ViewData["FormatoNombreUsuario"] = "mal";
                        return View("./VistaUsuario/Modificar", usuarioEN);
                    }

                    //VALIDANDO CONTRASENA
                    pattern = new Regex("^[A-Za-z.-_0-9]{4,15}$");
                    if (formCollection["newpass"] == "")
                    {
                        formCollection["newpass"] = formCollection["Password"];
                    }
                    else if (!pattern.IsMatch(formCollection["newpass"]))
                    {
                        ViewData["FormatoContrasenaUsuario"] = "De 4 a 15 caracteres. Letras del alfabeto inglés, números y símbolos . - _";
                        return View("./VistaUsuario/Modificar", usuarioEN);
                    }


                    //VALIDANDO EMAIL
                    pattern = new Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$");
                    if (!pattern.IsMatch(formCollection["Email"]))
                    {
                        ViewData["FormatoEmailUsuario"] = "El formato del email no es correcto. Ej: ejemplo@gmail.com";
                        return View("./VistaUsuario/Modificar", usuarioEN);
                    }

                    //VALIDANDO NICK
                    pattern = new Regex("^[A-Za-z.-_]{4,15}$");
                    UsuarioEN validando = usuarioCEN.ReadNick(usuarioEN.Nick);
                    if (validando == null)
                    {
                        if (!pattern.IsMatch(formCollection["Nick"]))
                        {
                            ViewData["FormatoNickUsuario"] = "De 4 a 15 caracteres. Solo letras del alfabeto inglés. Se aceptan los simbolos .-_";
                            return View("./VistaUsuario/Modificar", usuarioEN);
                        }
                        if (usuarioCEN.ReadNick(formCollection["Nick"]) != null)
                        {
                            ViewData["NickExiste"] = "Este nick ya existe";

                            return View("./VistaUsuario/Modificar", usuarioEN);
                        }
                        Session["usuario"] = usuarioEN.Nick;
                    }


                    if (fileName != "")
                    {
                        usuarioCEN.Modify(id, formCollection["Nombre"], formCollection["newpass"], formCollection["Email"], formCollection["Nick"], fileName);
                    }
                    else
                    {
                        usuarioCEN.Modify(id, formCollection["Nombre"], formCollection["newpass"], formCollection["Email"], formCollection["Nick"], "/Imagenes/NoFoto.png");

                    }

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
                    TempData["Modificar"] = "Tu perfil ha modificado";
                    return View("./VistaUsuario/Detalles", usuarioEN);
                }
                ViewData["error"] = "La contraseña introducida no es correcta";
                return View("./VistaUsuario/Modificar", usuarioEN);
            }
            catch
            {
                ViewData["error2"] = "Ha ocurrido un error y no se ha podido editar el usuario.";
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
