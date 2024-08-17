using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class DBContext : DbContext
    {

        public DBContext(): base("DBContextMarch")
            {
            }

            public DbSet<AcademicUsers> AcademicUsers { get; set; }
            public DbSet<UserViews> UserViews { get; set; }
            public DbSet<Articles> Articles { get; set; }
            public DbSet<ArticleViews> ArticleViews { get; set; }
            public DbSet<Books> Books { get; set; }
            public DbSet<BookViews> BookViews { get; set; }
            public DbSet<Connect> Connect { get; set; }
            public DbSet<Events> Events { get; set; }
            public DbSet<EventAttendance> EventAttendance { get; set; }
            public DbSet<Institutions> Institutions { get; set; }
            public DbSet<InstitutionViews> InstitutionViews { get; set; }
            public DbSet<News> News { get; set; }
            public DbSet<NewView> NewView { get; set; }
            public DbSet<ProfileContact> ProfileContact { get; set; }
            public DbSet<ProfileCourses> ProfileCourses { get; set; }
            public DbSet<ProfilePhoto> ProfilePhoto { get; set; }
            public DbSet<ProfileStatus> ProfileStatus { get; set; }
            public DbSet<ProfileWork> ProfileWork { get; set; }
            public DbSet<About> Abouts { get; set; }
            public DbSet<Papers> Papers { get; set; }
            
            public DbSet<StudentProject> StudentProject { get; set; }
            public DbSet<StudentProjectViews> StudentProjectViews { get; set; }
            public DbSet<Follower> Follower { get; set; }
            public DbSet<Journals> Journals { get; set; }
            public DbSet<JournalViews> JournalsViews { get; set; }
            public DbSet<NewsLetter> NewsLetter { get; set; }


            public DbSet<Termpaper> Termpaper { get; set; }
            public DbSet<Seminar> Seminar { get; set; }
            public DbSet<ITPresentation> ITPresentation { get; set; }
            public DbSet<Thesis> Thesis { get; set; }
            //public DbSet<InstituteNews> InstituteNews { get; set; }
            public DbSet<InstituteImages> InstituteImages { get; set; }

            //public DbSet<webpages_Membership> webpages_Memberships { get; set; }
    }
}