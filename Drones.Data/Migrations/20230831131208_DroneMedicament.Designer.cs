﻿// <auto-generated />
using Drones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Drones.Domain.Migrations
{
    [DbContext(typeof(DronesDbContext))]
    [Migration("20230831131208_DroneMedicament")]
    partial class DroneMedicament
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DroneMedicament", b =>
                {
                    b.Property<int>("DroneId")
                        .HasColumnType("int");

                    b.Property<int>("MedicamentsId")
                        .HasColumnType("int");

                    b.HasKey("DroneId", "MedicamentsId");

                    b.HasIndex("MedicamentsId");

                    b.ToTable("DroneMedicament");
                });

            modelBuilder.Entity("Drones.Domain.Entities.Drone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CapacidadBateria")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("Modelo")
                        .HasColumnType("int");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PesoLimite")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("Drones.Domain.Entities.Medicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("DroneMedicament", b =>
                {
                    b.HasOne("Drones.Domain.Entities.Drone", null)
                        .WithMany()
                        .HasForeignKey("DroneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drones.Domain.Entities.Medicament", null)
                        .WithMany()
                        .HasForeignKey("MedicamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
