namespace Transonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleMappingLazyLoading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRoleMappings", "registration_Email", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRoleMappings", "registration_Username", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRoleMappings", "role_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserRoleMappings", new[] { "registration_Email", "registration_Username" });
            CreateIndex("dbo.UserRoleMappings", "role_Id");
            AddForeignKey("dbo.UserRoleMappings", new[] { "registration_Email", "registration_Username" }, "dbo.Registrations", new[] { "Email", "Username" });
            AddForeignKey("dbo.UserRoleMappings", "role_Id", "dbo.Roles", "Id");
            DropColumn("dbo.UserRoleMappings", "Username");
            DropColumn("dbo.UserRoleMappings", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRoleMappings", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoleMappings", "Username", c => c.String());
            DropForeignKey("dbo.UserRoleMappings", "role_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRoleMappings", new[] { "registration_Email", "registration_Username" }, "dbo.Registrations");
            DropIndex("dbo.UserRoleMappings", new[] { "role_Id" });
            DropIndex("dbo.UserRoleMappings", new[] { "registration_Email", "registration_Username" });
            DropColumn("dbo.UserRoleMappings", "role_Id");
            DropColumn("dbo.UserRoleMappings", "registration_Username");
            DropColumn("dbo.UserRoleMappings", "registration_Email");
        }
    }
}
