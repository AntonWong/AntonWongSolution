using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Ioc;
using MvcApp.Model;

namespace MvcApp.Controllers
{
    [Export]
    public class HomeController : Controller
    {
        [Import]
        public IUser User { get; set; }


        [Import]
        public IUser2 User2 { get; set; }

        public ActionResult Index()
        {
            //var context = new testEntities();

            //var entity = context.CarSource_Role;
            //ViewData["UserCount"] = entity.ToList().Count;

            CarSource_Role role = new CarSource_Role
            {
                Role_Name = "A",
                Creator = "B",
                Modifier = "C",
                Role_Desc = "D",
                ShopType_Id = 0,
                ShopType_Name = "E"
            };
            AddCarNum(role);
            ViewData["UserCount"] = "Role_Id:" + role.Role_Id;

            return View();
        }

        public int AddCarNum(CarSource_Role role)
        {
            using (var context = new testEntities())
            {
                context.CarSource_Role.Add(role);
                return context.SaveChanges();
            }
        }

    }
}
