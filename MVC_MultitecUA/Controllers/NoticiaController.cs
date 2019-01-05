using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace MVC_MultitecUA.Controllers
{
    public class NoticiaController : BasicController
    {
        // GET: Noticia
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            NoticiaCEN noticiaCEN = new NoticiaCEN();

            int tamPag = 10;

            int numPags = (noticiaCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<NoticiaEN> listaNoticias = noticiaCEN.ReadAll(inicio, tamPag).ToList();

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            return View(listaNoticias);
        }


        // GET: Noticia/Details/5
        public ActionResult Details(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            ViewData["titulo"] = noticiaEN.Titulo;
            
            return View(noticiaEN);
        }

        // GET: Noticia/Create
        public ActionResult Create()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            
            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");


            NoticiaEN noticiaEN = new NoticiaEN();
            return View(noticiaEN);
        }

        // POST: Noticia/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NoticiaEN noticiaEN, HttpPostedFileBase fotoNoticia)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";
            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                //VALIDANDO TITULO
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{5,50}$");
                if (!pattern.IsMatch(noticiaEN.Titulo))
                {
                    ViewData["formatotitulonoticia"] = "mal";
                    return View();
                }

                //VALIDANDO CUERPO
                pattern = new Regex("^.{10,4000}$");
                if (!pattern.IsMatch(noticiaEN.Cuerpo))
                {
                    ViewData["formatocuerponoticia"] = "mal";
                    return View();
                }

                string nombreFoto = "", path = "";

                if (fotoNoticia != null && fotoNoticia.ContentLength > 0)
                {
                    nombreFoto = Path.GetFileName(fotoNoticia.FileName);
                    path = Path.Combine(Server.MapPath("~/Imagenes"), nombreFoto);
                    fotoNoticia.SaveAs(path);
                    //path = Server.MapPath("~/Imagenes/") + Path.GetFileName(postedFile.FileName);
                    //postedFile.SaveAs(path);
                    nombreFoto = "/Imagenes/" + nombreFoto;
                }

                int OID;

                if (nombreFoto == "")
                {
                    OID = noticiaCEN.New_(noticiaEN.Titulo, noticiaEN.Cuerpo, null);
                }
                else
                {
                    OID = noticiaCEN.New_(noticiaEN.Titulo, noticiaEN.Cuerpo, nombreFoto);
                }

                TempData["noticiacreada"] = "si";

                return RedirectToAction("Details/" + OID);
            }
            catch
            {
                return View();
            }
        }

        // GET: Noticia/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            ViewData["titulo"] = noticiaEN.Titulo;

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            return View(noticiaEN);
        }

        // POST: Noticia/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, NoticiaEN noticiaEN, HttpPostedFileBase fotoNoticia)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();

                //VALIDANDO TITULO
                Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{5,50}$");
                if (!pattern.IsMatch(noticiaEN.Titulo))
                {
                    ViewData["formatotitulonoticia"] = "mal";
                    return View();
                }

                //VALIDANDO CUERPO
                pattern = new Regex("^.{10,4000}$");
                if (!pattern.IsMatch(noticiaEN.Cuerpo))
                {
                    ViewData["formatocuerponoticia"] = "mal";
                    return View();
                }

                string nombreFoto = "", path = "";

                if (fotoNoticia != null && fotoNoticia.ContentLength > 0)
                {
                    path = Path.GetFullPath(Server.MapPath("~/" + noticiaEN.FotoNoticia));
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    nombreFoto = Path.GetFileName(fotoNoticia.FileName);
                    path = Path.Combine(Server.MapPath("~/Imagenes"), nombreFoto);
                    fotoNoticia.SaveAs(path);
                    //path = Server.MapPath("~/Imagenes/") + Path.GetFileName(postedFile.FileName);
                    //postedFile.SaveAs(path);
                    nombreFoto = "/Imagenes/" + nombreFoto;
                }

                if (nombreFoto == "")
                {
                    noticiaCEN.Modify(id, noticiaEN.Titulo, noticiaEN.Cuerpo, noticiaEN.FotoNoticia);
                }
                else
                {
                    noticiaCEN.Modify(id, noticiaEN.Titulo, noticiaEN.Cuerpo, nombreFoto);
                }
                TempData["noticiaeditada"] = "si";

                return RedirectToAction("Details/" + id);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);
            ViewData["titulo"] = noticiaEN.Titulo;
            return View(noticiaEN);
        }

        // POST: Noticia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NoticiaEN noticiaEN)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            if (TempData.ContainsKey("noticiacreada"))
                TempData.Remove("noticiacreada");
            if (TempData.ContainsKey("noticiaeditada"))
                TempData.Remove("noticiaeditada");

            try
            {
                NoticiaCEN noticiaCEN = new NoticiaCEN();
                noticiaEN = noticiaCEN.ReadOID(id);

                string path = Path.GetFullPath(Server.MapPath("~/" + noticiaEN.FotoNoticia));

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                noticiaCEN.Destroy(id);

                TempData["bien"] = "Se a borrado correctamente la noticia" + noticiaEN.Titulo;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar borrar la noticia";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Noticia(int id)
        {
            NoticiaCEN noticiaCEN = new NoticiaCEN();
            NoticiaEN noticiaEN = noticiaCEN.ReadOID(id);

            return View("./VistaUsuario/Noticia", noticiaEN);
        }
    }
}
