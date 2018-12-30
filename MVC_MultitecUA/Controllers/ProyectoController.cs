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
    public class ProyectoController : BasicController
    {
        // GET: Proyecto
        public ActionResult Index(int? pag)
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

            return View(listaProyectos);
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int id)
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
            return View(proyectoEN);
        }

        // POST: Proyecto/AgregarCatPro
        [HttpPost]
        public ActionResult AgregarCatPro(int id, FormCollection formCollection)
        {
            if (formCollection["CategoriaPro"] != "")
            {
                int num = id;
                CategoriaProyectoCEN categoria = new CategoriaProyectoCEN();
                CategoriaProyectoEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaPro"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.AgregaCategoriasProyecto(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });
        }

        // POST: Proyecto/EliminarCatPro
        [HttpPost]
        public ActionResult EliminarCatPro(int id, FormCollection formCollection)
        {
            if (formCollection["CategoriaPro"] != "")
            {
                int num = id;
                CategoriaProyectoCEN categoria = new CategoriaProyectoCEN();
                CategoriaProyectoEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaPro"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.EliminaCategoriasProyecto(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });
        }

        // POST: Proyecto/AgregarCatUsu
        [HttpPost]
        public ActionResult AgregarCatUsu(int id, FormCollection formCollection)
        {
            if (formCollection["CategoriaUsu"] != "")
            {
                int num = id;
                CategoriaUsuarioCEN categoria = new CategoriaUsuarioCEN();
                CategoriaUsuarioEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaUsu"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.AgregaCategoriasUsuario(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });
        }

        // POST: Proyecto/EliminarCatUsu
        [HttpPost]
        public ActionResult EliminarCatUsu(int id, FormCollection formCollection)
        {
            if (formCollection["CategoriaUsu"] != "")
            {
                int num = id;
                CategoriaUsuarioCEN categoria = new CategoriaUsuarioCEN();
                CategoriaUsuarioEN categoriaEN = categoria.ReadNombre(formCollection["CategoriaUsu"]);
                List<int> categorias = new List<int>();

                categorias.Add(categoriaEN.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.EliminaCategoriasUsuario(num, categorias);
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Details", new { id });
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            ProyectoEN proyectoEN = new ProyectoEN();
            return View(proyectoEN);
        }

        // POST: Proyecto/Create
        [HttpPost]
        public ActionResult Create(ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.New_(proyectoEN.Nombre, proyectoEN.Descripcion, proyectoEN.UsuarioCreador.Id, proyectoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            ViewData["titulo"] = proyectoEN.Nombre;
            return View(proyectoEN);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                proyectoCP.Modify(id, proyectoEN.Nombre, proyectoEN.Descripcion, proyectoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            ViewData["titulo"] = proyectoEN.Nombre;
            return View(proyectoEN);
        }

        // POST: Proyecto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                proyectoCP.Destroy(id);
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

            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(id);
            ViewData["evento"] = eventoEN.Nombre;

            IList<ProyectoEN> listaProyectos = proyectoCEN.DameProyectosPorEvento(id);

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
            return View(listaProyectos);
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
            return View(listaProyectos);
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
            return View(listaProyectos);
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
            return View(listaProyectos);
        }

        // GET: Proyecto/ChangeEstado/5
        public ActionResult ChangeEstado(int id)
        {
            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);

            ArrayList listaEstados = new ArrayList();

            foreach (var a in Enum.GetNames(typeof(EstadoProyectoEnum)))
                listaEstados.Add(a);

            ViewData["istaEstados"] = listaEstados;
            ViewData["nombre"] = proyectoEN.Nombre;

            return View(proyectoEN);
        }

        // POST: Proyecto/ChangeEstado/5
        [HttpPost]
        public ActionResult ChangeEstado(int id, ProyectoEN proyectoEN)
        {
            try
            {
                ProyectoCEN proyectoCEN = new ProyectoCEN();
                proyectoCEN.CambiarEstado(id, proyectoEN.Estado);
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
            ProyectoCAD proyectoCAD = new ProyectoCAD(session);
            ProyectoCEN proyectoCEN = new ProyectoCEN(proyectoCAD);
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(id);
            EventoCEN eventoCEN = new EventoCEN();

            ArrayList listaEventosAgregar = new ArrayList();
            ArrayList listaEventosEliminar = new ArrayList();

            foreach (var a in eventoCEN.ReadAll(0,-1))
            {
                if (proyectoEN.EventosAsociados.Contains(a))
                    listaEventosEliminar.Add(a.Nombre);
                else
                    listaEventosAgregar.Add(a.Nombre);
            }


            ViewData["listaEventosAgregar"] = listaEventosAgregar;
            ViewData["listaEventosEliminar"] = listaEventosEliminar;
            ViewData["nombre"] = proyectoEN.Nombre;

            return View(proyectoEN);
        }

        // POST: Proyecto/AgregarEvento/5
        [HttpPost]
        public ActionResult AgregarEvento(int id, FormCollection formCollection)
        {
            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                EventoCEN eventoCEN = new EventoCEN();

                List<int> eventos = new List<int>();
                eventos.Add(eventoCEN.ReadNombre(formCollection["Evento"]).Id);

                proyectoCP.AgregaEventos(id, eventos);
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
            try
            {
                ProyectoCP proyectoCP = new ProyectoCP();
                EventoCEN eventoCEN = new EventoCEN();

                List<int> eventos = new List<int>();
                eventos.Add(eventoCEN.ReadNombre(formCollection["Evento"]).Id);

                proyectoCP.EliminaEventos(id, eventos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
