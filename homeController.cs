using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebMatrix.WebData;
using scholarsnet.Models;
using System.IO;
using System.Collections;

namespace scholarsnet.Controllers
{
    [Authorize]
    public class homeController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Profile/

        public ActionResult index(int? page)
        {

            int pageSize = 3;
            int pageNumber = (page ?? 1);


            //Journal view
            var journal = from journ in db.Journals
                          orderby (journ.JournalID) descending
                          select new MyPaper
                          {
                              ID = journ.JournalID,
                              UserId = journ.UserId,
                              Title = journ.Topic,
                              Contributors = journ.Contributors,
                              Content = journ.JournalDescription,
                              DatePosted = journ.DatePosted,
                              path = journ.path,
                              ReadCount = journ.JournalViews.Count
                          };

            //var articles = db.Articles
            //               .OrderByDescending(a => a.UserId)
            //               .Take(5).ToList();

            var articles = from art in db.Articles
                           orderby(art.ArticleID) descending
                           select new MyPaper
                           {
                               ID=art.ArticleID,
                               UserId= art.UserId,
                               Title=art.Title,
                               Contributors=art.Contributors,
                               Content=art.Article,
                               path=art.path,
                               DatePosted=art.DatePosted,
                               FileType = art.fileType,
                               ReadCount= art.ArticleViews.Count
                           };


            //var books = db.Books
            //            .OrderByDescending(a => a.UserId)
            //            .Take(7).ToList();
            var books = from buk in db.Books
                           orderby(buk.BookID) descending
                           select new MyPaper
                           {
                               ID = buk.BookID,
                               UserId= buk.UserId,
                               Title=buk.Title,
                               Contributors=buk.Contributors,
                               Content=buk.Book,
                               path=buk.path,
                               DatePosted=buk.DatePosted,
                               FileType = buk.fileType,
                               ReadCount= buk.BookViews.Count
                           };

            ViewData["totalUsers"] = db.AcademicUsers.Count();
            ViewData["journal"] = journal;
            ViewData["articles"] = articles;
            ViewData["books"] = books;
            //var academ = db.AcademicUser
            //             .OrderByDescending(a => a.UserId)
            //             .Skip(2)
            //             .Take(3).ToList();

            var academ = from a in db.AcademicUsers
                         orderby (a.UserId) descending
                         select a;


            AcademicUsers academics = db.AcademicUsers.Find(WebSecurity.CurrentUserId);
           // Institutions institutions = db.Institutions.Find(academics.InstitutionID);
            UserProfileSessionData profileData = new UserProfileSessionData
            {
                UserId = academics.UserId,
                EmailAddress = academics.Email,
                FullName = academics.FullName,
                UserType = academics.UserType,
                Institution = academics.InstitutionID.ToString()
            };

            Session["UserProfile"] = profileData;

            return View(academ);
            //return View(academ.ToPagedList(pageNumber, pageSize));

        }

        //
        [AllowAnonymous]
        public ActionResult u(string un, int id = 0)
        {

            AcademicUsers academics = db.AcademicUsers.Find(id);
            
                var us = db.AcademicUsers
                                        .Include("Journals")
                                        .Include("Articles")
                                        .Include("Books")
                                        .Include("Connect")
                                        .Include("ProfilePhoto")
                                        .Include("ProfileStatus")
                                        .Include("ProfileContact")
                                        .Include("ProfileCourse")
                                        .Include("ProfileWork")
                                        .Include("About")
                                        .Include("UserViews")
                                        .Include("Follower")
                                        .Include("Thesis")
                                        .Include("StudentProject")
                                        .Include("ITPresentation")
                                        .Include("Seminar")
                                        .Include("Termpaper")
                                            .FirstOrDefault(i => i.UserName == un);
               
            //int ins = academics.InstitutionID;
            //ViewBag.ins =   db.Institutions.First(ins);
            ViewData["institution"] = new SelectList(db.Institutions.ToList(), "InstitutionID", "Name", "0");

                if (us == null)
                {
                    return View("Error");
                }
            return View(us);
        }
        //
        // GET: /Profile/Details/5
        [AllowAnonymous]
        public ActionResult user(int id = 0)
        {
           // var guid = WebSecurity.GetUserId(User.Identity.Name);
            AcademicUsers academicusers = db.AcademicUsers
                                        .Include("Journals")
                                        .Include("Articles")
                                        .Include("Books")
                                        .Include("Connect")
                                        .Include("ProfilePhoto")
                                        .Include("ProfileStatus")
                                        .Include("ProfileContact")
                                        .Include("ProfileCourse")
                                        .Include("ProfileWork")
                                        .Include("About")
                                        .Include("UserViews")
                                        .Include("Follower")
                                        .Include("Thesis")
                                        .Include("StudentProject")
                                        .Include("ITPresentation")
                                        .Include("Seminar")
                                        .Include("Termpaper")
                                        .FirstOrDefault(d => d.UserId == id);

            var instution = from i in db.Institutions
                            orderby (i.Name) ascending
                            select i;

            ViewData["institution"] = new SelectList(instution, "InstitutionID", "Name", "0");

           // ViewData["institution"] = db.Institutions.Select(a=>a.Name).ToList();

            try
            {
                AcademicUsers academics = db.AcademicUsers.Find(id);
                UserViews userview = new UserViews()
                {
                    UserId = WebSecurity.CurrentUserId,
                    ViewerName = WebSecurity.CurrentUserName
                };

                academics.UserViews.Add(userview);

                db.SaveChanges();
                ViewData["userview"] = academics.UserViews.Count();

            }
            catch
            {
                return HttpNotFound();
            }

            if (academicusers == null)
            {
                return HttpNotFound();
            }
            return View(academicusers);
        }

