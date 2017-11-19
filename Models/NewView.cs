using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class NewView
    {
        [Key]
        public int NewsViewID { get; set; }
        public int NewsID { get; set; }
        public String ViewerName { get; set; }
    }
}