namespace Transonline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateAndUpdateRegistration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registrations", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "UpdatedAt");
            DropColumn("dbo.Registrations", "CreatedAt");
        }
    }
}
