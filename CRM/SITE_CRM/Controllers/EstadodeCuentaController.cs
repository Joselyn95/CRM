using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;
namespace SITE_CRM.Controllers
{
    public class EstadodeCuentaController : Controller
    {
        private EstadodeCuentaBL estadoBL = new EstadodeCuentaBL();
        //private RolBL rolBL = new RolBL();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(estadoBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            //ViewBag.Roles = rolBL.Listar();
            return View(id == 0 ? new ET.EstadodeCuenta() : estadoBL.Obtener(id));
        }

        public ActionResult Guardar(EstadodeCuenta estado)
        {
            var r = estado.Id_Estado > 0 ?
                    estadoBL.Actualizar(estado) :
                    estadoBL.Registrar(estado);

            if (!r)
            {
                // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Usuario/Index");
        }
    }
}