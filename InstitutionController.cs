using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using WebMatrix.WebData;
using PagedList;
using System.Collections;
using System.IO;

namespace scholarsnet.Controllers
{
   // [AllowAnonymous]
    public class InstitutionController : Controller
    {
        private DBContext db = new DBContext();
        //
        // GET: /Institution/
         
        public ActionResult Index(int? page)
        {
            
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Name) ascending
                               select a;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_institutePartial", institutions);
            }

            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult home(int? page, string cat)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) descending
                               where (a.Category == cat || a.Category.Contains(cat))
                               select a;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_institutePartial", institutions);
            }

            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }

        //Sort Federal Schools
        public ActionResult federal(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) ascending
                               where (a.Category=="Federal")
                               select a;
            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }

        //Sort State Schools
        public ActionResult state(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) ascending
                               where (a.Category == "State")
                               select a;
            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }

        //Sort State Schools
        public ActionResult privat(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) ascending
                               where (a.Category == "Private")
                               select a;
            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }



        //Sort polytechnics
        public ActionResult poly(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) ascending
                               where (a.InstituteType.Contains("Polytechnic"))
                               select a;
            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }


        //Sort Universities
        public ActionResult university(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) ascending
                               where (a.InstituteType.Contains("University"))
                               select a;
            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }

        //Sort Colleges
        public ActionResult colleges(int? page)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            var institutions = from a in db.Institutions
                               orderby (a.Abbreviation) ascending
                               where (a.InstituteType.Contains("College"))
                               select a;
            //return View(academ);
            return View(institutions.ToPagedList(pageNumber, pageSize));
        }

        //All institutions
        public ActionResult Institutes(string institute)
        {
            var viewd = db.Institutions.Include("AcademicUsers")
                                                                .Include("InstitutionViews")
                                                                .Include("News")
                                                                .Include("InstituteImages")
                                                                .Single(i => i.Abbreviation == institute);

            #region This region tracks the number of times an institute has been viewed

            //Institutions institutions = db.Institutions.Find(id);

            ////if (!academicuser.IsUserRegistered(User.Identity.Name))
            ////{
            //InstitutionViews institutionviews = new InstitutionViews()
            //{
            //    InstitutionID = institutions.InstitutionID,
            //    InstitutionViewer = WebSecurity.CurrentUserName
            //};

            //institutions.InstitutionViews.Add(institutionviews);

            //db.SaveChanges();
            //ViewData["instView"] = institutions.InstitutionViews.Count();
            #endregion

            return View(viewd);
        }


        [ChildActionOnly]
        public ActionResult InstituteMenu()
        {
            //var Institutes = db.Institutions.ToList();
            var Institutes = from d in db.Institutions
                             orderby (d.Name) ascending
                             select d;

            return PartialView(Institutes);

        }

        //
        // GET: /Institution/Details/5

        public ActionResult Details(int id = 0)
        {
            //Institutions institutions = db.Institutions.Find(id);
         
            var viewd = db.Institutions.Include("AcademicUsers")
                                                               .Include("InstitutionViews")
                                                               .Include("News")
                                                               .Include("InstituteImages")
                                                               .Single(i => i.InstitutionID == id);


            #region This region tracks the number of times an institute has been viewed

            Institutions institutions = db.Institutions.Find(id);

            //if (!academicuser.IsUserRegistered(User.Identity.Name))
            //{
            InstitutionViews institutionviews = new InstitutionViews()
            {
                InstitutionID = institutions.InstitutionID,
                InstitutionViewer = WebSecurity.CurrentUserName
            };
            
            institutions.InstitutionViews.Add(institutionviews);

            db.SaveChanges();
           ViewData["instView"] = institutions.InstitutionViews.Count();
            #endregion

            if (viewd == null)
            {
                return HttpNotFound();
            }
            return View(viewd);
        }

        //
        // GET: /Institution/Create
        public ActionResult register()
        {
            Institutions institution = new Institutions()
            {
                Website= "http://www",
                Wiki = "http://en.wikipedia.org/wiki/"
            };
            var cat =  new string[] { "Federal", "State", "Private" };
            var instype = new [] { "University", "University of Technoloy", "University of Science and Technology", "Polytechnic", "College of Agriculture", "College of Education" };
            var Nstate = new string[] { "Abuja FCT", "Anambra", "Enugu", "Akwa Ibom", "Adamawa", "Abia", "Bauchi", "Bayelsa", "Benue", "Borno", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Gombe", "Imo", "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos", "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara" };

            
            ViewData["instype"] = new SelectList(instype.ToList());
            ViewData["cat"] = new SelectList(cat.ToList());
            ViewData["Nstate"] = new SelectList(Nstate.ToList());
           
            return View(institution);
        }

        //
        // POST: /Institution/Create

        [HttpPost]
        public ActionResult register(HttpPostedFileBase file, Institutions institutions)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string path = "";
                string fileType = "";

                if (file != null && file.ContentLength > 0 )
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(file.FileName);
                    //fileType = Path.GetExtension(file.ContentType);
                    fileType = file.ContentType;
                    fileName = DateTime.Now.Ticks + fileName;


                    // store the file inside ~/Files/Articles folder
                    if (fileType == "image/jpg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Files/Institutions"), fileName);
                        file.SaveAs(path);

                        institutions.path = fileName;
                        db.Institutions.Add(institutions);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("Errorinstitution");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(institutions);
        }

        public ActionResult Errorinstitution()
        {
             return View("Errorinstitution");
        }


        //
        // GET: /Institution/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            Institutions institutions = db.Institutions.Find(id);
            if (institutions == null)
            {
                return HttpNotFound();
            }

            var cat = new string[] { "Federal", "State", "Private" };
            var instype = new[] { "University", "University of Technoloy", "University of Science and Technology", "Polytechnic", "College of Agriculture", "College of Education" };
            var Nstate = new string[] { "Abuja FCT", "Anambra", "Enugu", "Akwa Ibom", "Adamawa", "Abia", "Bauchi", "Bayelsa", "Benue", "Borno", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Gombe", "Imo", "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos", "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara" };


            ViewData["instype"] = new SelectList(instype.ToList());
            ViewData["cat"] = new SelectList(cat.ToList());
            ViewData["Nstate"] = new SelectList(Nstate.ToList());

            if (institutions == null)
            {
                return HttpNotFound();
            }

            return View(institutions);
        }

        //
        // POST: /Institution/Edit/5

        
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, Institutions institutions)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string Fpath = "";
                string fileType = "";
                //Save the pix to file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(file.FileName);
                    fileType = file.ContentType;
                    fileName = DateTime.Now.Millisecond + fileName;
                    // store the file inside ~/Files/Articles folder
                    if (fileType == "image/jpg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/jpeg")
                    {
                        Fpath = Path.Combine(Server.MapPath("~/Files/Institutions"), fileName);
                        file.SaveAs(Fpath);
                        institutions.path = fileName;
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }
                db.Entry(institutions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institutions);
        }

        //
        // GET: /Institution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Institutions institutions = db.Institutions.Find(id);
            //if (institutions == null)
            //{
            //    return HttpNotFound();
            //}
            return View(institutions);
        }

        //
        // POST: /Institution/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Institutions institutions = db.Institutions.Find(id);
            //db.Institutions.Remove(institutions);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}