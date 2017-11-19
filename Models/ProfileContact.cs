using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class ProfileContact
    {
        [Key]
        public int ContactID { get; set; }
        public int UserId {get; set;}

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public String Phone1 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public String Phone2 { get; set; }

        [DataType(DataType.Url)]
        public String Website { get; set; }

        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }

    }
}