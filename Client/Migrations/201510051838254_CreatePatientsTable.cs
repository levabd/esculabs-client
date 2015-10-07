namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePatientsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 255),
                        middle_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        birthdate = c.DateTime(nullable: false, storeType: "date"),
                        iin = c.String(nullable: false, maxLength: 12, fixedLength: true),
                        gender = c.Int(nullable: false),
                        blood_group = c.Int(),
                        rh_factor = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.iin, unique: true, name: "IX_Iin");
            
        }
        
        public override void Down()
        {
            DropIndex("public.patients", "IX_Iin");
            DropTable("public.patients");
        }
    }
}
