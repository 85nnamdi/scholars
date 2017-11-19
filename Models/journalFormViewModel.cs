using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class journalFormViewModel
    {
        public Journals Journals { get; set; }

        //Public constructor
        public journalFormViewModel(Journals journals)
        {
            Journals = journals;
        }
    }
}