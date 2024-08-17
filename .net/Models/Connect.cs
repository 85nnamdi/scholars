using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace scholarsnet.Models
{
    public class Connect
    {
        public int ConnectID { get; set; }
        public int UserId { get; set; }
        
        [DataType(DataType.Url)]
        public string Blog { get; set; }

        public string UserName { get; set; }
    }
}