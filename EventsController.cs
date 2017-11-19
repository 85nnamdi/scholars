using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scholarsnet.Models;
using WebMatrix.WebData;
using PagedList;

namespace scholarsnet.Controllers
{
    

    public class EventsController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Events/

        public ActionResult Index(int? page)
        {

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var events = from b in db.Events
                       orderby (b.EventID) descending
                       select b;

            //return View(academ);
            return View(events.ToList().ToPagedList(pageNumber, pageSize));
        }

        //
        public ActionResult Events(string events)
        {
            var viewd = db.Events.Single(i => i.Title == events);
            return View(viewd);
        }

        //Menu
        [ChildActionOnly]
        public ActionResult EventMenu()
        {
            //var Institutes = db.Institutions.ToList();
            
            var events = db.Events
                           .OrderByDescending(a => a.EventID)
                           .Take(5).ToList();

            return PartialView(events);

        }
        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            
            var guid = WebSecurity.GetUserId(User.Identity.Name);

            
            Events events = new Events()
            {
                EventDate = DateTime.Now,
                UserId = guid,
                HostedBy =User.Identity.Name
            };
            return View(new EventViewModel(events));
        }

        //
        // POST: /Events/Create

        [HttpPost]
        public ActionResult Create(Events events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(new EventViewModel(events));
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(new EventViewModel(events));
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult Edit(Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.Events.Find(id);
            db.Events.Remove(events);
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