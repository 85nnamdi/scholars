using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace scholarsnet.Models
{
    public class Institutions
    {
        [ScaffoldColumn(false)]
        [Key]
        public int InstitutionID { get; set; }

        [Required(ErrorMessage = "Institution name is required"), Display(Name="Name of Institution")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Abbreviation is required"), Display(Name = "Institution's Abbreviation")]
        public string Abbreviation { get; set; }

        [Display(Name="Institution Type (eg. Polytechnic)")]
        public string InstituteType { get; set; }

        [Display(Name="Funding (eg. Federal)")]
        public string Category { get; set; }
        
        [Display(Name="Year founded"), DataType(DataType.Date)]
        public string founded { get; set; }

        [Required(ErrorMessage = "Address of this institution is required")]
        public string Address { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }


        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.Url)]
        public string Wiki { get; set; }

        [ScaffoldColumn(false), Display(Name="Institution's Logo")]
        public string path { get; set; }

        public ICollection<AcademicUsers> AcademicUsers { get; set; }
        public ICollection<InstitutionViews> InstitutionViews { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<InstituteImages> InstituteImages { get; set; }
        
    }
}