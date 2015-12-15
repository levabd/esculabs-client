namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.roles", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.roles", "description");
        }
    }
}
