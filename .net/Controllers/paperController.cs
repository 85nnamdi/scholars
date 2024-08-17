using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using System.IO;
using WebMatrix.WebData;

namespace scholarsnet.Controllers
{
    public class paperController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /paper/

        public ActionResult index()
        {
            return View(db.Papers.ToList());
        }

        //
        // GET: /paper/Details/5

        public ActionResult details(int id = 0)
        {
            Papers papers = db.Papers.Find(id);
            if (papers == null)
            {
                return HttpNotFound();
            }
            return View(papers);
        }

        //
        // GET: /paper/Create

        public ActionResult upload()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);
           
            Papers paper = new Papers()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Contributors = User.Identity.Name
            };
            return View(new PaperViewModel(paper));
        }

        //
        // POST: /paper/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult upload(HttpPostedFileBase file, Papers papers)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string path = "";
                string fileType="";

                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(file.FileName);
                    fileName = DateTime.Now.Millisecond + fileName;
                    // store the file inside ~/Files/Articles folder
                if (fileType == ".document" || fileName.Contains(".doc") || fileName.Contains(".pdf"))
                {
                    path = Path.Combine(Server.MapPath("~/Files/Paper"), fileName);
                    file.SaveAs(path);
                    db.Papers.Add(papers);
                    db.SaveChanges();
                }
                else
                {
                    return View("UploadError");
                }
                }
                return RedirectToAction("Index");
            }

            return View(papers);
        }

        //
        // GET: /paper/Edit/5

        public ActionResult edit(int id = 0)
        {
            Papers papers = db.Papers.Find(id);
            if (papers == null)
            {
                return HttpNotFound();
            }
            return View(papers);
        }

        //
        // POST: /paper/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(Papers papers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(papers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(papers);
        }

        //
        // GET: /paper/Delete/5

        public ActionResult delete(int id = 0)
        {
            Papers papers = db.Papers.Find(id);
            if (papers == null)
            {
                return HttpNotFound();
            }
            return View(papers);
        }

        //
        // POST: /paper/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Papers papers = db.Papers.Find(id);
            db.Papers.Remove(papers);
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