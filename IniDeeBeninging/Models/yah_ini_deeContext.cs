using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IniDeeBeninging.Models
{
    public partial class yah_ini_deeContext : DbContext
    {
        public yah_ini_deeContext()
        {
        }

        public yah_ini_deeContext(DbContextOptions<yah_ini_deeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressesEmployer> AddressesEmployers { get; set; } = null!;
        public virtual DbSet<Advertisement> Advertisements { get; set; } = null!;
        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<ContactPerson> ContactPeople { get; set; } = null!;
        public virtual DbSet<ContractType> ContractTypes { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<Field> Fields { get; set; } = null!;
        public virtual DbSet<LoginDatum> LoginData { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<PropertyCustodian> PropertyCustodians { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Upload> Uploads { get; set; } = null!;
        public virtual DbSet<VEmployerIdAdId> VEmployerIdAdIds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=yah_ini_dee;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressesEmployer>(entity =>
            {
                entity.ToTable("Addresses_Employers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.EmployerId).HasColumnName("Employer_ID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AddressesEmployers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adr_Cities");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.AddressesEmployers)
                    .HasForeignKey(d => d.EmployerId)
                    .HasConstraintName("FK_Adr_Employers");
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId)
                    .HasColumnName("Address_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContractId).HasColumnName("Contract_ID");

                entity.Property(e => e.FieldId).HasColumnName("Field_ID");

                entity.Property(e => e.IsValid)
                    .HasMaxLength(1)
                    .HasColumnName("Is_Valid")
                    .IsFixedLength();

                entity.Property(e => e.PositionId).HasColumnName("Position_ID");

                entity.Property(e => e.PostDate)
                    .HasColumnType("date")
                    .HasColumnName("Post_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adv_Adresses");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adv_Contracts");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adv_Fields");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adv_Positions");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvertsId).HasColumnName("Adverts_ID");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Adverts)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.AdvertsId)
                    .HasConstraintName("FK_Apl_Adverts");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Apl_Students");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.PostalCode).HasColumnName("Postal_Code");
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.ToTable("Contact_People");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.ToTable("Contract_Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type).HasMaxLength(256);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.File).HasMaxLength(256);

                entity.Property(e => e.Type).HasMaxLength(256);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.ContactId)
                    .HasColumnName("Contact_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustodianId)
                    .HasColumnName("Custodian_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(200)
                    .HasColumnName("Employer_Name");

                entity.Property(e => e.RegisteredSeat)
                    .HasMaxLength(200)
                    .HasColumnName("Registered_Seat");

                entity.Property(e => e.Uic)
                    .HasMaxLength(15)
                    .HasColumnName("UIC");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Cities");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Employers)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Contacts");

                entity.HasOne(d => d.Custodian)
                    .WithMany(p => p.Employers)
                    .HasForeignKey(d => d.CustodianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Custodians");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<LoginDatum>(entity =>
            {
                entity.ToTable("Login_Data");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LinkId).HasColumnName("Link_ID");

                entity.Property(e => e.Password).HasMaxLength(256);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(256)
                    .HasColumnName("Position_Name");
            });

            modelBuilder.Entity<PropertyCustodian>(entity =>
            {
                entity.ToTable("Property_Custodians");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Egn)
                    .HasMaxLength(10)
                    .HasColumnName("EGN");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sch_Cities");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.Egn)
                    .HasMaxLength(10)
                    .HasColumnName("EGN");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("Middle_Name");

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.SchoolId).HasColumnName("School_ID");

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stu_Cities");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stu_Schools");
            });

            modelBuilder.Entity<Upload>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationId).HasColumnName("Application_ID");

                entity.Property(e => e.File).HasMaxLength(256);
            });

            modelBuilder.Entity<VEmployerIdAdId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployerID_AdID");

                entity.Property(e => e.AId).HasColumnName("aID");

                entity.Property(e => e.EId).HasColumnName("eID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
