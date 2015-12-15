namespace Fibrosis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFibxSourceToExamines : DbMigration
    {
        public override void Up()
        {
            AddColumn("fibrosis.examines", "fibx_source", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("fibrosis.examines", "fibx_source");
        }
    }
}
