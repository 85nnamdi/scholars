using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class ArticleFormViewModel
    {
        public Articles Articles { get; set; }

          // Constructor 
        public ArticleFormViewModel(Articles articles)
        {
            Articles = articles;
        }
    }
}