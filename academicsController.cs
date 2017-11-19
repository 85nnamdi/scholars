using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace scholarsnet.Controllers
{
    public class academicsController : Controller
    {
        //
        // GET: /academics/

        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return Redirect("~/home/");
            }
            return View();
        }

    }
}
