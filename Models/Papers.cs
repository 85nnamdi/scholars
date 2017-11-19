using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class Papers
    {
         [Key]
            public int PapersID { get; set; }

            public int UserId { get; set; }

            [MaxLength(150, ErrorMessage = "Title of this paper Cannot be more than 100 characters")]
            [Required(ErrorMessage = "Title of this paper is required")]
            public string Title { get; set; }

            public string PaperType { get; set; }

            public string Contributors { get; set; }

            [Required(ErrorMessage = "Description Required")]
            [Display(Name = "Description")]
            [DataType(DataType.MultilineText)]
            public string PaperContent { get; set; }

            [DataType(DataType.Upload)]
            public string Path { get; set; }

            [ScaffoldColumn(false)]
            public string dataType { get; set; }

            [Required(ErrorMessage = "Date Required")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            public DateTime DatePosted { get; set; }

            public ICollection<PaperView> PaperViews { get; set; }
        
    }
}