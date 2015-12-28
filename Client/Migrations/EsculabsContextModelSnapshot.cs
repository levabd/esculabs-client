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
        }
    }
}
