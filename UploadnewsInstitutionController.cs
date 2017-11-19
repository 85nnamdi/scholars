using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using System.IO;

namespace scholarsnet.Controllers
{
    public class UploadnewsInstitutionController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /UploadnewsInstitution/

        public ActionResult Index()
        {
            return View(db.InstituteNews.ToList());
        }

        //
        // GET: /UploadnewsInstitution/Details/5

        public ActionResult Details(int id = 0)
        {
            InstituteNews institutenews = db.InstituteNews.Find(id);
            if (institutenews == null)
            {
                return HttpNotFound();
            }
            return View(institutenews);
        }

        //
        // GET: /UploadnewsInstitution/Create

        public ActionResult Create()
        {
            ViewData["Institution"] = new SelectList(db.Institutions.ToList(), "InstitutionID", "Name", "0");
            InstituteNews instutionNews = new InstituteNews()
            {
                NewsDate = DateTime.Now
            };
            return View(instutionNews);
        }

        //
        // POST: /UploadnewsInstitution/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, InstituteNews institutenews)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string path = "";
                string fileType = "";

                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(file.FileName);
                    //fileType = Path.GetExtension(file.ContentType);
                    fileType = file.ContentType;
                    fileName = DateTime.Now.Ticks + fileName;

                    // store the file inside ~/Files/Articles folder
                    if (fileType == "image/jpg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Files/News"), fileName);
                        file.SaveAs(path);

                        institutenews.path = fileName;
                        db.InstituteNews.Add(institutenews);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("Errorinstitution");
                    }
                }

                
                return RedirectToAction("Index");
            }

            return View(institutenews);
        }

        //
        // GET: /UploadnewsInstitution/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InstituteNews institutenews = db.InstituteNews.Find(id);
            if (institutenews == null)
            {
                return HttpNotFound();
            }
            return View(institutenews);
        }

        //
        // POST: /UploadnewsInstitution/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstituteNews institutenews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institutenews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institutenews);
        }

        //
        // GET: /UploadnewsInstitution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InstituteNews institutenews = db.InstituteNews.Find(id);
            if (institutenews == null)
            {
                return HttpNotFound();
            }
            return View(institutenews);
        }

        //
        // POST: /UploadnewsInstitution/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstituteNews institutenews = db.InstituteNews.Find(id);
            db.InstituteNews.Remove(institutenews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}