using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestUniversityEver.Models
{
    public class Course
    {
        [Key]
        public Int64 CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}