using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class PaperView
    {
        [Key]
        public int PaperViewID { get; set; }
        public int PapersID { get; set; }
        public String PaperViewer { get; set; }
    }
}