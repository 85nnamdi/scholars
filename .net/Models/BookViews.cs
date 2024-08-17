using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class BookViews
    {
        [Key]
        public int BookViewID { get; set; }
        public int BookID { get; set; }
        public String BookViewer { get; set; }
    }
}