using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class InstituteNews
    {
        [ScaffoldColumn(false)]
        [Key]
        public int NewsID { get; set; }

        [ScaffoldColumn(false)]
        public int InstitutionID { get; set; }

        [MaxLength(450, ErrorMessage = "Title of this news cannot be more than 66 characters")]
        [Required(ErrorMessage = "News is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime NewsDate { get; set; }

        [MaxLength(25000, ErrorMessage = "New Cannot be more than 25,000 characters")]
        [DataType(DataType.MultilineText), Display(Name = "Write the news")]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [Display(Name = "Posted by")]
        public String PostedBy { get; set; }

        [DataType(DataType.PhoneNumber), Display(Name = "Contact phone")]
        public string ContactPhone { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "Contact email")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime NewsExpiryDate { get; set; }
    }
}