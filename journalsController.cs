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
   
    public class journalsController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /journals/
         [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var jon = db.Journals
                        .OrderByDescending(r => r.JournalID);

            return View(jon.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /journals/Details/5

        public ActionResult Details(int id = 0)
        {
            Journals journal = db.Journals.Include("JournalViews").FirstOrDefault(j => j.JournalID == id);
            
            Journals journals = db.Journals.Find(id);
            
            #region This region tracks the number of views a Journal has gained
            //Make sure that the poster of the article will not increase the number of views
            if (journals.Contributors != WebSecurity.CurrentUserName)
            {
                JournalViews journ = new JournalViews()
                {
                    JournalViewID = WebSecurity.CurrentUserId,
                    ViewerName = WebSecurity.CurrentUserName
                };
                journals.JournalViews.Add(journ);

                db.SaveChanges();
            }
                ViewData["journview"] = journals.JournalViews.Count();
           
            #endregion
            
            if (journals == null)
            {
                return HttpNotFound();
            }
            return View(journals);
        }

        //
        // GET: /journals/Create
        [Authorize]
        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            // }
            //**** ViewBag.Aidv = guid;
            Journals journals = new Journals()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Contributors = User.Identity.Name
            };
            return View(journals);
        }

        //
        // POST: /journals/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Journals journals)
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
                        path = Path.Combine(Server.MapPath("~/Files/Journals"), fileName);
                        file.SaveAs(path);

                        journals.path = fileName;
                        db.Journals.Add(journals);
                        db.SaveChanges();
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }

                
                return RedirectToAction("index","home");

            }

            return View(journals);
        }

        //
        // GET: /journals/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Journals journals = db.Journals.Find(id);
            if (journals == null)
            {
                return HttpNotFound();
            }
            return View(journals);
        }

        //
        // POST: /journals/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Journals journals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journals);
        }

        //
        // GET: /journals/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Journals journals = db.Journals.Find(id);
            if (journals == null)
            {
                return HttpNotFound();
            }
            return View(journals);
        }

        //
        // POST: /journals/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Journals journals = db.Journals.Find(id);
            db.Journals.Remove(journals);
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