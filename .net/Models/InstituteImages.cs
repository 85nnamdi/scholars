using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class InstituteImages
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public int InstitutionID { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [Display(Name="Image Caption")]
        public string caption { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }
    }
}