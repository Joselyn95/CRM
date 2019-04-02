using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;

namespace SITE_CRM.Controllers
{
    public class EmpresaController : Controller
    {
        private EmpresaBL empresaBL = new EmpresaBL();
        private ProvinciaBL provinciaBL = new ProvinciaBL();
        private CantonBL cantonBL = new CantonBL();
        private DistritoBL distritoBL = new DistritoBL();
        // GET: Empresa
        public ActionResult Index()
        {
            return View(empresaBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.Provincias = provinciaBL.Listar();
            ViewBag.Cantones = cantonBL.Listar();
            ViewBag.Distritos = distritoBL.Listar();
            return View(id == 0 ? new Empresa() : empresaBL.Obtener(id));
        }

        public ActionResult Guardar(Empresa empresa)
        {
            var r = empresa.Id_Empresa > 0 ?
                    empresaBL.Actualizar(empresa) :
                    empresaBL.Registrar(empresa);

            if (!r)
            {
                // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Empresa/Index");
        }



    }
}