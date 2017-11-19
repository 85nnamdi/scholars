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
    public class StudentProjectController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /StudentProject/

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var stud = from a in db.StudentProject
                     orderby (a.StudentProjectID) descending
                     select a;

            return View(stud.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /StudentProject/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentProject studentproject = db.StudentProject.Find(id);
            if (studentproject == null)
            {
                return HttpNotFound();
            }
            return View(studentproject);
        }

        //
        // GET: /StudentProject/Create

        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            StudentProject stud = new StudentProject()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Author = User.Identity.Name
            };
            return View(stud);
        }

        //
        // POST: /StudentProject/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, StudentProject studentproject)
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
                        path = Path.Combine(Server.MapPath("~/Files/StudentProject"), fileName);
                        file.SaveAs(path);
                        studentproject.path = fileName;

                        db.StudentProject.Add(studentproject);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(studentproject);
        }

        //
        // GET: /StudentProject/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentProject studentproject = db.StudentProject.Find(id);
            if (studentproject == null)
            {
                return HttpNotFound();
            }
            return View(studentproject);
        }

        //
        // POST: /StudentProject/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentProject studentproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentproject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentproject);
        }

        //
        // GET: /StudentProject/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentProject studentproject = db.StudentProject.Find(id);
            if (studentproject == null)
            {
                return HttpNotFound();
            }
            return View(studentproject);
        }

        //
        // POST: /StudentProject/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentProject studentproject = db.StudentProject.Find(id);
            db.StudentProject.Remove(studentproject);
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