using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    
        public class MyPaper
        {
            public int ID { get; set; }
            public int UserId { get; set; }
            public string Title { get; set; }
            public string Contributors { get; set; }
            public string Content { get; set; }
            public string path { get; set; }
            public DateTime DatePosted { get; set; }
            public string FileType { get; set; }
            public int ReadCount { get; set; }
        }
    
}