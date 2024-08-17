using scholarsnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using PagedList;

namespace scholarsnet.Controllers
{
    //"Undergraduate", "Postgraduate", "Masters", "PhD"

    public class studentController : Controller
    {
        private DBContext db = new DBContext();
        //
        // GET: /student/

        public ActionResult index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                return Redirect("~/shome/");
            }
            return View();
        }

        //PhD home
        public ActionResult phd(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var phduser =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "PhD");

            //return View(academ);
            return View(phduser.ToPagedList(pageNumber, pageSize));
        }

        
        //Master Home
        public ActionResult master(int? page)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var masteruser =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "Masters");

            //return View(academ);
            return View(masteruser.ToPagedList(pageNumber, pageSize));
        }

        //Postgraduate Home
        public ActionResult pgd(int? page)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var pgduser =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "Postgraduate");

            //return View(academ);
            return View(pgduser.ToPagedList(pageNumber, pageSize));
        }

        //Postgraduate Home
        public ActionResult undergraduate(int? page)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var udergraduateuser =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "Undergraduate");

            //return View(academ);
            return View(udergraduateuser.ToPagedList(pageNumber, pageSize));
        }
    }
}
