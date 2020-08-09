using System;
using System.ComponentModel.DataAnnotations;

namespace BestUniversityEver.Models
{
    public class Enrollment
    {
        public Int64 EnrollmentID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}

