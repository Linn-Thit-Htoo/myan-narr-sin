﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyanNarrSinApi;

#nullable disable

namespace MyanNarrSinApi.Migrations
{
    [DbContext(typeof(MyanNarrSinDbContext))]
    [Migration("20231002085457_Second Migration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyanNarrSinApi.Models.UserModel", b =>
                {
                    b.Property<Guid>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
