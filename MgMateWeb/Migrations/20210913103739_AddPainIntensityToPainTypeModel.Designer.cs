﻿// <auto-generated />
using System;
using MgMateWeb.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMateWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210913103739_AddPainIntensityToPainTypeModel")]
    partial class AddPainIntensityToPainTypeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.AccompanyingSymptom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("AccompanyingSymptoms");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DurationOfActivity")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DurationOfIncapacitation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PainDuration")
                        .HasColumnType("datetime2");

                    b.Property<int>("PainIntensity")
                        .HasColumnType("int");

                    b.Property<bool>("WasPainIncreasedDuringPhysicalActivity")
                        .HasColumnType("bit");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("MedicationEffectiveness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.PainType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("PainIntensity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("PainTypes");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Trigger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EntryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("Triggers");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.WeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.AccompanyingSymptom", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.Entry", null)
                        .WithMany("AccompanyingSymptoms")
                        .HasForeignKey("EntryId");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Entry", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.WeatherData", "WeatherData")
                        .WithMany()
                        .HasForeignKey("WeatherDataId");

                    b.Navigation("WeatherData");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Medication", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.Entry", null)
                        .WithMany("Medications")
                        .HasForeignKey("EntryId");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.PainType", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.Entry", null)
                        .WithMany("PainTypes")
                        .HasForeignKey("EntryId");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Trigger", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.Entry", null)
                        .WithMany("Triggers")
                        .HasForeignKey("EntryId");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Entry", b =>
                {
                    b.Navigation("AccompanyingSymptoms");

                    b.Navigation("Medications");

                    b.Navigation("PainTypes");

                    b.Navigation("Triggers");
                });
#pragma warning restore 612, 618
        }
    }
}
