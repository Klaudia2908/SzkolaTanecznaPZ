namespace DancingSchool.Migrations
{
    using DancingSchool.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DancingSchool.dal.PortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DancingSchool.dal.PortalContext context)
        {
            var roles = new List<Role>
            {
                new Role
                {
                    role = RoleDictionary.USER
                },
                 new Role
                {
                    role = RoleDictionary.ADMIN
                }

            };

            roles.ForEach(role => context.Roles.Add(role));
            context.SaveChanges();


            var schools = new List<School>
            {
                new School{Name = "Szko³a tañca Riviera",Description = "Specjalizujemy siê w tañcach towarzyskich ale w ofercie posiadamy te¿ inne style." +
                "Zapraszamy do zapoznania siê z ofert¹" },

                new School{Name = "Szko³a tañca \"Roztañczona\"",Description = "Specjalizujemy siê w tañcach nowoczesnych ale w ofercie posiadamy te¿ inne style." +
                "Zapraszamy m³odszych i starszych" },

                new School{Name = "Szko³a tañca Fokus",Description = "Zatañcz z nami póki czas" }

            };
            schools.ForEach(s => context.Schools.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{SchoolID = 1,Title = "Taniec towarzyski",Description = "Kurs tañca towarzyskiego skupia siê na tañcach latynoamerykañski i standardowych", Price = 130 },

                new Course{SchoolID = 1,Title = "Taniec nowoczesny",Description = "Ruchy do szybkiej muzyki", Price = 100 },

                new Course{ SchoolID = 2, Title = "Salsa",Description = "Taniec latynoski. Mo¿na tañczyæ solo jak i w parze", Price = 90 },

                new Course{ SchoolID = 3, Title = "Ladies Latino",Description = "Kurs specjalny dla Pañ z tañcami latynoamerykañskimi", Price = 150 }


            };
            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var people = new List<People>
            {
                new People{FirstName="Karolina",LastName="Nowak",BirthDay=DateTime.Parse("2005-09-01")},

                new People{FirstName="Magda",LastName="Zieleñ",BirthDay=DateTime.Parse("1996-06-22")},

                new People{FirstName="Andrzej",LastName="Zimny",BirthDay=DateTime.Parse("1995-03-17")},

                new People{FirstName="£ukasz",LastName="Œwietlnik",BirthDay=DateTime.Parse("1997-10-05")},


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
