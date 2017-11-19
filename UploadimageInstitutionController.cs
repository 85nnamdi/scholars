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
    public class UploadimageInstitutionController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /UploadimageInstitution/

        public ActionResult Index()
        {
            return View(db.InstituteImages.ToList());
        }

        //
        // GET: /UploadimageInstitution/Details/5

        public ActionResult Details(int id = 0)
        {
            InstituteImages instituteimages = db.InstituteImages.Find(id);
            if (instituteimages == null)
            {
                return HttpNotFound();
            }
            return View(instituteimages);
        }

        //
        // GET: /UploadimageInstitution/Create

        public ActionResult Create()
        {
            ViewData["Institution"] = new SelectList(db.Institutions.ToList(), "InstitutionID", "Name", "0");
            InstituteImages instutionImage = new InstituteImages()
            {
                DatePosted = DateTime.Now
            };
            return View(instutionImage);
        }

        //
        // POST: /UploadimageInstitution/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, InstituteImages instituteimages)
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
                        path = Path.Combine(Server.MapPath("~/Files/InstituteImages"), fileName);
                        file.SaveAs(path);

                        instituteimages.path = fileName;
                        db.InstituteImages.Add(instituteimages);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("Errorinstitution");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(instituteimages);
        }

        //
        // GET: /UploadimageInstitution/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InstituteImages instituteimages = db.InstituteImages.Find(id);
            if (instituteimages == null)
            {
                return HttpNotFound();
            }
            return View(instituteimages);
        }

        //
        // POST: /UploadimageInstitution/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstituteImages instituteimages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituteimages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instituteimages);
        }

        //
        // GET: /UploadimageInstitution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InstituteImages instituteimages = db.InstituteImages.Find(id);
            if (instituteimages == null)
            {
                return HttpNotFound();
            }
            return View(instituteimages);
        }

        //
        // POST: /UploadimageInstitution/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstituteImages instituteimages = db.InstituteImages.Find(id);
            db.InstituteImages.Remove(instituteimages);
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