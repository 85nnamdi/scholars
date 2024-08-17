using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class Events
    {
        [Key]
        public int EventID { get; set; }
        public int UserId { get; set; }

        [MaxLength(450, ErrorMessage = "Title of this article Cannot be more than 66 characters")]
        [Required(ErrorMessage = "Title of this article is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [MaxLength(10000, ErrorMessage = "You have exceeded the maximum allowed characters for decription")]
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string HostedBy { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        public string EventAddress { get; set; }


        //Repository methods
        public bool IsHostedBy(string userName)
        {

            return HostedBy.Equals(userName,
                                   StringComparison.InvariantCultureIgnoreCase);
        }

        public ICollection<EventAttendance> EventAttendance { get; set; }
    }
}