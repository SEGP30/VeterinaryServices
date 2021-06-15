﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeterinaryServices.Infrastructure;

namespace VeterinaryServices.Infrastructure.Migrations
{
    [DbContext(typeof(VeterinaryServicesContext))]
    partial class VeterinaryServicesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.AestheticService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PetId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PetId");

                    b.ToTable("AestheticServices");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Names")
                        .HasColumnType("text");

                    b.Property<string>("Surnames")
                        .HasColumnType("text");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Names")
                        .HasColumnType("text");

                    b.Property<string>("Surnames")
                        .HasColumnType("text");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.Hospitalization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Observation")
                        .HasColumnType("text");

                    b.Property<long?>("PetId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PetId");

                    b.ToTable("Hospitalizations");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.MedicalAppointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Observation")
                        .HasColumnType("text");

                    b.Property<long?>("PetId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PetId");

                    b.ToTable("MedicalAppointments");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Kind")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Profile")
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.AestheticService", b =>
                {
                    b.HasOne("VeterinaryServices.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("VeterinaryServices.Domain.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Doctor");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.Hospitalization", b =>
                {
                    b.HasOne("VeterinaryServices.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("VeterinaryServices.Domain.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Doctor");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VeterinaryServices.Domain.Entities.MedicalAppointment", b =>
                {
                    b.HasOne("VeterinaryServices.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("VeterinaryServices.Domain.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Doctor");

                    b.Navigation("Pet");
                });
#pragma warning restore 612, 618
        }
    }
}
