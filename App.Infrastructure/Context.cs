using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class Context : DbContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contrat>()
            //.HasOne(c => c.Reservation)
            //.WithOne(r => r.Contrat)
            //.HasForeignKey<Reservation>(r => r.ContratId); // Clé étrangère dans la classe Reservation

            //modelBuilder.Entity<Reservation>()
            //    .HasOne(r => r.Contrat)
            //    .WithOne(c => c.Reservation)
            //    .HasForeignKey<Contrat>(c => c.ReservationId); // Clé étrangère dans la classe Contrat
            //modelBuilder.ApplyConfiguration(new ContratConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
