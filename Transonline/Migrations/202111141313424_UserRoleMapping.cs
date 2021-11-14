namespace Transonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleMapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoleMappings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        RoleId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoleMappings");
        }
    }
}
