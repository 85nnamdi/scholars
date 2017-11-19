using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class Articles
    {
        [Key]
        public int ArticleID { get; set; }

        public int UserId { get; set; }

        [MaxLength(350, ErrorMessage = "Title of this article Cannot be more than 66 characters")]
        [Required(ErrorMessage = "Title of this article is required")]
        public string Title { get; set; }

        public string Contributors { get; set; }

        [MaxLength(35000, ErrorMessage = "You have exceeded the maximum allowed characters for decription")]
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Article { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [ScaffoldColumn(false)]
        public string fileType { get; set; }

        public string tag { get; set; }// tags are used to determine where an article can be placed or found in a search
        
        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

        public ICollection<ArticleViews> ArticleViews { get; set; }
    }
}