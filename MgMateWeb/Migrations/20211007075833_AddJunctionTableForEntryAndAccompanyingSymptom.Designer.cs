﻿// <auto-generated />
using System;
using MgMateWeb.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MgMateWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211007075833_AddJunctionTableForEntryAndAccompanyingSymptom")]
    partial class AddJunctionTableForEntryAndAccompanyingSymptom
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

                    b.Property<float>("HoursOfActivity")
                        .HasColumnType("real");

                    b.Property<float>("HoursOfIncapacitation")
                        .HasColumnType("real");

                    b.Property<float>("HoursOfPain")
                        .HasColumnType("real");

                    b.Property<bool>("WasPainIncreasedDuringPhysicalActivity")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("MgMateWeb.Models.RelationshipModels.EntryAccompanyingSymptom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccompanyingSymptomId")
                        .HasColumnType("int");

                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccompanyingSymptomId");

                    b.HasIndex("EntryId");

                    b.ToTable("EntryAccompanyingSymptoms");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.AccompanyingSymptom", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.Entry", null)
                        .WithMany("AccompanyingSymptoms")
                        .HasForeignKey("EntryId");
                });

            modelBuilder.Entity("MgMateWeb.Models.RelationshipModels.EntryAccompanyingSymptom", b =>
                {
                    b.HasOne("MgMateWeb.Models.EntryModels.AccompanyingSymptom", "AccompanyingSymptom")
                        .WithMany()
                        .HasForeignKey("AccompanyingSymptomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MgMateWeb.Models.EntryModels.Entry", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccompanyingSymptom");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("MgMateWeb.Models.EntryModels.Entry", b =>
                {
                    b.Navigation("AccompanyingSymptoms");
                });
#pragma warning restore 612, 618
        }
    }
}
