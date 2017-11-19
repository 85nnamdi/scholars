using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class UserViews
    {
        [Key]
        public int UserViewID { get; set; }
        public int UserId { get; set; }
        public String ViewerName { get; set; }
    }
}