using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DancingSchool.Models
{
    public class Course
    {

        public int CourseID { get; set; }
        public int SchoolID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }


        public virtual School School { get; set; }

    }
}