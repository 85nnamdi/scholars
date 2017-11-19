using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }

        public int UserId { get; set; }

        [MaxLength(450, ErrorMessage = "Title of this book Cannot be more than 66 characters")]
        [Required(ErrorMessage = "Title of this article is required")]
        public string Title { get; set; }

        public string Contributors { get; set; }

        [Display(Name=" Book's Discipline")]
        public string Discipline { get; set; } //This is the discipline where this book can be placed.

        [MaxLength(35000, ErrorMessage = "You have exceeded the maximum allowed characters for decription")]
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Book Description or Abstract")]
        [DataType(DataType.MultilineText)]
        public string Book { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [ScaffoldColumn(false)]
        public string fileType { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

        public ICollection<BookViews> BookViews { get; set; }
    }
}