using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class InstitutionViews
    {
        [Key]
        public int InstitutionViewID { get; set; }
        public int InstitutionID { get; set; }
        public String InstitutionViewer { get; set; }
    }
}