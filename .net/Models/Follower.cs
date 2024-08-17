using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class Follower
    {
        [Key]
        public int FollowerID { get; set; }
        public int UserId { get; set; }
        public String FollowerName { get; set; }
       
    }
}