using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class notifications
    {
        public int notificationID { get; set; }

        public string notificationsView(string msg, string title, string url)
        {
            return (msg + title + url);
        }
    }
}