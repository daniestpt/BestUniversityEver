using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestUniversityEver.Models.MetaData
{
    public class CourseModel
    {
        public Int64 CourseID { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public int TeachersCount { get; set; }
    }
}