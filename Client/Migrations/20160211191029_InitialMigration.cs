using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Client.Migrations
{
    public partial class InitialMigration : Migration
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
                name: "PatientMetric",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientIin = table.Column<string>(nullable: false),
                    Scd = table.Column<double>(nullable: true),
                    Tp = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMetric", x => x.Id);
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
            migrationBuilder.CreateTable(
                name: "Examine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    ExpertStatus = table.Column<int>(nullable: false),
                    FibxSource = table.Column<string>(nullable: true),
                    Iqr = table.Column<double>(nullable: false),
                    Med = table.Column<double>(nullable: false),
                    PatientIin = table.Column<string>(nullable: false),
                    PatientMetricId = table.Column<int>(nullable: true),
                    SensorType = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Valid = table.Column<bool>(nullable: false),
                    WhiskerPlot = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examine_Patient_PatientIin",
                        column: x => x.PatientIin,
                        principalTable: "Patient",
                        principalColumn: "Iin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examine_PatientMetric_PatientMetricId",
                        column: x => x.PatientMetricId,
                        principalTable: "PatientMetric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examine_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ExamineId = table.Column<int>(nullable: false),
                    ResultMerged = table.Column<byte[]>(nullable: true),
                    Source = table.Column<byte[]>(nullable: true),
                    Stiffness = table.Column<double>(nullable: false),
                    ValidationElasto = table.Column<int>(nullable: false),
                    ValidationModeA = table.Column<int>(nullable: false),
                    ValidationModeM = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measure_Examine_ExamineId",
                        column: x => x.ExamineId,
                        principalTable: "Examine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Measure");
            migrationBuilder.DropTable("Examine");
            migrationBuilder.DropTable("Patient");
            migrationBuilder.DropTable("PatientMetric");
            migrationBuilder.DropTable("User");
        }
    }
}
