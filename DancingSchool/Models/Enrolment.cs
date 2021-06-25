using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DancingSchool.Models
{
    public class Enrolment
    {
        public int EnrolmentID { get; set; }
        public int CourseID { get; set; }
        public int PeopleID { get; set; }

        public virtual Course Course { get; set; }
        public virtual People People { get; set; }
    }
}