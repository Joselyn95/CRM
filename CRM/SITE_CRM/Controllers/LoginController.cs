using BL;
using ET;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SITE_CRM.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private UsuarioBL usuarioBL = new UsuarioBL();

        // GET: Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string correo, string contraseña,int id)
        {
            //var usuarioLog = usuarioBL.Obtener(id);

            //Usuario usuarios = usuarioBL.Listar();

            //if (usuarioLog != null && correo == usuarios.Correo && contraseña == usuarios.Contraseña)
            //{

            //    RedirectToRoute("Entrar");
            //}
            //else
            //{

            //}
            return View();
        }
    }
}

    ////
    //// POST: /Account/Login
    //[HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // This doesn't count login failures towards account lockout
    //        // To enable password failures to trigger account lockout, change to shouldLockout: true
    //        var result = model.Email; //await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
    //        switch (result)
    //        {
    //            //case SignInStatus.Success:
    //            //    return RedirectToLocal(returnUrl);
    //            //case SignInStatus.LockedOut:
    //            //    return View("Lockout");
    //            //case SignInStatus.RequiresVerification:
    //            //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
    //            //case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Usuario Inválido");
    //                return View(model);
    //        }
    //    }

    //    private ActionResult RedirectToLocal(string returnUrl)
    //    {
    //        if (Url.IsLocalUrl(returnUrl))
    //        {
    //            return Redirect(returnUrl);
    //        }
    //        return RedirectToAction("Inicio", "Menu");
    //    }

    //    public class LoginViewModel
    //    {
    //        [Required]
    //        [Display(Name = "Email")]
    //        [EmailAddress]
    //        public string Email { get; set; }

    //        [Required]
    //        [DataType(DataType.Password)]
    //        [Display(Name = "Password")]
    //        public string Password { get; set; }

    //        [Display(Name = "Remember me?")]
    //        public bool RememberMe { get; set; }
    //    }
