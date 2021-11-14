namespace Transonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsernameAsPKRegistration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Registrations");
            AlterColumn("dbo.Registrations", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Registrations", new[] { "Email", "Username" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Registrations");
            AlterColumn("dbo.Registrations", "Username", c => c.String());
            AddPrimaryKey("dbo.Registrations", "Email");
        }
    }
}
