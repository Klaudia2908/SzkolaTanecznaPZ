using DancingSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DancingSchool.dal
{
    public class PortalInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<PortalContext>
    {
        protected override void Seed(PortalContext context)
        {
            var schools = new List<School>
            {
                new School{Name = "Szkoła tańca Riviera",Description = "Specjalizujemy się w tańcach towarzyskich ale w ofercie posiadamy też inne style." +
                "Zapraszamy do zapoznania się z ofertą" },

                new School{Name = "Szkoła tańca \"Roztańczona\"",Description = "Specjalizujemy się w tańcach nowoczesnych ale w ofercie posiadamy też inne style." +
                "Zapraszamy młodszych i starszych" },

                new School{Name = "Szkoła tańca Fokus",Description = "Zatańcz z nami póki czas" }

            };
            schools.ForEach(s => context.Schools.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{SchoolID = 1,Title = "Taniec towarzyski",Description = "Kurs tańca towarzyskiego skupia się na tańcach latynoamerykański i standardowych", Price = 130 },

                new Course{SchoolID = 1,Title = "Taniec nowoczesny",Description = "Ruchy do szybkiej muzyki", Price = 100 },

                new Course{ SchoolID = 2, Title = "Salsa",Description = "Taniec latynoski. Można tańczyć solo jak i w parze", Price = 90 },
                                
                new Course{ SchoolID = 3, Title = "Ladies Latino",Description = "Kurs specjalny dla Pań z tańcami latynoamerykańskimi", Price = 150 }


            };
            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var people = new List<People>
            {
                new People{FirstName="Karolina",LastName="Nowak",BirthDay=DateTime.Parse("2005-09-01")},

                new People{FirstName="Magda",LastName="Zieleń",BirthDay=DateTime.Parse("1996-06-22")},

                new People{FirstName="Andrzej",LastName="Zimny",BirthDay=DateTime.Parse("1995-03-17")},

                new People{FirstName="Łukasz",LastName="Świetlnik",BirthDay=DateTime.Parse("1997-10-05")},


            };
            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();


            var enrolments = new List<Enrolment>
            {
            new Enrolment{CourseID=1,PeopleID=1},
            new Enrolment{CourseID=2,PeopleID=2},
            new Enrolment{CourseID=3,PeopleID=2},
            new Enrolment{CourseID=1,PeopleID=3}
            };
            enrolments.ForEach(e => context.Enrolments.Add(e));
            context.SaveChanges();
        }

    }
}