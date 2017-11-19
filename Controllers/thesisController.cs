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
    public class thesisController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /thesis/

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var thesis = from a in db.Thesis
                     orderby (a.ThesisID) descending
                     select a;

            return View(thesis.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /thesis/Details/5

        public ActionResult Details(int id = 0)
        {
            Thesis thesis = db.Thesis.Find(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        //
        // GET: /thesis/Create
        [Authorize]
        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            Thesis thes = new Thesis()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Author = User.Identity.Name
            };
            return View(thes);
        }

        //
        // POST: /thesis/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Thesis thesis)
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
                    if (fileType == ".document" || fileType == "application/msword" || fileType == "application/pdf" || fileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                      {
                        path = Path.Combine(Server.MapPath("~/Files/Thesis"), fileName);
                        file.SaveAs(path);
                        thesis.path = fileName;

                        db.Thesis.Add(thesis);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(thesis);
        }

        //
        // GET: /thesis/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Thesis thesis = db.Thesis.Find(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        //
        // POST: /thesis/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thesis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thesis);
        }

        //
        // GET: /thesis/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Thesis thesis = db.Thesis.Find(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        //
        // POST: /thesis/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thesis thesis = db.Thesis.Find(id);
            db.Thesis.Remove(thesis);
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