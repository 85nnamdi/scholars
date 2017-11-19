using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using PagedList;

namespace scholarsnet.Controllers
{
    [Authorize]
    public class shomeController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /shome/

        public ActionResult index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            //THESIS view
            var thesis = from thes in db.Thesis
                          orderby (thes.ThesisID) descending
                          select new MyPaper
                          {
                              ID = thes.ThesisID,
                              UserId = thes.UserId,
                              Title = thes.Title,
                              Contributors = thes.Author,
                              Content = thes.Thesis_Description,
                              DatePosted = thes.DatePosted,
                              path = thes.path,
                              //ReadCount = journ.JournalViews.Count
                          };

            //StudentProject view
            var sproj = from sp in db.StudentProject
                      orderby (sp.StudentProjectID) descending
                      select new MyPaper
                      {
                          ID = sp.StudentProjectID,
                          UserId = sp.UserId,
                          Title = sp.Topic,
                          Contributors = sp.Author,
                          Content = sp.ResearchDescription,
                          DatePosted = sp.DatePosted,
                          path = sp.path,
                          ReadCount = sp.StudentProjectViews.Count
                      };

            //THESIS view
            var ITPresent = from ITdefence in db.ITPresentation
                      orderby (ITdefence.ITPresentationID) descending
                      select new MyPaper
                      {
                          ID = ITdefence.ITPresentationID,
                          UserId = ITdefence.UserId,
                          Title = ITdefence.Title,
                          Contributors = ITdefence.Author,
                          Content = ITdefence.ItPresentation,
                          DatePosted = ITdefence.DatePosted,
                          path = ITdefence.path,
                          //ReadCount = journ.JournalViews.Count
                      };

            //THESIS view
            var senmiar = from semi in db.Seminar
                            orderby (semi.SeminarID) descending
                            select new MyPaper
                            {
                                ID = semi.SeminarID,
                                UserId = semi.UserId,
                                Title = semi.Title,
                                Contributors = semi.Author,
                                Content = semi.Seminar_Description,
                                DatePosted = semi.DatePosted,
                                path = semi.path,
                                //ReadCount = journ.JournalViews.Count
                            };

            //THESIS view
            var termpaper = from term in db.Termpaper
                            orderby (term.TermpaperID) descending
                            select new MyPaper
                            {
                                ID = term.TermpaperID,
                                UserId = term.UserId,
                                Title = term.Title,
                                Contributors = term.Author,
                                Content = term.TermPaper,
                                DatePosted = term.DatePosted,
                                path = term.path,
                                //ReadCount = journ.JournalViews.Count
                            };


            ViewData["totalUsers"] = db.AcademicUsers.Count();
            ViewData["thesis"] = thesis;
            ViewData["sproj"] = sproj;
            ViewData["ITPresent"] = ITPresent;
            ViewData["seminar"] = senmiar;
            ViewData["termpaper"] = termpaper;


            var students = from a in db.AcademicUsers
                         orderby (a.UserId) descending
                         select a;

            return View(students.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /shome/Details/5

        public ActionResult suser(int id = 0)
        {
            AcademicUsers studentuser = db.AcademicUsers.Find(id);
            if (studentuser == null)
            {
                return HttpNotFound();
            }
            return View(studentuser);
        }
        
        //
        public ActionResult su(string un, int id = 0)
        {

            AcademicUsers academics = db.AcademicUsers.Find(id);

            var us = db.AcademicUsers.Include("Termpaper")
                                        .Include("Seminar")
                                        .Include("ITPresentation")
                                        .Include("StudentProject")
                                        .Include("Thesis")
                                        .FirstOrDefault(i => i.UserName == un);

            if (us == null)
            {
                return View("Error");
            }
            return View(us);
        }
        

        //
        // GET: /shome/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /shome/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicUsers studentuser)
        {
            if (ModelState.IsValid)
            {
                db.AcademicUsers.Add(studentuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentuser);
        }

        //
        // GET: /shome/Edit/5
        public ActionResult edit(int id = 0)
        {
            AcademicUsers studentuser = db.AcademicUsers.Find(id);
            if (studentuser == null)
            {
                return HttpNotFound();
            }
            return View(studentuser);
        }

        //
        // POST: /shome/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(StudentUser studentuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentuser);
        }

        //
        // GET: /shome/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AcademicUsers studentuser = db.AcademicUsers.Find(id);
            if (studentuser == null)
            {
                return HttpNotFound();
            }
            return View(studentuser);
        }

        //
        // POST: /shome/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicUsers studentuser = db.AcademicUsers.Find(id);
            db.AcademicUsers.Remove(studentuser);
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