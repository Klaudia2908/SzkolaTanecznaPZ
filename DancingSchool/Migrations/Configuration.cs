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
                new School{Name = "Szko�a ta�ca Riviera",Description = "Specjalizujemy si� w ta�cach towarzyskich ale w ofercie posiadamy te� inne style." +
                "Zapraszamy do zapoznania si� z ofert�" },

                new School{Name = "Szko�a ta�ca \"Rozta�czona\"",Description = "Specjalizujemy si� w ta�cach nowoczesnych ale w ofercie posiadamy te� inne style." +
                "Zapraszamy m�odszych i starszych" },

                new School{Name = "Szko�a ta�ca Fokus",Description = "Zata�cz z nami p�ki czas" }

            };
            schools.ForEach(s => context.Schools.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{SchoolID = 1,Title = "Taniec towarzyski",Description = "Kurs ta�ca towarzyskiego skupia si� na ta�cach latynoameryka�ski i standardowych", Price = 130 },

                new Course{SchoolID = 1,Title = "Taniec nowoczesny",Description = "Ruchy do szybkiej muzyki", Price = 100 },

                new Course{ SchoolID = 2, Title = "Salsa",Description = "Taniec latynoski. Mo�na ta�czy� solo jak i w parze", Price = 90 },

                new Course{ SchoolID = 3, Title = "Ladies Latino",Description = "Kurs specjalny dla Pa� z ta�cami latynoameryka�skimi", Price = 150 }


            };
            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var people = new List<People>
            {
                new People{FirstName="Karolina",LastName="Nowak",BirthDay=DateTime.Parse("2005-09-01")},

                new People{FirstName="Magda",LastName="Ziele�",BirthDay=DateTime.Parse("1996-06-22")},

                new People{FirstName="Andrzej",LastName="Zimny",BirthDay=DateTime.Parse("1995-03-17")},

                new People{FirstName="�ukasz",LastName="�wietlnik",BirthDay=DateTime.Parse("1997-10-05")},


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
