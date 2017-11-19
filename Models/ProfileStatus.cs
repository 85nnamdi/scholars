using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class ProfileStatus
    {
        [Key]
        public int StatusID { get; set; }
        public int UserId { get; set; }

        [MaxLength(60, ErrorMessage = "Status Text Cannot be more than 60 characters")] 
        public string StatusText { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateChanged { get; set; }
    }
}