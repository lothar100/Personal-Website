﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Personal_Website.Data.Context;

namespace Personal_Website.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20200815164848_MoreSummary")]
    partial class MoreSummary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Personal_Website.Data.Models.PageModuleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageCSS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageCount")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("MoreSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VideoSrc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}