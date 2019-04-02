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

        // GET: Usuario
        public ActionResult Index()
        {
            return View(contactoBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new Contacto() : contactoBL.Obtener(id));
        }

        public ActionResult Guardar(Contacto contacto)
        {
            var r = contacto.Id_Contacto > 0 ?
                    contactoBL.Actualizar(contacto) :
                    contactoBL.Registrar(contacto);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Usuario/Index");
        }

    }
}