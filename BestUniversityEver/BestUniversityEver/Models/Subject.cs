using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestUniversityEver.Models
{
    public class Subject
    {
        [Key]
        public Int64 SubjectID { get; set; }

        public string SubjectName { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}