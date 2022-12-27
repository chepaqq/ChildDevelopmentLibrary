﻿// <auto-generated />
using System;
using ChildDevelopmentLibrary.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChildDevelopmentLibrary.DAL.Migrations
{
    [DbContext(typeof(DBWebsite))]
    [Migration("20221226162105_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChildDevelopmentLibrary.DAL.Entities.Child", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("ChildDevelopmentLibrary.DAL.Entities.EducationalProgram", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("ChildDevelopmentLibrary.DAL.Entities.Child", b =>
                {
                    b.HasOne("ChildDevelopmentLibrary.DAL.Entities.EducationalProgram", "Program")
                        .WithMany("Children")
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("ChildDevelopmentLibrary.DAL.Entities.EducationalProgram", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
