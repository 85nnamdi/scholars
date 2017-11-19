using scholarsnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace scholarsnet.Controllers
{
    public class AcademicuserController : Controller
    {
        private DBContext db = new DBContext();
        //
        // GET: /Academicuser/
        [AllowAnonymous]
        public ActionResult index(int? page)
        {

            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var alluser =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId);

            //var academ = from a in db.AcademicUsers
            //             orderby (a.UserId) descending
            //             select a;

            //return View(academ);
            return View(alluser.ToPagedList(pageNumber, pageSize));
        }


        //Academic users
        [AllowAnonymous]
        public ActionResult academic(int? page)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var academicuser =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "Academic (Lecturer)");

            return View(academicuser.ToPagedList(pageNumber, pageSize));
        }

        //researcher page
        [AllowAnonymous]
        public ActionResult researcher(int? page)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var researcher =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "Researcher");

            return View(researcher.ToPagedList(pageNumber, pageSize));
        }

        //Student user
        [AllowAnonymous]
        public ActionResult students(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var students =
                       db.AcademicUsers
                       .OrderByDescending(r => r.UserId)
                       .Where(r => r.UserType == "Student");

           
            return View(students.ToPagedList(pageNumber, pageSize));
        }



    }
}
