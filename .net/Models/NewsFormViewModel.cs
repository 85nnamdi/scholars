using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class NewsFormViewModel
    {
        public News News { get; set; }

        public NewsFormViewModel(News news)
        {
            News = news;
        }
    }
}