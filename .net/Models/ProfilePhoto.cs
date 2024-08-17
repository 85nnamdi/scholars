using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class ProfilePhoto
    {
        [Key]
        public int PhotoID { get; set; }
        public int UserId { get; set; }

        [DataType(DataType.ImageUrl)]
        public String PhotoUrl { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateUploaded { get; set; }

    }
}