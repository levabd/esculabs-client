namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePatientsAndPhysiciansTables : DbMigration
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
            
            CreateTable(
                "public.physicians",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        login = c.String(nullable: false),
                        password = c.String(nullable: false),
                        first_name = c.String(nullable: false, maxLength: 255),
                        middle_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        position = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.login, unique: true, name: "IX_Login");
            
        }
        
        public override void Down()
        {
            DropIndex("public.physicians", "IX_Login");
            DropIndex("public.patients", "IX_Iin");
            DropTable("public.physicians");
            DropTable("public.patients");
        }
    }
}
