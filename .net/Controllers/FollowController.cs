using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using WebMatrix.WebData;

namespace scholarsnet.Controllers
{
    public class FollowController : Controller
    {
        //
        // GET: /Follow/

        public ActionResult Index()
        {
            return View();
        }
        DBContext db = new DBContext();

        //Follower
        [Authorize, AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(int id)
        {
            AcademicUsers academicuser = db.AcademicUsers.Find(id);

            //Make sure that the poster of the article will not increase the number of views
            if (academicuser.UserName != WebSecurity.CurrentUserName)
            {

                Follower follower = new Follower()
                {
                    // rsvp.Attendeename = User.Identity.Name;
                    UserId = WebSecurity.CurrentUserId,
                    FollowerName = WebSecurity.CurrentUserName
                };

                //    dinner.RSVPs.Add(rsvp);
                academicuser.Follower.Add(follower);
                //dinnerRepository.Save();
                db.SaveChanges();
                return Content("Following");
            }
            return Content("...");

        //AcademicUsers academicuser = db.AcademicUsers.Find(id);
        //if (!academicuser.IsUserRegistered(WebSecurity.CurrentUserName))
        //{
        //    Follower follower = new Follower();
        //    follower.FollowerName = User.Identity.Name;
        //    follower.UserId = WebSecurity.CurrentUserId;
        //    academicuser.Follower.Add(follower);

        //    db.SaveChanges();
        //}
        //return Content("Following");

            //Dinner dinner = dinnerRepository.GetDinner(id);

            //if (!dinner.IsUserRegistered(User.Identity.Name))
            //{
            //    RSVP rsvp = new RSVP();
            //    rsvp.Attendeename = User.Identity.Name;

            //    dinner.RSVPs.Add(rsvp);
            //    dinnerRepository.Save();
            //}
            //return Content("Thanks - we'll see you there!");
        
        
        
        }
    }
}
