namespace EsculabsCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEsculabsTables : DbMigration
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
            
            CreateTable(
                "public.roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.physicians_roles",
                c => new
                    {
                        physician_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.physician_id, t.role_id })
                .ForeignKey("public.physicians", t => t.physician_id, cascadeDelete: true)
                .ForeignKey("public.roles", t => t.role_id, cascadeDelete: true)
                .Index(t => t.physician_id)
                .Index(t => t.role_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.physicians_roles", "role_id", "public.roles");
            DropForeignKey("public.physicians_roles", "physician_id", "public.physicians");
            DropIndex("public.physicians_roles", new[] { "role_id" });
            DropIndex("public.physicians_roles", new[] { "physician_id" });
            DropIndex("public.physicians", "IX_Login");
            DropIndex("public.patients", "IX_Iin");
            DropTable("public.physicians_roles");
            DropTable("public.roles");
            DropTable("public.physicians");
            DropTable("public.patients");
        }
    }
}
