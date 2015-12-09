namespace Fibrosis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFibrosisTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fibrosis.examines",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        patient_id = c.Int(nullable: false),
                        physician_id = c.Int(nullable: false),
                        sensor_type = c.Int(nullable: false),
                        e_med = c.Double(nullable: false),
                        e_iqr = c.Double(nullable: false),
                        duration = c.Int(nullable: false),
                        whisker_plot = c.Binary(),
                        valid = c.Boolean(nullable: false),
                        expert_status = c.Int(nullable: false),
                        created_at = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "fibrosis.measures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        source = c.Binary(),
                        result_merged = c.Binary(),
                        result_mode_a = c.Binary(),
                        result_mode_m = c.Binary(),
                        result_elasto = c.Binary(),
                        validation_mode_a = c.Int(nullable: false),
                        validation_mode_m = c.Int(nullable: false),
                        validation_elasto = c.Int(nullable: false),
                        stiffness = c.Double(nullable: false),
                        created_at = c.DateTime(storeType: "date"),
                        Examine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("fibrosis.examines", t => t.Examine_Id)
                .Index(t => t.Examine_Id);
            
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
            DropForeignKey("fibrosis.measures", "Examine_Id", "fibrosis.examines");
            DropIndex("fibrosis.measures", new[] { "Examine_Id" });
            DropTable("fibrosis.patient_metrics");
            DropTable("fibrosis.measures");
            DropTable("fibrosis.examines");
        }
    }
}
