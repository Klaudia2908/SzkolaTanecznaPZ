namespace DancingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        SchoolID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.School", t => t.SchoolID, cascadeDelete: true)
                .Index(t => t.SchoolID);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        SchoolID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SchoolID);
            
            CreateTable(
                "dbo.Enrolment",
                c => new
                    {
                        EnrolmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        PeopleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrolmentID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PeopleID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.PeopleID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrolment", "PeopleID", "dbo.People");
            DropForeignKey("dbo.Enrolment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "SchoolID", "dbo.School");
            DropIndex("dbo.Enrolment", new[] { "PeopleID" });
            DropIndex("dbo.Enrolment", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "SchoolID" });
            DropTable("dbo.People");
            DropTable("dbo.Enrolment");
            DropTable("dbo.School");
            DropTable("dbo.Course");
        }
    }
}
