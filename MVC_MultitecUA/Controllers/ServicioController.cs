using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class ServicioController : BasicController
    {
        // GET: Servicio
        public ActionResult Index()
        {
            ServicioCEN servicioCEN = new ServicioCEN();
            IList<ServicioEN> listaServicios = servicioCEN.ReadAll(0, -1).ToList();
            return View(listaServicios);
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int id)
        {
            ServicioCEN servicioCEN = new ServicioCEN();
            ServicioEN servicioEN = servicioCEN.ReadOID(id);
            return View(servicioEN);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            ServicioEN servicioEN = new ServicioEN();
            return View(servicioEN);
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(ServicioEN servicioEN)
        {
            try
            {
                ServicioCEN servicioCEN = new ServicioCEN();
                servicioCEN.New_(servicioEN.Nombre, servicioEN.Descripcion, servicioEN.Estado, servicioEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int id)
        {
            ServicioCEN servicioCEN = new ServicioCEN();
            ServicioEN servicioEN = servicioCEN.ReadOID(id);
            return View(servicioEN);
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServicioEN servicioEN)
        {
            try
            {
                ServicioCEN servicioCEN = new ServicioCEN();
                servicioCEN.Modify(id, servicioEN.Nombre, servicioEN.Descripcion, servicioEN.Estado, servicioEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(int id)
        {
            ServicioCEN servicioCEN = new ServicioCEN();
            ServicioEN servicioEN = servicioCEN.ReadOID(id);
            return View(servicioEN);
        }

        // POST: Servicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ServicioEN servicioEN)
        {
            try
            {
                ServicioCEN servicioCEN = new ServicioCEN();
                servicioCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
