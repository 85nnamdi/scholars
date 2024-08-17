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
    public class termpaperController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /termpaper/

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var term = from a in db.Termpaper
                     orderby (a.TermpaperID) descending
                     select a;

            return View(term.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /termpaper/Details/5

        public ActionResult Details(int id = 0)
        {
            Termpaper termpaper = db.Termpaper.Find(id);
            if (termpaper == null)
            {
                return HttpNotFound();
            }
            return View(termpaper);
        }

        //
        // GET: /termpaper/Create

        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            Termpaper tp = new Termpaper()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Author = User.Identity.Name
            };
            return View(tp);
        }

        //
        // POST: /termpaper/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Termpaper termpaper)
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
                        path = Path.Combine(Server.MapPath("~/Files/Term"), fileName);
                        file.SaveAs(path);
                        termpaper.path = fileName;

                        db.Termpaper.Add(termpaper);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(termpaper);
        }

        //
        // GET: /termpaper/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Termpaper termpaper = db.Termpaper.Find(id);
            if (termpaper == null)
            {
                return HttpNotFound();
            }
            return View(termpaper);
        }

        //
        // POST: /termpaper/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Termpaper termpaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termpaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termpaper);
        }

        //
        // GET: /termpaper/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Termpaper termpaper = db.Termpaper.Find(id);
            if (termpaper == null)
            {
                return HttpNotFound();
            }
            return View(termpaper);
        }

        //
        // POST: /termpaper/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termpaper termpaper = db.Termpaper.Find(id);
            db.Termpaper.Remove(termpaper);
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