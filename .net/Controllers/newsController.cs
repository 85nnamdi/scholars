using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using PagedList;
using WebMatrix.WebData;
using System.IO;

namespace scholarsnet.Controllers
{
    [AllowAnonymous]
    public class newsController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /News/
        public ActionResult index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var news = from n in db.News
                       orderby (n.NewsID) descending
                       select n;

            //return View(academ);
            return View(news.ToList().ToPagedList(pageNumber, pageSize));
        }

        [ChildActionOnly]
        public ActionResult NewsMenu()
        {
            //var Institutes = db.Institutions.ToList(); 
            var Institutes = db.News
                       .OrderByDescending(a => a.NewsID)
                       .Take(8).ToList();

            return PartialView(Institutes);
        }

        public ActionResult news(string news)
        {
            var viewd = db.News.FirstOrDefault(i => i.Title == news);
            return View(viewd);
        }

        //
        // GET: /News/Details/5

        public ActionResult details(int id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // GET: /News/Create

        public ActionResult create()
        {
            var institution = from n in db.Institutions
                       orderby (n.Name) ascending
                       select n;

            ViewData["Institution"] = new SelectList(institution.ToList(), "InstitutionID", "Name", "0");

            var date = DateTime.Now;
            string userStatus = "";
            
            if (WebSecurity.IsAuthenticated)
            {
                userStatus = WebSecurity.CurrentUserName;
            }
            else
            {
                userStatus = "Guest";
            }

            News news = new News
            {
                NewsDate = date,
                NewsExpiryDate = date.AddDays(14),
                PostedBy = userStatus
            };
            return View(news);
        }

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult create(HttpPostedFileBase file, News news)
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

                        news.path = fileName;
                        
                    }
                    else
                    {
                        return View("Errorinstitution");
                    }
                }
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(new NewsFormViewModel(news));
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id = 0)
        {
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
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