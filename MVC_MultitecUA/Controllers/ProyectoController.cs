using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class ProyectoController : BasicController
    {
        // GET: Proyecto
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            ProyectoCEN proyectoCEN = new ProyectoCEN();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["listaEstados"] = listaEstados;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasU"] = listaCategoriasUsuarios;

            ArrayList listaCategoriasProyectos = new ArrayList();
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            foreach (var a in categoriaProyectoCEN.ReadAll(0, -1))
                listaCategoriasProyectos.Add(a.Nombre);

            ViewData["listaCategoriasP"] = listaCategoriasProyectos;

            int tamPag = 10;

            int numPags = (proyectoCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<ProyectoEN> listaProyectos = proyectoCEN.ReadAll(inicio, tamPag).ToList();

            return View(listaProyectos);
        }

        // GET: Proyecto/MisProyectos/5
        public ActionResult MisProyectos(string nick)
        {
            if (Session["usuario"] == null && nick == null)
            {
                return RedirectToAction("Login", "Sesion");
            }
            IList<ProyectoEN> listaProyectos = new List<ProyectoEN>();

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(nick);

            if (usuarioEN != null)
            {
                int OID_usuario = usuarioEN.Id;
                ProyectoCEN proyectoCEN = new ProyectoCEN();



                listaProyectos = proyectoCEN.DameProyectosUsuarioPertenece(OID_usuario);
                
            }
            ViewData["titulo"] = "Proyectos en los que participa " + nick;

            return View("./VistaUsuario/MisProyectos", listaProyectos);
        }

        // GET: Proyecto/ProyectosPresentados/5
        public ActionResult ProyectosPresentados(int? pag)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["listaEstados"] = listaEstados;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasU"] = listaCategoriasUsuarios;

            ArrayList listaCategoriasProyectos = new ArrayList();
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            foreach (var a in categoriaProyectoCEN.ReadAll(0, -1))
                listaCategoriasProyectos.Add(a.Nombre);

            ViewData["listaCategoriasP"] = listaCategoriasProyectos;

            int tamPag = 10;

            int numPags = (proyectoCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<ProyectoEN> listaProyectos = proyectoCEN.ReadAll(inicio, tamPag).ToList();

            return View("./VistaUsuario/ProyectosPresentados", listaProyectos);
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            ArrayList listaCatesE = new ArrayList();
            ArrayList listaCatesA = new ArrayList();

            CategoriaUsuarioCEN categorias = new CategoriaUsuarioCEN();
            List<CategoriaUsuarioEN> cat = categorias.ReadAll(0, -1).ToList();

            foreach (CategoriaUsuarioEN a in cat)
            {
                if (!proyectoEN.CategoriasBuscadas.Contains(a))
                {
                    listaCatesA.Add(a.Nombre);
                }
                else
                {
                    listaCatesE.Add(a.Nombre);
                }
            }
            ViewData["listaCategoriasUsuarioAgregar"] = listaCatesA;
            ViewData["listaCategoriasUsuarioEliminar"] = listaCatesE;

            listaCatesE = new ArrayList();
            listaCatesA = new ArrayList();
            CategoriaProyectoCEN categoriasProyectos = new CategoriaProyectoCEN();
            List<CategoriaProyectoEN> catPro = categoriasProyectos.ReadAll(0, -1).ToList();

            foreach (CategoriaProyectoEN a in catPro)
            {
                if (!proyectoEN.CategoriasProyectos.Contains(a))
                {
                    listaCatesA.Add(a.Nombre);
                }
                else
                {
                    listaCatesE.Add(a.Nombre);
                }
            }
            ViewData["listaCategoriasProyectoAgregar"] = listaCatesA;
            ViewData["listaCategoriasProyectoEliminar"] = listaCatesE;

            ViewData["titulo"] = proyectoEN.Nombre;
            ViewData["creador"] = proyectoEN.UsuarioCreador.Nombre + " ("+ proyectoEN.UsuarioCreador.Nick+")";
            return View(proyectoEN);
        }

        // GET: Proyecto/Details/5
        public ActionResult Detalles(int id)
        {
            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            ArrayList listaCatesE = new ArrayList();
            ArrayList listaCatesA = new ArrayList();

            CategoriaUsuarioCEN categorias = new CategoriaUsuarioCEN();
            List<CategoriaUsuarioEN> cat = categorias.ReadAll(0, -1).ToList();

            foreach (CategoriaUsuarioEN a in cat)
            {
                if (!proyectoEN.CategoriasBuscadas.Contains(a))
                {
                    listaCatesA.Add(a.Nombre);
                }
                else
                {
                    listaCatesE.Add(a.Nombre);
                }
            }
            ViewData["listaCategoriasUsuarioAgregar"] = listaCatesA;
            ViewData["listaCategoriasUsuarioEliminar"] = listaCatesE;

            listaCatesE = new ArrayList();
            listaCatesA = new ArrayList();
            CategoriaProyectoCEN categoriasProyectos = new CategoriaProyectoCEN();
            List<CategoriaProyectoEN> catPro = categoriasProyectos.ReadAll(0, -1).ToList();

            foreach (CategoriaProyectoEN a in catPro)
            {
                if (!proyectoEN.CategoriasProyectos.Contains(a))
                {
                    listaCatesA.Add(a.Nombre);
                }
                else
                {
                    listaCatesE.Add(a.Nombre);
                }
            }
            ViewData["listaCategoriasProyectoAgregar"] = listaCatesA;
            ViewData["listaCategoriasProyectoEliminar"] = listaCatesE;

            ViewData["titulo"] = proyectoEN.Nombre;
            ViewData["creador"] = proyectoEN.UsuarioCreador.Nick;

            ArrayList listaUsuarios = new ArrayList();
            foreach (UsuarioEN u in proyectoEN.UsuariosModeradores)
                listaUsuarios.Add(u.Nick);
            if (listaUsuarios.Contains(Session["usuario"]))
            {
                ViewData["esModerador"] = "true";
            }
            ViewData["listaModeradores"] = listaUsuarios;

            listaUsuarios = new ArrayList();
            foreach (UsuarioEN u in proyectoEN.UsuariosParticipantes)
                listaUsuarios.Add(u.Nick);
            if (Session["usuario"] != null && !listaUsuarios.Contains(Session["usuario"]))
            {
                ViewData["noParticpante"] = "true";
            }
            ViewData["listaParticipantes"] = listaUsuarios;

            return View("./VistaUsuario/Detalles", proyectoEN);
        }

        // POST: Proyecto/AgregarCatPro
        [HttpPost]
        public ActionResult AgregarCatPro(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            if (formCollection["CategoriaPro"] != "")
            {
                int num = id;
                CategoriaProyectoCEN categoria = new CategoriaProyectoCEN();
                CategoriaProyectoEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaPro"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                
                proyectoCEN.AgregaCategoriasProyecto(num, categorias);
            }

            if (Session["modoAdmin"].ToString() == "false")
                return RedirectToAction("Detalles", new { id = proyectoEN.Id });
            else
                return RedirectToAction("Details", new { id });
        }

        // POST: Proyecto/EliminarCatPro
        [HttpPost]
        public ActionResult EliminarCatPro(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            if (formCollection["CategoriaPro"] != "")
            {
                int num = id;
                CategoriaProyectoCEN categoria = new CategoriaProyectoCEN();
                CategoriaProyectoEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaPro"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                proyectoCEN.EliminaCategoriasProyecto(num, categorias);                
            }

            if (Session["modoAdmin"].ToString() == "false")
                return RedirectToAction("Detalles", new { id = proyectoEN.Id });
            else
                return RedirectToAction("Details", new { id });
        }

        // POST: Proyecto/AgregarCatUsu
        [HttpPost]
        public ActionResult AgregarCatUsu(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            if (formCollection["CategoriaPro"] != "")
            {
                int num = id;
                CategoriaUsuarioCEN categoria = new CategoriaUsuarioCEN();
                CategoriaUsuarioEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaUsu"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                proyectoCEN.AgregaCategoriasUsuario(num, categorias);
            }

            if (Session["modoAdmin"].ToString() == "false")
                return RedirectToAction("Detalles", new { id = proyectoEN.Id });
            else
                return RedirectToAction("Details", new { id });
        }

        // POST: Proyecto/EliminarCatUsu
        [HttpPost]
        public ActionResult EliminarCatUsu(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            if (formCollection["CategoriaPro"] != "")
            {
                int num = id;
                CategoriaUsuarioCEN categoria = new CategoriaUsuarioCEN();
                CategoriaUsuarioEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaUsu"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                proyectoCEN.EliminaCategoriasUsuario(num, categorias);
            }

            if (Session["modoAdmin"].ToString() == "false")
                return RedirectToAction("Detalles", new { id = proyectoEN.Id });
            else
                return RedirectToAction("Details", new { id });
        }

        // GET: Proyecto/Create
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

            ViewData["ListaNicks"] = listaNicks;

            ProyectoEN proyectoEN = new ProyectoEN();
            return View(proyectoEN);
        }

        // POST: Proyecto/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();

                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadNick(formCollection["creador"]);

                IList<UsuarioEN> listaUsuarios = usuarioCEN.ReadAll(0, -1).ToList();
                ArrayList listaNicks = new ArrayList();
                foreach (var e in listaUsuarios)
                {
                    listaNicks.Add(e.Nick);
                }

                ViewData["ListaNicks"] = listaNicks;

                if (formCollection["Nombre"] == "" || formCollection["Descripcion"] == "")
                {
                    ViewData["proyectovacio"] = "vacio";
                    return View();
                }

                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                if (!pattern.IsMatch(formCollection["Nombre"]))
                {
                    ViewData["fomatonombreproyecto"] = "mal";
                    return View();
                }

                if (proyectoCEN.ReadNombre(formCollection["Nombre"]) != null)
                {
                    ViewData["nombreproyecto"] = "existe";
                    return View();
                }

                //VALIDANDO DESCRIPCRION
                pattern = new Regex("^.{5,200}$");
                if (!pattern.IsMatch(formCollection["Descripcion"].ToString()))
                {
                    ViewData["formatodescripproyecto"] = "mal";
                    return View();
                }

                int OID = proyectoCEN.New_(formCollection["Nombre"], formCollection["Descripcion"], usuarioEN.Id, null);
                TempData["proyectocreado"] = "Se ha creado el proyecto: "+formCollection["Nombre"];

                return RedirectToAction("Details/" + OID);
            }
            catch
            {
                ViewData["error"] = "Ha ocurrido un error al intentar crear.";
                return View();
            }
        }

        public ActionResult Crear()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoEN proyectoEN = new ProyectoEN();
            return View("./VistaUsuario/Crear",proyectoEN);
        }

        // POST: Proyecto/Crear
        [HttpPost]
        public ActionResult Crear(FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();

                UsuarioCEN usuarioCEN = new UsuarioCEN();
                UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

                if (formCollection["Nombre"] == "" || formCollection["Descripcion"] == "")
                {
                    ViewData["proyectovacio"] = "vacio";
                    return View();
                }

                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                if (!pattern.IsMatch(formCollection["Nombre"]))
                {
                    ViewData["fomatonombreproyecto"] = "mal";
                    return View();
                }

                if (proyectoCEN.ReadNombre(formCollection["Nombre"]) != null)
                {
                    ViewData["nombreproyecto"] = "existe";
                    return View();
                }

                //VALIDANDO DESCRIPCRION
                pattern = new Regex("^.{5,200}$");
                if (!pattern.IsMatch(formCollection["Descripcion"].ToString()))
                {
                    ViewData["formatodescripproyecto"] = "mal";
                    return View();
                }

                int OID = proyectoCEN.New_(formCollection["Nombre"], formCollection["Descripcion"], usuarioEN.Id, null);
                TempData["proyectocreado"] = "Se ha creado el proyecto: " + formCollection["Nombre"];

                IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosUsuarioPertenece(usuarioEN.Id);
                ViewData["titulo"] = "Proyectos en los que participas";

                return View("./VistaUsuario/MisProyectos", listaProyectos);
            }
            catch
            {
                ViewData["error"] = "Ha ocurrido un error al intentar crear.";
                return View();
            }
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            if (proyectoEN.UsuariosModeradores.Contains(usuarioEN) || Session["modoAdmin"].ToString() == "true")
            {
                ViewData["titulo"] = proyectoEN.Nombre;
                if (Session["modoAdmin"].ToString() == "false")
                    return View("./VistaUsuario/Modificar", proyectoEN);
            }

            return View(proyectoEN);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProyectoEN proyectoEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                ProyectoCEN proyectoCEN = new ProyectoCEN();

                if (proyectoEN.Nombre == "" || proyectoEN.Descripcion == "")
                {
                    ViewData["proyectovacio"] = "vacio";
                    return View();
                }

                //VALIDANDO NOMBRE
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                if (!pattern.IsMatch(proyectoEN.Nombre))
                {
                    ViewData["fomatonombreproyecto"] = "mal";
                    return View();
                }

                if (proyectoEN.Nombre != proyectoCEN.ReadOID(id).Nombre &&  proyectoCEN.ReadNombre(proyectoEN.Nombre) != null)
                {
                    ViewData["nombreproyecto"] = "existe";
                    return View();
                }

                //VALIDANDO DESCRIPCRION
                pattern = new Regex("^.{5,200}$");
                if (!pattern.IsMatch(proyectoEN.Descripcion.ToString()))
                {
                    ViewData["formatodescripproyecto"] = "mal";
                    return View();
                }

                proyectoCP.Modify(id, proyectoEN.Nombre, proyectoEN.Descripcion, proyectoEN.FotosProyecto);

                TempData["proyectoeditado"] = "Se ha editado el proyecto: " + proyectoEN.Nombre;
                
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id = proyectoEN.Id });
                else
                    return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            if (proyectoEN.UsuariosModeradores.Contains(usuarioEN) || Session["modoAdmin"].ToString() == "true")
            {
                ViewData["titulo"] = proyectoEN.Nombre;
                if (Session["modoAdmin"].ToString() == "false")
                    return View("./VistaUsuario/Borrar", proyectoEN);
            }

            return View(proyectoEN);

        }

        // POST: Proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProyectoEN proyectoEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                proyectoCP.Destroy(id);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("MisProyectos",new { nick = Session["usuario"] });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/ProyectosPorEvento/5
        public ActionResult ProyectosPorEvento(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(id);
            ViewData["evento"] = eventoEN.Nombre;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosPorEvento(id);

            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaProyectos);
            else
                return View("./VistaUsuario/ProyectosPorEvento", listaProyectos);
        }

        // GET: Proyecto/ProyectosUsuarioPertenece/5
        public ActionResult ProyectosUsuarioPertenece(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            ProyectoCEN proyectoCEN = new ProyectoCEN();

            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(id);
            ViewData["participante"] = usuarioEN.Nick;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosUsuarioPertenece(id);

            return View(listaProyectos);
        }

        //GET: Proyecto/ForNombre/5
        public ActionResult ForNombre(ProyectoEN proyectoEN)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["listaEstados"] = listaEstados;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasU"] = listaCategoriasUsuarios;

            ArrayList listaCategoriasProyectos = new ArrayList();
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            foreach (var a in categoriaProyectoCEN.ReadAll(0, -1))
                listaCategoriasProyectos.Add(a.Nombre);

            ViewData["listaCategoriasP"] = listaCategoriasProyectos;
            ViewData["titulo"] = proyectoEN.Nombre;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosPorNombre(proyectoEN.Nombre);
            if (Session["modoAdmin"]!= null && Session["modoAdmin"].ToString() == "true")
                return View(listaProyectos);
            else
                return View("./VistaUsuario/ProyectosPresentados",listaProyectos);
        }

        //GET: Proyecto/ForEstado/5
        public ActionResult ForEstado(ProyectoEN proyectoEN)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["listaEstados"] = listaEstados;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasU"] = listaCategoriasUsuarios;

            ArrayList listaCategoriasProyectos = new ArrayList();
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            foreach (var a in categoriaProyectoCEN.ReadAll(0, -1))
                listaCategoriasProyectos.Add(a.Nombre);

            ViewData["listaCategoriasP"] = listaCategoriasProyectos;
            ViewData["estado"] = proyectoEN.Estado;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosPorEstado(proyectoEN.Estado);
            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaProyectos);
            else
                return View("./VistaUsuario/ProyectosPresentados", listaProyectos);
        }

        //GET: Proyecto/ForCategoriaProyecto/5
        public ActionResult ForCategoriaProyecto(FormCollection formCollection)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["listaEstados"] = listaEstados;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasU"] = listaCategoriasUsuarios;

            ArrayList listaCategoriasProyectos = new ArrayList();
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            foreach (var a in categoriaProyectoCEN.ReadAll(0, -1))
                listaCategoriasProyectos.Add(a.Nombre);

            ViewData["listaCategoriasP"] = listaCategoriasProyectos;

            string nombre = formCollection["categoriaP"];

            int id = categoriaProyectoCEN.ReadNombre(nombre).Id;

            ViewData["categoria"] = nombre;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosPorCategoria(id);
            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaProyectos);
            else
                return View("./VistaUsuario/ProyectosPresentados", listaProyectos);
        }

        //GET: Proyecto/ForCategoriaUsuario/5
        public ActionResult ForCategoriaUsuario(FormCollection formCollection)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["listaEstados"] = listaEstados;

            ArrayList listaCategoriasUsuarios = new ArrayList();
            CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

            foreach (var a in categoriaUsuarioCEN.ReadAll(0, -1))
                listaCategoriasUsuarios.Add(a.Nombre);

            ViewData["listaCategoriasU"] = listaCategoriasUsuarios;

            ArrayList listaCategoriasProyectos = new ArrayList();
            CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

            foreach (var a in categoriaProyectoCEN.ReadAll(0, -1))
                listaCategoriasProyectos.Add(a.Nombre);

            ViewData["listaCategoriasP"] = listaCategoriasProyectos;

            string nombre = formCollection["categoriaU"];

            int id = categoriaUsuarioCEN.ReadNombre(nombre).Id;
            ViewData["categoria"] = nombre;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosPorCategoriaUsuario(id);
            if (Session["modoAdmin"] != null && Session["modoAdmin"].ToString() == "true")
                return View(listaProyectos);
            else
                return View("./VistaUsuario/ProyectosPresentados", listaProyectos);
        }

        // GET: Proyecto/ChangeEstado/5
        public ActionResult ChangeEstado(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            if (proyectoEN.UsuariosModeradores.Contains(usuarioEN) || Session["modoAdmin"].ToString() == "true")
            {
                ArrayList listaEstados = new ArrayList();

                foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                    listaEstados.Add(a);

                ViewData["istaEstados"] = listaEstados;
                ViewData["nombre"] = proyectoEN.Nombre;

                if (Session["modoAdmin"].ToString() == "false")
                    return View("./VistaUsuario/CambiarEstado",proyectoEN);
            }      

            return View(proyectoEN);
        }

        // POST: Proyecto/ChangeEstado/5
        [HttpPost]
        public ActionResult ChangeEstado(int id, ProyectoEN proyectoEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.CambiarEstado(id, proyectoEN.Estado);

                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id = proyectoEN.Id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/GestionEventos/5
        public ActionResult GestionEventos(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());

            EventoCAD eventoCAD = new EventoCAD(session);
            EventoCEN eventoCEN = new EventoCEN(eventoCAD);

            if (proyectoEN.UsuariosModeradores.Contains(usuarioEN) || Session["modoAdmin"].ToString() == "true")
            {
                ArrayList listaEventosAgregar = new ArrayList();
                ArrayList listaEventosEliminar = new ArrayList();

                foreach (var a in eventoCEN.ReadAll(0, -1))
                {
                    if (proyectoEN.EventosAsociados.Contains(a))
                        listaEventosEliminar.Add(a.Nombre);
                    else
                        listaEventosAgregar.Add(a.Nombre);
                }


                ViewData["listaEventosAgregar"] = listaEventosAgregar;
                ViewData["listaEventosEliminar"] = listaEventosEliminar;
                ViewData["nombre"] = proyectoEN.Nombre;

                if (Session["modoAdmin"].ToString() == "false")
                    return View("./VistaUsuario/GestionEventos", proyectoEN);
            }

            return View(proyectoEN);
        }

        // POST: Proyecto/AgregarEvento/5
        [HttpPost]
        public ActionResult AgregarEvento(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                EventoCEN eventoCEN = new EventoCEN();

                List<int> eventos = new List<int>();
                eventos.Add(eventoCEN.ReadNombre(formCollection["Evento"]).Id);

                proyectoCP.AgregaEventos(id, eventos);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Proyecto/EliminarEvento/5
        [HttpPost]
        public ActionResult EliminarEvento(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                EventoCEN eventoCEN = new EventoCEN();

                List<int> eventos = new List<int>();
                eventos.Add(eventoCEN.ReadNombre(formCollection["Evento"]).Id);

                proyectoCP.EliminaEventos(id, eventos);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/GestionParticipantes/5
        public ActionResult GestionParticipantes(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());


            if (proyectoEN.UsuariosModeradores.Contains(usuarioEN) || Session["modoAdmin"].ToString() == "true")
            {
                ArrayList listaUsuariosAgregar = new ArrayList();
                ArrayList listaUsuariosEliminar = new ArrayList();

                foreach (var a in usuarioCEN.ReadAll(0, -1))
                {
                    if (proyectoEN.UsuariosParticipantes.Contains(a))
                        listaUsuariosEliminar.Add(a.Nick);
                    else
                        listaUsuariosAgregar.Add(a.Nick);
                }


                ViewData["listaUsuariosAgregar"] = listaUsuariosAgregar;
                ViewData["listaUsuariosEliminar"] = listaUsuariosEliminar;
                ViewData["nombre"] = proyectoEN.Nombre;

                if (Session["modoAdmin"].ToString() == "false")
                    return View("./VistaUsuario/GestionParticipantes", proyectoEN);
            }

            return View(proyectoEN);
        }

        // POST: Proyecto/AgregarParticipante/5
        [HttpPost]
        public ActionResult AgregarParticipante(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                UsuarioCEN usuarioCEN = new UsuarioCEN();

                List<int> usuarios = new List<int>();
                usuarios.Add(usuarioCEN.ReadNick(formCollection["Participante"]).Id);

                proyectoCP.AgregaParticipantes(id, usuarios);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Proyecto/EliminarParticipante/5
        [HttpPost]
        public ActionResult EliminarParticipante(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                UsuarioCEN usuarioCEN = new UsuarioCEN();

                List<int> usuarios = new List<int>();
                usuarios.Add(usuarioCEN.ReadNick(formCollection["Participante"]).Id);

                proyectoCP.EliminaParticipantes(id, usuarios);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/GestionParticipantes/5
        public ActionResult GestionModeradores(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
            UsuarioEN usuarioEN = usuarioCEN.ReadNick(Session["usuario"].ToString());


            if (proyectoEN.UsuariosModeradores.Contains(usuarioEN) || Session["modoAdmin"].ToString() == "true")
            {
                ArrayList listaUsuariosAgregar = new ArrayList();
                ArrayList listaUsuariosEliminar = new ArrayList();

                foreach (var a in usuarioCEN.ReadAll(0, -1))
                {
                    if (proyectoEN.UsuariosModeradores.Contains(a))
                        listaUsuariosEliminar.Add(a.Nick);
                    else if (proyectoEN.UsuariosParticipantes.Contains(a))
                        listaUsuariosAgregar.Add(a.Nick);
                }


                ViewData["listaUsuariosAgregar"] = listaUsuariosAgregar;
                ViewData["listaUsuariosEliminar"] = listaUsuariosEliminar;
                ViewData["nombre"] = proyectoEN.Nombre;

                if (Session["modoAdmin"].ToString() == "false")
                    return View("./VistaUsuario/GestionModeradores", proyectoEN);
            }

            return View(proyectoEN);
        }

        // POST: Proyecto/AgregarModerador/5
        [HttpPost]
        public ActionResult AgregarModerador(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                UsuarioCEN usuarioCEN = new UsuarioCEN();

                List<int> usuarios = new List<int>();
                usuarios.Add(usuarioCEN.ReadNick(formCollection["Moderador"]).Id);

                proyectoCP.AgregaModeradores(id, usuarios);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Proyecto/EliminarModerador/5
        [HttpPost]
        public ActionResult EliminarModerador(int id, FormCollection formCollection)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                UsuarioCEN usuarioCEN = new UsuarioCEN();

                List<int> usuarios = new List<int>();
                usuarios.Add(usuarioCEN.ReadNick(formCollection["Moderador"]).Id);

                proyectoCP.EliminaModeradores(id, usuarios);
                if (Session["modoAdmin"].ToString() == "false")
                    return RedirectToAction("Detalles", new { id });
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
