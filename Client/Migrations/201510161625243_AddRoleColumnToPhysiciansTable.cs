namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    public partial class AddRoleColumnToPhysiciansTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.physicians", "role", c => c.Int(nullable: false, defaultValue: (int)PhysicianRole.Physician));
        }
        
        public override void Down()
        {
            DropColumn("public.physicians", "role");
        }
    }
}
