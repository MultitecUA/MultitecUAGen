using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class RecuerdoController : BasicController
    {
        // GET: Recuerdo
        public ActionResult Index()
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            IList<RecuerdoEN> listaRecuerdos = recuerdoCEN.ReadAll(0, -1).ToList();
            return View(listaRecuerdos);
        }

        // GET: Recuerdo/Details/5
        public ActionResult Details(int id)
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            return View(recuerdoEN);
        }

        // GET: Recuerdo/Create
        public ActionResult Create()
        {
            RecuerdoEN recuerdoEN = new RecuerdoEN();
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Create
        [HttpPost]
        public ActionResult Create(RecuerdoEN recuerdoEN)
        {
            try
            {
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                recuerdoCEN.New_(recuerdoEN.Titulo, recuerdoEN.Cuerpo, recuerdoEN.EventoRecordado.Id, recuerdoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recuerdo/Edit/5
        public ActionResult Edit(int id)
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RecuerdoEN recuerdoEN)
        {
            try
            {
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                recuerdoCEN.Modify(id, recuerdoEN.Titulo, recuerdoEN.Cuerpo, recuerdoEN.Fotos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recuerdo/Delete/5
        public ActionResult Delete(int id)
        {
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            return View(recuerdoEN);
        }

        // POST: Recuerdo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RecuerdoEN recuerdoEN)
        {
            try
            {
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                recuerdoCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
