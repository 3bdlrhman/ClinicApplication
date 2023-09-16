using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicApplication.Models
{
    public partial class ClinicDbContext : DbContext
    {
        public ClinicDbContext()
        {
        }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DoctorWorkDay> DoctorWorkDays { get; set; }
        public virtual DbSet<Tblclinic> Tblclinics { get; set; }
        public virtual DbSet<Tbldoctor> Tbldoctors { get; set; }
        public virtual DbSet<TbldoctorSchedule> TbldoctorSchedules { get; set; }
        public virtual DbSet<WeekDay> WeekDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ClinicDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorWorkDay>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.DoctorWorkDays)
                    .HasForeignKey(d => d.DayId)
                    .HasConstraintName("FK_DoctorWorkDays_WeekDays");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorWorkDays)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_DoctorWorkDays_TBLDoctors");
            });

            modelBuilder.Entity<Tblclinic>(entity =>
            {
                entity.HasKey(e => e.ClinicId)
                    .HasName("PK__Clinic__3347C2FDA202DEC9");

                entity.ToTable("TBLClinic");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ClinicAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClinicName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbldoctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__Doctors__2DC00EDFE36AF400");

                entity.ToTable("TBLDoctors");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.About).HasMaxLength(500);

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Tbldoctors)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("FK_ClinicID");
            });

            modelBuilder.Entity<TbldoctorSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__DoctorSc__9C8A5B696B9BD50B");

                entity.ToTable("TBLDoctorSchedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientName).HasMaxLength(255);

                entity.HasOne(d => d.DayOfWeekNavigation)
                    .WithMany(p => p.TbldoctorSchedules)
                    .HasForeignKey(d => d.DayOfWeek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBLDoctorSchedule_WeekDays");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TbldoctorSchedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ForiegnKey_DoctorId");
            });

            modelBuilder.Entity<WeekDay>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Day).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
