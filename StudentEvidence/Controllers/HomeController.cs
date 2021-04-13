using DATA;
using StudentEvidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentEvidence.Controllers
{
    public class HomeController : Controller
    {
        DALUser dALUser = new DALUser();
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
        public virtual ActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public virtual ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dALUser.CheckUser(model.UserName, model.Password);
                if (user == true)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Wrong", "Wrong password or username");
            return View();
        }
        public virtual ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
         


    }
}