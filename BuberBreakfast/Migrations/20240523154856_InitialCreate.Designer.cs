﻿// <auto-generated />
using System;
using BuberBreakfast.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuberBreakfast.Migrations
{
    [DbContext(typeof(YourDbContext))]
    [Migration("20240523154856_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuberBreakfast.Models.Breakfast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Savory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sweet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Breakfasts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("94e70a61-7e9a-4e18-8819-135734ba6a11"),
                            Description = "Vegan everything! Join us for a healthy breakfast.",
                            EndDateTime = new DateTime(2022, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedDateTime = new DateTime(2024, 5, 23, 12, 58, 14, 418, DateTimeKind.Utc).AddTicks(4169),
                            Name = "Vegan Sunshine",
                            Savory = "[\"Oatmeal\",\"Avocado Toast\",\"Omelette\",\"Salad\"]",
                            StartDateTime = new DateTime(2022, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Sweet = "[\"Cookie\"]"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
