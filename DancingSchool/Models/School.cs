using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DancingSchool.Models
{
    public class School

    {
        public int SchoolID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}