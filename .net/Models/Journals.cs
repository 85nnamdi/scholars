using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class Journals
    {
        [Key]
        public int JournalID { get; set; }

        public int UserId { get; set; }

        [MaxLength(450, ErrorMessage = "Journal title Cannot be more than 200 characters")]
        [Required(ErrorMessage = "Project topic is required")]
        public string Topic { get; set; }

        public string Contributors { get; set; }

        [MaxLength(35000, ErrorMessage = "Mximum allowed characters exceeded")]
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Journal Description")]
        [DataType(DataType.MultilineText)]
        public string JournalDescription { get; set; }

        [ScaffoldColumn(false)]
        public string path { get; set; }

        [Required(ErrorMessage="You did not provide journal type")]
        public string journalOf { get; set; } //Eg. Journal of Science

        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }

        public ICollection<JournalViews> JournalViews { get; set; }
    }
}