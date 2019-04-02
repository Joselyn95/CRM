using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;

namespace SITE_CRM.Controllers
{
    public class ServicioEmpController : Controller
    {
        private ServicioEmpresaBL serEmpBL = new ServicioEmpresaBL();
        // GET: ServicioEmp
        public ActionResult Index()
        {
            return View(serEmpBL.Listar());
        }
    }
}