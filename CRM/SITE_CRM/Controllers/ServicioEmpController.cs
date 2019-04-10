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

        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new ServicioEmpresa() : serEmpBL.Obtener(id));
        }

        public ActionResult Guardar(ServicioEmpresa servicio)
        {
            var r = servicio.Id_ServicioEmpresa > 0 ?
                    serEmpBL.Actualizar(servicio) :
                    serEmpBL.Registrar(servicio);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Usuario/Index");
        }
    }
}