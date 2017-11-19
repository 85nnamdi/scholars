using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class EventAttendance
    {
        [Key]
        public int EventAttendanceID { get; set; }
        public int EventID { get; set; }
        public String AttendeeName { get; set; }
    }
}