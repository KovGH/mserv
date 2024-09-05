﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seminar;

#nullable disable

namespace ConsoleApp1.Migrations
{
    [DbContext(typeof(ProduktContext))]
    partial class ProduktContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Seminar.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktId"));

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gewicht")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hersteller")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lagerbestand")
                        .HasColumnType("int");

                    b.Property<string>("Lieferzeit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProduktId");

                    b.ToTable("Produkte");
                });
#pragma warning restore 612, 618
        }
    }
}
