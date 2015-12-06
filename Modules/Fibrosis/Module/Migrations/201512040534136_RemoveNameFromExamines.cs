namespace Fibrosis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameFromExamines : DbMigration
    {
        public override void Up()
        {
            DropColumn("fibrosis.examines", "name");
        }
        
        public override void Down()
        {
            AddColumn("fibrosis.examines", "name", c => c.String(nullable: false));
        }
    }
}
