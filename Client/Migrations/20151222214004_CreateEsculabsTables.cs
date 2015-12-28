using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Client.Migrations
{
    public partial class CreateEsculabsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Iin = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    RhFactor = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Iin);
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Patient");
            migrationBuilder.DropTable("User");
        }
    }
}
