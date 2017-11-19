using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class StudentProjectViews
    {
        [Key]
        public int StudentProjectViewsID { get; set; }
        public int StudentProjectID { get; set; }
        public string ProjectViewer { get; set; }
    }
}