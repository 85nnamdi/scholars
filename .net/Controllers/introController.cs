using scholarsnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using scholarsnet.Mailers;

namespace scholarsnet.Controllers
{
    public class introController : Controller
    {
        
        DBContext db = new DBContext();
        private IUserMailer _mailer = new UserMailer();
        public IUserMailer Mailer
        {
            get { return _mailer; }
            set { _mailer = value; }
        }


        public ActionResult index()
        {
           if (WebSecurity.IsAuthenticated)
            {
                return Redirect("~/home/");
            }
            return View();
        }

        [HttpPost]
        public ActionResult index(String email)
        {
            if (email != null)
            {
                NewsLetter newsleta = new NewsLetter
                {
                    Email = email
                };

                db.NewsLetter.Add(newsleta);
                db.SaveChanges();

                //send the email here
                try
                {
                    Mailer.invite(email).Send();
                    ViewData["email"] = "An email has been sent! Thank you for inviting " + email;

                }
                catch (Exception ex)
                {
                    ViewData["email"] = "Couldn't send the email " + ex;
                //return RedirectToAction("Index", "intro");
                }
                
            }
            return View();
        }

        public ActionResult privacy()
        {

            return View();
        }

        public ActionResult terms()
        {
            
            return View();
        }

        public ActionResult disclaimer()
        {
            return View();
        }

        public ActionResult faq()
        {
            return View();
        }

        

        //Friend invite
        public ActionResult invite(string email)
        {
            if (email != null)
            {
                NewsLetter newsleta = new NewsLetter
                    {
                        Email=email
                    };

                db.NewsLetter.Add(newsleta);
                db.SaveChanges();

                //send the email here
                try
                {
                    Mailer.invite(email).Send();
                    ViewData["email"] = "An email has been sent! Thank you for inviting " + email;

                }
                catch(Exception ex)
                {
                    ViewData["email"] = "Couldn't send the email" + ex;
                }
                return RedirectToAction("Index", "intro");
            }
            return View();
        }
        ////
        //// POST: /NewsLetter/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult newsletter(NewsLetter newsletter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var a = from n in db.NewsLetter
        //                select n.Email;
                

        //        db.NewsLetter.Add(newsletter);
        //        db.SaveChanges();
        //        return RedirectToAction("index");
        //    }

        //    return View(newsletter);
        //}
    }
}
