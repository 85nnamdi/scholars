using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class NewsLetter
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}