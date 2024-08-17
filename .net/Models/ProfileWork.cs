using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class ProfileWork
    {
        [Key]
        public int WorkID { get; set; }
        public int UserId { get; set; }

        public string Institution { get; set; }
        
        [Required(ErrorMessage="Position held is Required")]
        public string Position {get; set;}

        [Required(ErrorMessage = "Job Description is Required")]
        [DataType(DataType.MultilineText)]
        public string JobDescription {get; set;}

        [Required(ErrorMessage = "Start Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Start {get; set;}

        [Required(ErrorMessage = "End Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime End {get; set;}
    }
}