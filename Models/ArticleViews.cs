using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class ArticleViews
    {
        [Key]
        public int ArticleViewID { get; set; }
        public int ArticleID { get; set; }
        public String ArticleViewer { get; set; }
    }
}