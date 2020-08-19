﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dominio.Core.Entities;
using Dominio.Main.Module;

namespace ASPCapas.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            IEnumerable<Curso> objeto = null;
            CursoManager manager = new CursoManager();

            objeto = manager.ListarCurso();
            return View(objeto);
        }


        public ActionResult CrearCurso()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearCurso(Curso objeto)
        {
            CursoManager manager = new CursoManager();
            if (ModelState.IsValid)
            {
                manager.RegistrarCurso(objeto);
                return RedirectToAction("Index");
            }
            else
            {
                return View(objeto);
            }
        }

        public ActionResult CerrarCesion()
        {
            return RedirectToAction("Validar", "Usuario");
        }


    }
}