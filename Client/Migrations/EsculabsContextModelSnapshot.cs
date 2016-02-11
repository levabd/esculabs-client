using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Client.Context;

namespace Client.Migrations
{
    [DbContext(typeof(EsculabsContext))]
    partial class EsculabsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Client.Models.Examine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<int>("Duration");

                    b.Property<int>("ExpertStatus");

                    b.Property<string>("FibxSource");

                    b.Property<double>("Iqr");

                    b.Property<double>("Med");

                    b.Property<string>("PatientIin")
                        .IsRequired();

                    b.Property<int?>("PatientMetricId");

                    b.Property<string>("SensorType");

                    b.Property<int?>("UserId");

                    b.Property<bool>("Valid");

                    b.Property<byte[]>("WhiskerPlot");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Client.Models.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<int?>("ExamineId")
                        .IsRequired();

                    b.Property<byte[]>("ResultMerged");

                    b.Property<byte[]>("Source");

                    b.Property<double>("Stiffness");

                    b.Property<int>("ValidationElasto");

                    b.Property<int>("ValidationModeA");

                    b.Property<int>("ValidationModeM");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Client.Models.Patient", b =>
                {
                    b.Property<string>("Iin");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int?>("BloodGroup");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName")
                        .IsRequired();

                    b.Property<bool?>("RhFactor");

                    b.HasKey("Iin");
                });

            modelBuilder.Entity("Client.Models.PatientMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PatientIin")
                        .IsRequired();

                    b.Property<double?>("Scd");

                    b.Property<double?>("Tp");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Client.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("MiddleName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Position")
                        .IsRequired();

                    b.Property<int>("Role");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Client.Models.Examine", b =>
                {
                    b.HasOne("Client.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientIin");

                    b.HasOne("Client.Models.PatientMetric")
                        .WithMany()
                        .HasForeignKey("PatientMetricId");

                    b.HasOne("Client.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Client.Models.Measure", b =>
                {
                    b.HasOne("Client.Models.Examine")
                        .WithMany()
                        .HasForeignKey("ExamineId");
                });
        }
    }
}
