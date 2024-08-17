using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using System.IO;
using PagedList;
using WebMatrix.WebData;
using System.Web.Security;

namespace scholarsnet.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Books/
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var book = from b in db.Books
                      orderby (b.BookID) descending
                      select b;
            
            //return View(academ);
            return View(book.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Books/Details/5

        public ActionResult Details(int id = 0)
        {
            Books book = db.Books.Include("BookViews") .FirstOrDefault(d => d.BookID == id);

            Books books = db.Books.Find(id);
             #region This region tracks the number of views a Journal has gained
            //Make sure that the poster of the article will not increase the number of views
            if (books.Contributors != WebSecurity.CurrentUserName)
            {
                BookViews bookview = new BookViews()
                {
                    BookID = WebSecurity.CurrentUserId,
                    BookViewer = WebSecurity.CurrentUserName
                };

                books.BookViews.Add(bookview);
                db.SaveChanges();
            }
            ViewData["bookviews"] = books.BookViews.Count();
             #endregion

            if (books == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            // }
            //**** ViewBag.Aidv = guid;
            Books books = new Books()
            {
                DatePosted = DateTime.Now,
                UserId = guid,
                Contributors =User.Identity.Name
            };
            return View(books);
        }

        //
        // POST: /Books/Create

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Books books)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string path = "";
                string fileType = "";

                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                fileType = file.ContentType;
                fileName = DateTime.Now.Ticks + fileName;
                // store the file inside ~/Files/Articles folder

                if (fileType == ".document" || fileName.Contains(".doc") || fileName.Contains(".pdf"))
                {
                    path = Path.Combine(Server.MapPath("~/Files/Books"), fileName);
                    file.SaveAs(path);
                    books.path = fileName;
                    db.Books.Add(books);
                    db.SaveChanges();
                }
                else
                {
                    return View("UploadError");
                }
            }

            return View(books);
        }

        //
        // GET: /Books/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(new BooksFormViewModel(books));
        }

        //
        // POST: /Books/Edit/5

        [HttpPost]
        public ActionResult Edit(Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        //
        // GET: /Books/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        //
        // POST: /Books/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
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