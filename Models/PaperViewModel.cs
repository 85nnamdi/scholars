using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class PaperViewModel
    {
         public Papers Papers { get; set; }

          // Constructor 
         public PaperViewModel(Papers papers)
        {
            Papers = papers;
        }
    }
}