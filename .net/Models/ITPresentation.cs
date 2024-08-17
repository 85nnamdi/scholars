using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class ITPresentation
    {
        [Key]
        public int ITPresentationID { get; set; }

        public int UserId { get; set; }

        [MaxLength(250, ErrorMessage = "Title of this article Cannot be more than 66 characters")]
        [Required(ErrorMessage = "Title of this article is required")]
        public string Title { get; set; }

        public string Author { get; set; }

        [MaxLength(20000, ErrorMessage = "You have exceeded the maximum allowed characters for decription")]
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string ItPresentation { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [ScaffoldColumn(false)]
        public string fileType { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

       // public ICollection<ArticleViews> ArticleViews { get; set; }
    }
}