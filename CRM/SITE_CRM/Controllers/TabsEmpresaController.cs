using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AjaxControlToolkit;
using BL;
using ET;

namespace SITE_CRM.Controllers
{
    public class TabsEmpresaController : Controller
    {
        private ServicioEmpresaBL serBL = new ServicioEmpresaBL();
        private ContactoBL contactoBL = new ContactoBL();
        // GET: TabsEmpresa
        public ActionResult Index (Models.modelTab modelos)
        {
            if (ModelState.IsValid)
            {
                modelos.contacto = contactoBL.Listar();
                modelos.servicioEmp = serBL.Listar();
                //Acciones y operaciones a realizar

            }
            return View(modelos);
        }
    }
}