using MedicalConsultationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalConsultationSystem.Data
{
    public class MedicalConsultationContext : DbContext
    {
        public MedicalConsultationContext(DbContextOptions<MedicalConsultationContext> options):base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Room>()
            //    .HasOne(r => r.Patient)
            //    .WithOne(p => p.Room)
            //    .HasForeignKey<Patient>(r => r.RoomID);

            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Room>().ToTable("Room");
        }
    }
}
