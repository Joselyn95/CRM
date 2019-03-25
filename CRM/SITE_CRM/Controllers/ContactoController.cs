using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;
namespace SITE_CRM.Controllers
{
    public class ContactoController : Controller
    {
        private ContactoBL contactoBL = new ContactoBL();
        //private RolBL rolBL = new RolBL();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(contactoBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            //ViewBag.Roles = rolBL.Listar();
            return View(id == 0 ? new Contacto() : contactoBL.Obtener(id));
        }

        public ActionResult Guardar(Contacto contacto)
        {
            var r = contacto.Id_Contacto > 0 ?
                    contactoBL.Actualizar(contacto) :
                    contactoBL.Registrar(contacto);

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