using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BestUniversityEver.Models
{
    public class Grade
    {
        public Int64 GradeID { get; set; }

        public decimal GradeValue { get; set; }

        public virtual Subject Subject { get; set; }


        public virtual Student Student { get; set; }
    }
}