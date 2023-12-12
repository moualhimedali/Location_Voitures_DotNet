﻿// <auto-generated />
using System;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230903164957_LocationVoiturePhotoDaliDB")]
    partial class LocationVoiturePhotoDaliDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.ApplicationCore.Domain.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroTelephone")
                        .HasColumnType("int");

                    b.Property<string>("PermisConduire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Contrat", b =>
                {
                    b.Property<int>("NumeroContrat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroContrat"));

                    b.Property<DateTime>("DateDebutContrat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinContrat")
                        .HasColumnType("datetime2");

                    b.Property<int>("NombreJoursLocation")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("VoitureId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NumeroContrat");

                    b.HasIndex("ReservationId");

                    b.HasIndex("VoitureId");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebutLocation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinLocation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime2");

                    b.Property<int>("EtatReservation")
                        .HasColumnType("int");

                    b.Property<int>("MarqueVoiture")
                        .HasColumnType("int");

                    b.Property<float>("PrixLocationParJour")
                        .HasColumnType("real");

                    b.HasKey("IdReservation");

                    b.HasIndex("ClientId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Voiture", b =>
                {
                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Couleur")
                        .HasColumnType("int");

                    b.Property<int>("Marque")
                        .HasColumnType("int");

                    b.Property<int>("NombrePlace")
                        .HasColumnType("int");

                    b.HasKey("Matricule");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Contrat", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Domain.Voiture", "Voiture")
                        .WithMany("Contrats")
                        .HasForeignKey("VoitureId");

                    b.Navigation("Reservation");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Reservation", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Voiture", b =>
                {
                    b.Navigation("Contrats");
                });
#pragma warning restore 612, 618
        }
    }
}
