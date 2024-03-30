﻿// <auto-generated />
using System;
using AppointmentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentSystem.Persistence.Migrations
{
    [DbContext(typeof(AppointmentSqlContext))]
    partial class AppointmentSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppUserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdentifierNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppUserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdentifierNumber")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("AppUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsClosedByDoctor")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.Policlinic", b =>
                {
                    b.Property<int>("PoliclinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliclinicId"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoliclinicId");

                    b.ToTable("Policlinics");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.DoctorUser", b =>
                {
                    b.HasBaseType("AppointmentSystem.Domain.Entities.AppUser");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliclinicId")
                        .HasColumnType("int");

                    b.HasIndex("PoliclinicId");

                    b.HasDiscriminator().HasValue("DoctorUser");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.PatientUser", b =>
                {
                    b.HasBaseType("AppointmentSystem.Domain.Entities.AppUser");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PatientUser");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("AppointmentSystem.Domain.Entities.DoctorUser", "DoctorUser")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppointmentSystem.Domain.Entities.PatientUser", "PatientUser")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DoctorUser");

                    b.Navigation("PatientUser");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.DoctorUser", b =>
                {
                    b.HasOne("AppointmentSystem.Domain.Entities.Policlinic", "Policlinic")
                        .WithMany("DoctorUsers")
                        .HasForeignKey("PoliclinicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Policlinic");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.Policlinic", b =>
                {
                    b.Navigation("DoctorUsers");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.DoctorUser", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("AppointmentSystem.Domain.Entities.PatientUser", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
