using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;

namespace SITE_CRM.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioBL usuarioBL = new UsuarioBL();
        private RolBL rolBL = new RolBL();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuarioBL.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.Roles = rolBL.Listar();
            return View(id == 0 ? new Usuario() : usuarioBL.Obtener(id));
        }

        public ActionResult Guardar(Usuario usuario)
        {
            var r = usuario.Id_Usuario > 0 ?
                    usuarioBL.Actualizar(usuario) :
                    usuarioBL.Registrar(usuario);

            if (!r)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/Usuario/Index");
        }

    }
}