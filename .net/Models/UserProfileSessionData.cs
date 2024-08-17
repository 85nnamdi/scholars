using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    [Serializable]
    public class UserProfileSessionData
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string Institution { get; set; }
        public string UserType { get; set; }
    }
}