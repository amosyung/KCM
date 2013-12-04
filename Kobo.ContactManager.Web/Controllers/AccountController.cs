using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kobo.ContactManager.Web.Models;

namespace Kobo.ContactManager.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult LogOn()
        {
            return View(new LogonModel() { ErrorMessage = string.Empty });
        }

        public ActionResult LogOn(LogonModel model)
        {                      
            if (Membership.ValidateUser(model.UserId, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserId, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ErrorMessage = "Invalid login credential";
                return View(model);
            }
        }



    }
}
