using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestUniversityEver.Models
{
    public class Teacher : Person
    {
        [Key]
        public Int64 TeacherID { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        public virtual Course Course { get; set; }
    }
}