using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Mailers;
using scholarsnet.Models;
using PagedList;
using WebMatrix.WebData;

namespace scholarsnet.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private DBContext db = new DBContext();
        private IUserMailer _mailer = new UserMailer();
        public IUserMailer Mailer
        {
            get { return _mailer; }
            set { _mailer = value; }
        }

        //
        //AutoComplete
        public ActionResult Autocomplete(string term)
        {
            var resul =  db.Articles
                        .Where(r=>r.Title.Contains(term))
                        .Select(r=> new
                        {
                            label = r.Title
                        });
            return Json(resul, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Articles/
        [AllowAnonymous]
        public ActionResult Index(int? page, string term)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var art =
                        db.Articles
                        .OrderByDescending(r => r.ArticleID)
                        .Where(r => term == null || r.Title.Contains(term) || r.Article.StartsWith(term));

            //var art = from a in db.Articles
            //             orderby (a.ArticleID) descending
            //             select a;

            //return View(academ);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ArtList", art);
            }
            return View(art.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Articles/Details/5

        public ActionResult Details(int id = 0)
        {
            Articles article = db.Articles.Include("ArticleViews")
                                .FirstOrDefault(d => d.ArticleID == id);

            Articles articles = db.Articles.Find(id);

            #region This region tracks the number of views a user has gained
            //Make sure that the poster of the article will not increase the number of views
            if (articles.Contributors != WebSecurity.CurrentUserName)
             {
            //if (!academicuser.IsUserRegistered(User.Identity.Name))
            //{
            ArticleViews artviews = new ArticleViews()
            { 
                ArticleID=  WebSecurity.CurrentUserId,
                ArticleViewer = WebSecurity.CurrentUserName
            };

            
                articles.ArticleViews.Add(artviews);

                db.SaveChanges();
                ViewData["userview"] = articles.ArticleViews.Count();
            }
            #endregion

            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Articles/Create

        public ActionResult Create()
        {
            
        // var guid = 
           
               var guid = WebSecurity.GetUserId(User.Identity.Name);
           
             // }
             //**** ViewBag.Aidv = guid;
            Articles article = new Articles()
            {
              DatePosted = DateTime.Now,
              UserId = guid,
              Contributors = User.Identity.Name
            };
            return View(new ArticleFormViewModel(article));
        }

        //
        // POST: /Articles/Create

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Articles articles)
        {
            if (ModelState.IsValid)
            {
            string fileName = "";
            string path="";
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
                    path = Path.Combine(Server.MapPath("~/Files/Articles"), fileName);
                    file.SaveAs(path);
                    articles.path = fileName;

                    db.Articles.Add(articles);
                    db.SaveChanges();
                }
                else
                {
                    return View("UploadError");
                }
            }
                //send the email here
                //Mailer.Welcome().Send();

                return RedirectToAction("Index");
            }
            return View(new ArticleFormViewModel(articles));
        }
        
        public ActionResult UploadError()
        {
            return View("UploadError");
        }


        //
        // GET: /Articles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            //return View(articles);

            return View(new ArticleFormViewModel(articles));

        }

        //
        // POST: /Articles/Edit/5

        [HttpPost]
        public ActionResult Edit(Articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articles);
        }

        //
        // GET: /Articles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View(articles);
        }

        //
        // POST: /Articles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Articles articles = db.Articles.Find(id);
            db.Articles.Remove(articles);
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