using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using OpenContactsNet;
using scholarsnet.Models;
using scholarsnet.Mailers;


namespace scholarsnet.Controllers
{
    public class EmailInviteController : Controller
    {
        //MailContactList list = null;
        DBContext db = new DBContext();
        private IUserMailer _mailer = new UserMailer();
        public IUserMailer Mailer
        {
            get { return _mailer; }
            set { _mailer = value; }
        }
        
        //
        // GET: /EmailInvite/
        public ActionResult Index()
        {
            //ask the user to provide email credentials
            var ac = db.AcademicUsers.ToList();

            foreach (AcademicUsers item in ac)
            {
                //send the email here
                Mailer.NewsLetter(item.FullName, item.Email, item.UserName).Send();
            }
            return View();
        }

        //NewsLetter
        public ActionResult newsletter()
        {
            //ask the user to provide email credentials
            var ac = db.AcademicUsers.ToList();

            foreach (AcademicUsers item in ac)
            {
                //send the email here
                Mailer.NewsLetter(item.FullName, item.Email, item.UserName).Send();
            }
            ViewData["message"] = "email sent!";
            return View();
        }

        //Friend invite
        public ActionResult invite(string email)
        {
            if (email != null)
            {
                //send the email here
                Mailer.invite(email).Send();
                ViewData["email"] = "An email has been sent! Thank you for inviting " + email;
            }
            return View();
        }

        //Post it
        public ActionResult howtoupload()
        {
            //ask the user to provide email credentials
            var ac = db.AcademicUsers.ToList();

            foreach (AcademicUsers item in ac)
            {
                //send the email here
                Mailer.howtoupload(item.FullName, item.Email, item.UserName).Send();
            }
            ViewData["message"] = "email sent!";
            return View();
        }

        //Lets loop through email to exteact email
        //public ActionResult Checker()
        //{
        //    try{
        //        GmailExtract extractor = new GmailExtract();
        //        bool res = extractor.Extract(new NetworkCredential("html2ava@gmail.com", "prof3366"), out list);
        //        ViewBag.Msg = ( res ? "Succeeded" : "Failed" );

        //        if (list != null)
        //        {
        //          var a =list.Count+ " items imported"  ;
        //            foreach (MailContact contact in list)
        //            {
        //                ViewBag.count = a;
        //                ViewBag.Extract = contact.Email + " AND "+ contact.Name ;
        //            }
        //        }

        //        }catch{
        //            return View("Error");
        //        } 
        //    return View();
        //}
    }
}
