using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using MVC_MultitecUA.Models;
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
    public class RecuerdoController : BasicController
    {
        // GET: Recuerdo
        public ActionResult Index(int? pag)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            SessionInitialize();

            RecuerdoCAD cadRec = new RecuerdoCAD(session);
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN(cadRec);

            int tamPag = 10;

            int numPags = (recuerdoCEN.ReadAll(0, -1).Count - 1) / tamPag;

            if (pag == null || pag < 0)
                pag = 0;
            else if (pag >= numPags)
                pag = numPags;

            ViewData["pag"] = pag;

            ViewData["numeroPaginas"] = numPags;

            int inicio = (int)pag * tamPag;

            IList<RecuerdoEN> listaRecuerdosEn = recuerdoCEN.ReadAll(inicio, tamPag).ToList();
            IEnumerable<Recuerdo> listaRecuerdos = new AssemblerRecuerdo().ConvertListENToModel(listaRecuerdosEn).ToList();

            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("nocreado"))
            {
                TempData.Remove("nocreado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }

            SessionClose();

            return View(listaRecuerdos);
        }

        // GET: Recuerdo/Details/5
        public ActionResult Details(int id)
        {
            Recuerdo rec = null;
            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            ViewData["idEvento"] = rec.IdEvento;
            ViewData["recuerdo"] = recuerdoEN.Titulo;
            ArrayList fotos = new ArrayList();
            foreach (string foto in recuerdoEN.FotosRecuerdo)
            {
                fotos.Add(foto);
            }
            ViewData["listaFotos"] = fotos;

            if (Session["usuario"] != null && Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
            {
                return View(rec);
            }
            else
            {
                return View("./VistaUsuario/Detalles", rec);
            }
        }

        // GET: Recuerdo/Create
        public ActionResult Create(int idEvento)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            Recuerdo rec = new Recuerdo();
            TempData["idEvento"] = idEvento;
            ViewData["idEvento"] = idEvento;
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN eventoEN = eventoCEN.ReadOID(idEvento);
            ViewData["NombreEvento"] = eventoEN.Nombre;

            if (TempData.ContainsKey("creado"))
                TempData.Remove("creado");
            if (TempData.ContainsKey("editado"))
                TempData.Remove("editado");

            if (Session["usuario"] != null && Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
            {
                return View(rec);
            }
            else
            {
                return View("./VistaUsuario/CrearRecuerdo", rec);
            }

        }


        public ActionResult CreateNoId()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            Recuerdo recuerdo = new Recuerdo();
            if (TempData.ContainsKey("creado"))
            {
                TempData.Remove("creado");
            }
            if (TempData.ContainsKey("editado"))
            {
                TempData.Remove("editado");
            }
            return View(recuerdo);
        }



        // POST: Recuerdo/Create/id
        [HttpPost]
        public ActionResult Create(Recuerdo rec, HttpPostedFileBase file)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            try
            {
                RecuerdoCEN cen = new RecuerdoCEN();
                EventoCEN eventoCEN = new EventoCEN();
                EventoEN evento = eventoCEN.ReadOID(int.Parse(TempData["idEvento"].ToString()));
                
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

                if (Session["modoAdmin"].ToString() == "false")
                {
                    if (rec.Titulo == null || rec.Cuerpo == null)
                    {
                        TempData["vaciorecuerdo"] = "No pueden haber campos vacios";
                        return Redirect("Create?idEvento="+TempData["idEvento"]);
                    }

                    //VALIDANDO TITULO
                    Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                    if (!pattern.IsMatch(rec.Titulo))
                    {
                        TempData["formatotitulo"] = "mal";
                        return Redirect("Create?idEvento=" + TempData["idEvento"]);
                    }

                    //VALIDANDO CUERPO
                    pattern = new Regex("^.{10,2000}$");
                    if (!pattern.IsMatch(rec.Cuerpo))
                    {
                        TempData["formatocuerpo"] = "mal";
                        return Redirect("Create?idEvento=" + TempData["idEvento"]);
                    }
                }

                int id;
                if (fileName != "")  {
                    IList<string> fotos = new List<string>();
                    fotos.Add(fileName);
                    id = cen.New_(rec.Titulo, rec.Cuerpo, int.Parse(TempData["idEvento"].ToString()), fotos);
                }
                else {
                    IList<string> fotos = new List<string>();
                    fotos.Add("/Imagenes/NoFoto.png");
                    id = cen.New_(rec.Titulo, rec.Cuerpo, int.Parse(TempData["idEvento"].ToString()), fotos);
                }

                TempData["creado"] = "si";
                TempData.Remove("idEvento");
                return Redirect("Details/" + id);
            }
            catch
            {
                TempData["nocreado"] = "Ha habido un error al crear el recuerdo";
                return Redirect("Create?idEvento=" + TempData["idEvento"]);
            }
        }





        // POST: Recuerdo/Create/id
        [HttpPost]
        public ActionResult CreateNoId(Recuerdo rec, HttpPostedFileBase file)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            if (Session["esAdmin"].ToString() == "false")
                return View("../NoAdministrador");
            if (Session["modoAdmin"].ToString() == "false")
                Session["modoAdmin"] = "true";

            try
            {
                // TODO: Add insert logic here
                RecuerdoCEN cen = new RecuerdoCEN();
                EventoCEN eventoCEN = new EventoCEN();
                EventoEN evento = eventoCEN.ReadOID(rec.IdEvento);

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
                
                int id;
                if (fileName == "")
                {
                    IList<string> fotos = new List<string>();
                    fotos.Add("/Imagenes/NoFoto.png");
                    id = cen.New_(rec.Titulo, rec.Cuerpo, rec.IdEvento, fotos);
                }
                else
                {
                    IList<string> fotos = new List<string>();
                    fotos.Add(fileName);
                    id = cen.New_(rec.Titulo, rec.Cuerpo, rec.IdEvento, fotos);
                }
                
                TempData["creado"] = "si";

                return Redirect("Details/" + id);
            }
            catch
            {
                TempData["nocreado"] = "No se ha podido crear el recuerdo";
                return View();
            }
        }




        // GET: Recuerdo/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            RecuerdoEN recuerdoEN = new RecuerdoCAD(session).ReadOID(id);
            Recuerdo recuerdo = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            
            if (TempData.ContainsKey("creado"))
                TempData.Remove("creado");
            if (TempData.ContainsKey("nocreado"))
                TempData.Remove("nocreado");

            ViewData["recuerdo"] = recuerdoEN.Titulo;

            if (Session["usuario"] != null && Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
            {
                return View(recuerdo);
            }
            else
            {
                return View("./VistaUsuario/Editar", recuerdo);
            }

        }





        // POST: Recuerdo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Recuerdo rec, HttpPostedFileBase file)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            
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
            
            try
            {
                // TODO: Add update logic here
                RecuerdoCEN cen = new RecuerdoCEN();


                if (Session["modoAdmin"].ToString() == "false")
                {
                    if (rec.Titulo == null || rec.Cuerpo == null)
                    {
                        TempData["vaciorecuerdo"] = "No pueden haber campos vacios";
                        return Redirect("../Edit/" + id);
                    }

                    //VALIDANDO TITULO
                    Regex pattern = new Regex("^[A-Za-z0-9 áéíóúñç]{4,30}$");
                    if (!pattern.IsMatch(rec.Titulo))
                    {
                        TempData["formatotitulo"] = "mal";
                        return Redirect("../Edit/" + id);
                    }

                    //VALIDANDO CUERPO
                    pattern = new Regex("^.{10,2000}$");
                    if (!pattern.IsMatch(rec.Cuerpo))
                    {
                        TempData["formatocuerpo"] = "mal";
                        return Redirect("../Edit/" + id);
                    }
                }


                if (fileName == "")
                {
                    IList<string> fotos = new List<string>();
                    fotos.Add("/Imagenes/NoFoto.png");
                    cen.Modify(id, rec.Titulo, rec.Cuerpo, fotos);
                }
                else
                {
                    IList<string> fotos = new List<string>();
                    fotos.Add(fileName);
                    cen.Modify(id, rec.Titulo, rec.Cuerpo, fotos);
                }
                TempData["editado"] = "si";

                return RedirectToAction("Details/"+id);
            }
            catch
            {
                ViewData["error"] = "No se se ha podido crear el recuerdo";
                return Redirect("../Edit/" + id);
            }
        }





        // GET: Recuerdo/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");
            
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);

            if (TempData.ContainsKey("creado"))
                TempData.Remove("creado");
            if (TempData.ContainsKey("nocreado"))
                TempData.Remove("nocreado");
            if (TempData.ContainsKey("editado"))
                TempData.Remove("editado");
            
            ViewData["recuerdo"] = recuerdoEN.Titulo;
            Recuerdo recuerdo = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            if (Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
            {
                return View(recuerdoEN);
            }
            else
            {
                return View("./VistaUsuario/Borrar", recuerdo);
            }
        }





        // POST: Recuerdo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RecuerdoEN recuerdo)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Login", "Sesion");

            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            RecuerdoEN recuerdoEN = recuerdoCEN.ReadOID(id);
            Recuerdo rec = new AssemblerRecuerdo().ConvertENToModelUI(recuerdoEN);
            int idE = rec.IdEvento;

            try
            {
                // TODO: Add delete logic here
                
                recuerdoCEN.Destroy(id);
                TempData["bien"] = "Se a borrado correctamente el recuerdo " + recuerdo.Titulo;
                if (Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("porEvento", new { idEvento = idE });
                }
            }
            catch
            {
                TempData["mal"] = "Ocurrio un problema al intentar borrar el recuerdo";
                if (Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("porEvento", new { idEvento=idE});
                }
            }
        }




        //Filtro
        public ActionResult porEvento (int idEvento)
        {
           
            RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
            IList<RecuerdoEN> recuerdo = recuerdoCEN.DameRecuerdosPorProyecto(idEvento);
            IEnumerable<Recuerdo> listaRecuerdos = new AssemblerRecuerdo().ConvertListENToModel(recuerdo).ToList();
            EventoCEN eventoCEN = new EventoCEN();
            EventoEN evento = eventoCEN.ReadOID(idEvento);
            ViewData["idevento"] = idEvento;
            ViewData["nombreEvento"] = evento.Nombre;
            if (TempData.ContainsKey("creado"))
                TempData.Remove("creado");
            if (TempData.ContainsKey("nocreado"))
                TempData.Remove("nocreado");
            if (TempData.ContainsKey("editado"))
                TempData.Remove("editado");


            if (Session["usuario"] != null && Session["esAdmin"].ToString() == "true" && Session["modoAdmin"].ToString() == "true")
            {
                return View(listaRecuerdos);
            }
            else
            {
                return View("./VistaUsuario/Recuerdos", listaRecuerdos);
            }

        }
    }
}
