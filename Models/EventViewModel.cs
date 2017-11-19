using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class EventViewModel
    {
         public Events Events { get; set; }

          // Constructor 
         public EventViewModel(Events events)
        {
            Events = events;
        }
    }
}