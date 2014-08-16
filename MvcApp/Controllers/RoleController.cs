using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApp.Controllers
{
    public class RoleController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string uname)
        {
            if (!string.IsNullOrEmpty(uname))
            {
                FormsAuthentication.SetAuthCookie(uname,true);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (1,
                        uname,
                        DateTime.Now,
                        DateTime.Now.Add(FormsAuthentication.Timeout),
                        //DateTime.Now.AddMinutes(20),
                        true,
                        "7,1,8",
                        "/"
                    );
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                cookie.HttpOnly = true;
                HttpContext.Response.Cookies.Add(cookie);

                return RedirectToAction("UserPage");
            }
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "1,2,3")]
        public ActionResult UserPage()
        {
            ViewData["user"] = User.Identity.Name;
            if (!User.Identity.IsAuthenticated)
            {
                return View("~/Views/Role/Login.cshtml");
            }
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string role = ticket.UserData;

            ViewData["role"] = role;
            return View();
        }
        [Authorize(Roles = "1,2,3")]
        public ActionResult Role()
        {
            ViewData["user"] = User.Identity.Name;
            return View();
        }
        public ActionResult NotAllowed()
        {
            return View();
        }

    }
}
