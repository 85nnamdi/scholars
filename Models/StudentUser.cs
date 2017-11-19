using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    [Table("StudentUser")]
    public class StudentUser
    {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string UserName { get; set; }

            [Required(ErrorMessage = "First name is required.")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required.")]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            //[Required(ErrorMessage = "Date of birth is required")]
            //[Display(Name = "Date of Birth")]
            //[DataType(DataType.Date)]
            //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
            //public DateTime DOB { get; set; }

            [Required]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [DisplayName("Institution")]
            public int InstitutionID { get; set; }

            // [Required(ErrorMessage = "Select a User Type")]
            [Display(Name = "User Category")]
            public string UserType { get; set; }

            [Display(Name = "Photo")]
            public string Photo { get; set; }

            [DataType(DataType.DateTime)]
            public DateTime DateRegistered { get; set; }

            [DisplayName("Full name")]
            public string FullName
            {
                get
                {
                    return LastName + ", " + FirstName;
                }
            }
            //public bool IsUserRegistered(string userName)
            //{

            //    return Follower.Any(r => r.FollowerName.Equals(userName,
            //                           StringComparison.InvariantCultureIgnoreCase));
            //}

            

            //public ICollection<UserViews> UserViews { get; set; }
            //public ICollection<Follower> Follower { get; set; }
            //public ICollection<ProfileWork> ProfileWork { get; set; }
            //public ICollection<ProfilePhoto> ProfilePhoto { get; set; }
            //public ICollection<ProfileCourses> ProfileCourse { get; set; }
        }
    }


