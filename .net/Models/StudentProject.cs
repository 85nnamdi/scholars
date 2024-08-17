using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class StudentProject
    {
        [Key]
        public int StudentProjectID { get; set; }

        public int UserId { get; set; }

        [MaxLength(200, ErrorMessage = "Research title Cannot be more than 200 characters")]
        [Required(ErrorMessage = "Project topic is required")]
        public string Topic { get; set; }

        public string Author { get; set; }

        [MaxLength(20000, ErrorMessage = "Mximum allowed characters exceeded")]
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Research Description")]
        [DataType(DataType.MultilineText)]
        public string ResearchDescription { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

        public ICollection<StudentProjectViews> StudentProjectViews { get; set; }
    }

   
}