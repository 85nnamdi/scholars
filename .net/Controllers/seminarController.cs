using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using WebMatrix.WebData;
using System.IO;
using PagedList;

namespace scholarsnet.Controllers
{
    public class seminarController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /seminar/

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var sem = from a in db.Seminar
                     orderby (a.SeminarID) descending
                     select a;

            return View(sem.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /seminar/Details/5

        public ActionResult Details(int id = 0)
        {
            Seminar seminar = db.Seminar.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        //
        // GET: /seminar/Create

        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            Seminar seminar = new Seminar()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Author = User.Identity.Name
            };
            return View(seminar);
        }

        //
        // POST: /seminar/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Seminar seminar)
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
                    fileType = file.ContentType;
                    fileName = DateTime.Now.Ticks + fileName;
                    // store the file inside ~/Files/Articles folder
                    if (fileType == ".document" || fileName.Contains(".doc") || fileName.Contains(".pdf"))
                    {
                        path = Path.Combine(Server.MapPath("~/Files/Seminar"), fileName);
                        file.SaveAs(path);
                        seminar.path = fileName;

                        db.Seminar.Add(seminar);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(seminar);
        }

        //
        // GET: /seminar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Seminar seminar = db.Seminar.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        //
        // POST: /seminar/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seminar);
        }

        //
        // GET: /seminar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Seminar seminar = db.Seminar.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        //
        // POST: /seminar/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seminar seminar = db.Seminar.Find(id);
            db.Seminar.Remove(seminar);
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