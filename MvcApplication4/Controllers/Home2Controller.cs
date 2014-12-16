using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CYP.Common;
namespace MvcApplication4.Controllers
{
    public class Home2Controller : Controller
    {
        public ActionResult Index(int? pageIndex)
        {
            int pageNumber = pageIndex ?? 1;
            int pageSize = 2;
            int tatail =  Data().Count();
            return View(new CYP.Common.MvcPager.PagedList<int>(Data(), pageNumber, pageSize, Data().Count()));
        }

        public List<int> Data()
        {
            return new List<int> { 1, 2, 3 };
        }
    }
}
