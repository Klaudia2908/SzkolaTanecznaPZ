namespace DancingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanieTabeliUsera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
