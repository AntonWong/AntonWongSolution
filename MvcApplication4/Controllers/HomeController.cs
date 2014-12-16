using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? pageIndex)
        {
            int pageNumber = pageIndex ?? 1;
            int pageSize = 2;
            int tatail =  Data().Count();
            return View(new PagedList<int>(Data(), pageNumber, pageSize));
        }

        public List<int> Data()
        {
            return new List<int> { 1, 2, 34, 5, 6, 7, 8, 11, 12, 23, 45, 76, 89, 56, 347, 8784, 23247, 1, 2, 34, 5, 6, 7, 8, 11, 12, 23, 45, 76, 89, 56, 347, 8784, 23247 };
        }
    }
}
