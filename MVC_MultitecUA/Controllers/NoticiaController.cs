using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MultitecUA.Controllers
{
    public class NoticiaController : BasicController
    {
        // GET: Noticia
        public ActionResult Index()
        {
            NoticiaCEN noticiaCEN = new NoticiaCEN();
            IList<NoticiaEN> listaNoticias = noticiaCEN.ReadAll(0, -1).ToList();
            return View(listaNoticias);
        }

        // GET: Noticia/Details/5
        public ActionResult Details(int id)
        {
            NoticiaCEN noticiaCEN = new NoticiaCEN();

            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);

            return View(noticiaEN);
        }

        // GET: Noticia/Create
        public ActionResult Create()
        {
            NoticiaEN noticiaEN = new NoticiaEN();
            return View(noticiaEN);
        }

        // POST: Noticia/Create
        [HttpPost]
        public ActionResult Create(NoticiaEN noticiaEN)
        {
            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                noticiaCEN.New_(noticiaEN.Titulo, noticiaEN.Cuerpo, noticiaEN.Foto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Edit/5
        public ActionResult Edit(int id)
        {
            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            return View(noticiaEN);
        }

        // POST: Noticia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NoticiaEN noticiaEN)
        {
            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                noticiaCEN.Modify(id, noticiaEN.Titulo, noticiaEN.Cuerpo, noticiaEN.Foto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(int id)
        {
            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            return View(noticiaEN);
        }

        // POST: Noticia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NoticiaEN noticiaEN)
        {
            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                noticiaCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
