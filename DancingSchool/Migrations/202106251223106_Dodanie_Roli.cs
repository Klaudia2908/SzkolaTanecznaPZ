namespace DancingSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dodanie_Roli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        idRole = c.Int(nullable: false, identity: true),
                        role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRole);
            
            AddColumn("dbo.User", "RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Role_idRole", c => c.Int());
            CreateIndex("dbo.User", "Role_idRole");
            AddForeignKey("dbo.User", "Role_idRole", "dbo.Role", "idRole");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Role_idRole", "dbo.Role");
            DropIndex("dbo.User", new[] { "Role_idRole" });
            DropColumn("dbo.User", "Role_idRole");
            DropColumn("dbo.User", "RoleID");
            DropTable("dbo.Role");
        }
    }
}
