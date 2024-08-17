using scholarsnet.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace scholarsnet.Controllers
{
    internal class ErrorController : Controller
    {
        [HttpGet]
        public ViewResult Index(Int32? id)
        {
            var statusCode = id.HasValue ? id.Value : 500;
            var error = new HandleErrorInfo(new Exception("An exception with error " + statusCode + " occurred!"), "Error", "Index");
            return View("Error", error);
        }
    }
}



