using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class About
    {
        [ScaffoldColumn(false)]
        [Key]
        public int AboutID { get; set; }
        public int UserId { get; set; }

        [MaxLength(3500, ErrorMessage = "You have exceeded the maximum allowed characters for your detail")]
        [Required(ErrorMessage = "Detail Required")]
        [Display(Name = "Detail")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
    }

}