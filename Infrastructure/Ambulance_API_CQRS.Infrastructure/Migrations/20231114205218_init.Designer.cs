﻿// <auto-generated />
using System;
using Ambulance_API_CQRS.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ambulance_API_CQRS.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231114205218_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.AmbulanceDepart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CallingAmbulanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDepart")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("EndTimePatient")
                        .HasColumnType("time");

                    b.Property<string>("NameHospital")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberAccident_AssistantSquad")
                        .HasColumnType("int");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultDepart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartPatient")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeDepart")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CallingAmbulanceId")
                        .IsUnique();

                    b.HasIndex("DateDepart");

                    b.ToTable("Departs");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.CallingAmbulance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CauseCall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCall")
                        .HasColumnType("date");

                    b.Property<string>("NameOfCAllAmbulance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RedirectCall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("TimeCall")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DateCall");

                    b.ToTable("Callings");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameLocality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthYear")
                        .HasColumnType("date");

                    b.Property<int>("CallingAmbulanceId")
                        .HasColumnType("int");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("LocalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StreetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CallingAmbulanceId")
                        .IsUnique();

                    b.HasIndex("LocalityId");

                    b.HasIndex("StreetId");

                    b.HasIndex("Name", "FamilyName", "Patronymic");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LocalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberEntranceOfHouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberFlat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberHouse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.AmbulanceDepart", b =>
                {
                    b.HasOne("Ambulance_API_CQRS.Domain.Entities.CallingAmbulance", "Calling")
                        .WithOne("Departure")
                        .HasForeignKey("Ambulance_API_CQRS.Domain.Entities.AmbulanceDepart", "CallingAmbulanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calling");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Patient", b =>
                {
                    b.HasOne("Ambulance_API_CQRS.Domain.Entities.CallingAmbulance", "CallingAmbulance")
                        .WithOne("Patient")
                        .HasForeignKey("Ambulance_API_CQRS.Domain.Entities.Patient", "CallingAmbulanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambulance_API_CQRS.Domain.Entities.Locality", "Locality")
                        .WithMany("Patients")
                        .HasForeignKey("LocalityId");

                    b.HasOne("Ambulance_API_CQRS.Domain.Entities.Street", "Street")
                        .WithMany("Patients")
                        .HasForeignKey("StreetId");

                    b.Navigation("CallingAmbulance");

                    b.Navigation("Locality");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Street", b =>
                {
                    b.HasOne("Ambulance_API_CQRS.Domain.Entities.Locality", "Locality")
                        .WithMany("Streets")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locality");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.CallingAmbulance", b =>
                {
                    b.Navigation("Departure")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Locality", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Ambulance_API_CQRS.Domain.Entities.Street", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
