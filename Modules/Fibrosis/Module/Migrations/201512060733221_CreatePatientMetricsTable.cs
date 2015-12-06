namespace Fibrosis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePatientMetricsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fibrosis.patient_metrics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        patient_id = c.Int(nullable: false),
                        tp = c.Double(),
                        scd = c.Double(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("fibrosis.patient_metrics");
        }
    }
}
