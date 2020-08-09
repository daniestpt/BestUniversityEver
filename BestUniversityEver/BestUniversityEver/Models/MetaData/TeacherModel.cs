using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestUniversityEver.Models.MetaData
{
    public class TeacherModel
    {
        public Int64 TeacherID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime? BirthDay { get; set; }

        public decimal Salary { get; set; }

    }
}