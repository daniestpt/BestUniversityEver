using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestUniversityEver.Models.MetaData
{
    public class SubjectModel
    {
        public Int64 SubjectID { get; set; }

        public string SubjectName { get; set; }

        public string  TeacherName { get; set; }
        public virtual ICollection<Student> Student { get; set; }

        public Teacher Teacher { get; set; }

    }
}