        //
        // GET: /Profile/Create

        public ActionResult Create()
        {
            //return View();
            return RedirectToAction("index");
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AcademicUsers academicusers)
        {
            if (ModelState.IsValid)
            {
                db.AcademicUsers.Add(academicusers);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(academicusers);
        }

        //
        // GET: /Profile/Edit/5

        public ActionResult edit(int id = 0)
        {
            AcademicUsers academicusers = db.AcademicUsers.Find(id);

            if (WebSecurity.CurrentUserId != academicusers.UserId)
            {
                return Redirect("~/home/");
            }
                var us = new string[] { "Academic (Lecturer)", "Researcher", "PhD", "Masters", "Postgraduate", "Undergraduate" };
                ViewData["usertyp"] = new SelectList(us.ToList());

                if (academicusers == null)
                {
                    return HttpNotFound();
                }
            
            return View(academicusers);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(HttpPostedFileBase file, AcademicUsers academicusers)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                string path = "";
                string fileType = "";
                //Save the pix to file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    fileName = Path.GetFileName(file.FileName);
                    fileType = file.ContentType;
                    fileName = DateTime.Now.Millisecond + fileName;
                    // store the file inside ~/Files/Articles folder
                    if (fileType == "image/jpg" || fileType == "image/png" || fileType == "image/gif" || fileType == "image/jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Files/Users"), fileName);
                        file.SaveAs(path);
                        academicusers.Photo = fileName;
                    }
                    else
                    {
                        return View("UploadError");
                    }
                }

                db.Entry(academicusers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicusers);
        }

        //
        // GET: /Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AcademicUsers academicusers = db.AcademicUsers.Find(id);
            if (academicusers == null)
            {
                return HttpNotFound();
            }
            return View(academicusers);
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicUsers academicusers = db.AcademicUsers.Find(id);
            db.AcademicUsers.Remove(academicusers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //Follower
        [Authorize, AcceptVerbs(HttpVerbs.Post)]
        public ActionResult follow(int id)
        {
            AcademicUsers auser = db.AcademicUsers.Find(id);
            //Dinner dinner = dinnerRepository.GetDinner(id);

            //if (!Auser.IsUserRegistered(User.Identity.Name))
            //{
            //    RSVP rsvp = new RSVP();
            Follower follower = new Follower{
            //    rsvp.Attendeename = User.Identity.Name;
            UserId = WebSecurity.CurrentUserId,
            FollowerName = WebSecurity.CurrentUserName
            };

            //    dinner.RSVPs.Add(rsvp);
            auser.Follower.Add(follower);
            //    dinnerRepository.Save();
            db.SaveChanges();
            //}
            return Content("Following");
        }


        //Follow2
        [HttpPost]
        public ActionResult fol(int id = 0)
        {
            if (Request.IsAjaxRequest())
            {
                
                AcademicUsers user = db.AcademicUsers.Include("Follower")
                                     .FirstOrDefault(d => d.UserId == id);

                AcademicUsers users = db.AcademicUsers.Find(id);

                #region This region tracks the number of follow a user has gained

                //if (!academicuser.IsUserRegistered(User.Identity.Name))
                //{
                Follower follow = new Follower()
                {
                    UserId = WebSecurity.CurrentUserId,
                    FollowerName = WebSecurity.CurrentUserName
                };

                users.Follower.Add(follow);
                db.SaveChanges();
                ViewData["userview"] = users.Follower.Count();
                #endregion

                if (users == null)
                {
                    return HttpNotFound();
                }
            }
                return Content("Now Following");
            
        }
    }
}