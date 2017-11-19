using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scholarsnet.Models
{
    public class AcademicUserFormModel
    {
        public AcademicUsers AcademicUsers { get; set; }

          // Constructor 
        public AcademicUserFormModel(AcademicUsers academicUser)
        {
            AcademicUsers = academicUser;
        }
    }
}

