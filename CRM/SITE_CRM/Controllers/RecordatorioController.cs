using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;

namespace SITE_CRM.Controllers
{
    public class RecordatorioController : Controller
    {
        
        private RecordatorioBL recorBL = new RecordatorioBL();

        public ActionResult Index()
        {
            return View(recorBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            return View(id == 0 ? new Recordatorio() : recorBL.Obtener(id));
        }

        public ActionResult Guardar(Recordatorio recordatorio)
        {
            var r = recordatorio.Id_Recordatorio > 0 ?
                    recorBL.Actualizar(recordatorio) :
                    recorBL.Registrar(recordatorio);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Recordatorio/Index");
        }
    }
}
