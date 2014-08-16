using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Ioc;

namespace MvcApp.Controllers
{
    /// <summary>
    /// MEFIOC
    /// </summary>
    [Export]
    public class Default1Controller : Controller
    {
        [Import]
        public IUser User { get; set; }


        [Import]
        public IUser2 User2 { get; set; }

        public ActionResult Index()
        {
            ViewData["UserCount"] = User.UserCount();
            return View();
        }

    }
}
