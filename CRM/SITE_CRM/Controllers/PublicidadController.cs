using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;

namespace SITE_CRM.Controllers
{
    public class PublicidadController : Controller
    {
        private PublicidadBL publiBL = new PublicidadBL();
        // GET: Publicidad
        public ActionResult Index()
        {
            return View(publiBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new Publicidad() : publiBL.Obtener(id));
        }

        public ActionResult Guardar(Publicidad publicidad)
        {
            var r = publicidad.Id_Publicidad > 0 ?
                    publiBL.Actualizar(publicidad) :
                    publiBL.Registrar(publicidad);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Publicidad/Index");
        }
    }
}
