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
    public class ITPresentController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /ITPresent/

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var it = from a in db.ITPresentation
                        orderby (a.ITPresentationID) descending
                         select a;

            return View(it.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /ITPresent/Details/5

        public ActionResult Details(int id = 0)
        {
            ITPresentation itpresentation = db.ITPresentation.Find(id);
            if (itpresentation == null)
            {
                return HttpNotFound();
            }
            return View(itpresentation);
        }

        //
        // GET: /ITPresent/Create
        [Authorize]
        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            ITPresentation itpresent = new ITPresentation()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Author = User.Identity.Name
            };
            return View(itpresent);
        }

        //
        // POST: /ITPresent/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, ITPresentation itpresentation)
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
                    if(fileType == ".document" || fileName.Contains(".doc") || fileName.Contains(".pdf"))
                    {
                        path = Path.Combine(Server.MapPath("~/Files/ITPrentation"), fileName);
                        file.SaveAs(path);
                        itpresentation.path = fileName;

                        db.ITPresentation.Add(itpresentation);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }
                return RedirectToAction("Index");
            }

            return View(itpresentation);
        }

        //
        // GET: /ITPresent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ITPresentation itpresentation = db.ITPresentation.Find(id);
            if (itpresentation == null)
            {
                return HttpNotFound();
            }
            return View(itpresentation);
        }

        //
        // POST: /ITPresent/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ITPresentation itpresentation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itpresentation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itpresentation);
        }

        //
        // GET: /ITPresent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ITPresentation itpresentation = db.ITPresentation.Find(id);
            if (itpresentation == null)
            {
                return HttpNotFound();
            }
            return View(itpresentation);
        }

        //
        // POST: /ITPresent/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITPresentation itpresentation = db.ITPresentation.Find(id);
            db.ITPresentation.Remove(itpresentation);
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