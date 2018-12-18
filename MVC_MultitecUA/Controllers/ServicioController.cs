﻿using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Enumerated.MultitecUA;
using MVC_MultitecUA.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            SessionInitialize();
            ArrayList listaEstados = new ArrayList();
            foreach (var a in Enum.GetNames(typeof(EstadoServicioEnum)))
            {
                listaEstados.Add(a);
            }
            ViewData["listaEstadosServicio"] = listaEstados;
            ServicioCAD cadServ = new ServicioCAD(session);
            ServicioCEN servicioCEN = new ServicioCEN(cadServ);
            IList<ServicioEN> listaServiciosEn = servicioCEN.ReadAll(0,-1).ToList();
            IEnumerable<Servicio> listaServicios = new AssemblerServicio().ConvertListENToModel(listaServiciosEn).ToList();
            SessionClose();
            return View(listaServicios);
        }

        //POST: Servicio/PorEstado
        public ActionResult PorEstado(FormCollection f)
        {
            if(f == null)
            {
                return RedirectToAction("Index");
            }
            SessionInitialize();
            ArrayList listaEstados = new ArrayList();
            foreach (var cosa in Enum.GetNames(typeof(EstadoServicioEnum)))
            {
                listaEstados.Add(cosa);
            }
            ViewData["listaEstadosServicio"] = listaEstados;
            ServicioCAD cadServ = new ServicioCAD(session);
            ServicioCEN servicioCEN = new ServicioCEN(cadServ);
            var a = Enum.Parse(typeof(EstadoServicioEnum), f["Estados"]);
            ViewData["filtroEstado"] = f["Estados"];
            IList<ServicioEN> lista = servicioCEN.DameServiciosPorEstado((EstadoServicioEnum)a);
            IEnumerable<Servicio> listaServiciosEstados = new AssemblerServicio().ConvertListENToModel(lista).ToList();
            SessionClose();
            return View(listaServiciosEstados);
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int id)
        {
            Servicio serv = null;
            SessionInitialize();
            ServicioEN servicioEN = new ServicioCAD(session).ReadOID(id);
            serv = new AssemblerServicio().ConvertENToModelUI(servicioEN);
            SessionClose();
            return View(serv);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            ArrayList listaEstados = new ArrayList();
            foreach (var a in Enum.GetNames(typeof(EstadoServicioEnum)))
            {
                listaEstados.Add(a);
            }
            ViewData["listaEstadosServicio"] = listaEstados;
            Servicio serv = new Servicio();
            return View(serv);
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(Servicio serv)
        {
           
            try
            {
                // TODO: Add insert logic here
                ServicioCEN cen = new ServicioCEN();
                cen.New_(serv.Nombre, serv.Descripcion, serv.Estado,null);
                
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
            Servicio serv = null;
            SessionInitialize();
            ArrayList listaEstados = new ArrayList();
            foreach (var a in Enum.GetNames(typeof(EstadoServicioEnum)))
            {
                listaEstados.Add(a);
            }
            ViewData["listaEstadosServicio"] = listaEstados;
            ServicioEN servicioEN = new ServicioCAD(session).ReadOID(id);
            serv = new AssemblerServicio().ConvertENToModelUI(servicioEN);
            SessionClose();
            return View(serv);
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Servicio serv)
        {
            try
            {
                // TODO: Add update logic here
                ServicioCEN cen = new ServicioCEN();
                cen.Modify(id, serv.Nombre, serv.Descripcion,serv.Estado,null);

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
        public ActionResult Delete(int id, ServicioEN ser)
        {
            try
            {
                // TODO: Add delete logic here
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
