﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SITE_CRM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Entrar()
        {
            return View();
        }
    }
}