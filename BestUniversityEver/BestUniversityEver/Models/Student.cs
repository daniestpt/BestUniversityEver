using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestUniversityEver.Models
{
    public class Student : Person
    {
        [Key]
        public Int64 StudentID { get; set; }
    }
}