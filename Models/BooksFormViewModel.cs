using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class BooksFormViewModel
    {
         public Books Books { get; set; }

          // Constructor 
        public BooksFormViewModel(Books books)
        {
            Books = books;
        }
    }
}