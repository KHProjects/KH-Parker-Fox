﻿using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class JavascriptController : Controller
    {
        //
        // GET: /Javascript/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modules()
        {
            return View();
        }

        public ActionResult Testing()
        {
            return View();
        }

        public ViewResult Patterns()
        {
            return View();
        }

        public ViewResult Jquery()
        {
            return View();
        }

        public ActionResult JqueryUI()
        {
            return View();
        }

        public ActionResult Cassette()
        {
            return View();
        }
    }
}
