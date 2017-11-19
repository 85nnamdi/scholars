using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class JournalViews
    {
        [Key]
        public int JournalViewID { get; set; }
        public int JournalId { get; set; }
        public String ViewerName { get; set; }
    }
}