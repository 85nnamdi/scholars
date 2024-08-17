using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class ProfileCourses
    {
        [Key]
        public int CourseID { get; set; }
        public int UserId { get; set; }

        [MaxLength(20, ErrorMessage = "Course code Cannot be more than 20 characters")] 
        public string CourseCode { get; set; }

        [MaxLength(30, ErrorMessage = "Course title Cannot be more than 30 characters")]
        public string CourseTitle { get; set; }

        [MaxLength(60, ErrorMessage = "Institution Cannot be more than 60 characters")]
        public string Institution { get; set; }
    }
}