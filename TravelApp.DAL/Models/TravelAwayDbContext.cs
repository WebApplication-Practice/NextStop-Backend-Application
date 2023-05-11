using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TravelApp.DAL.Models;

public partial class TravelAwayDbContext : DbContext
{
    public TravelAwayDbContext()
    {
    }

    public TravelAwayDbContext(DbContextOptions<TravelAwayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accomodation> Accomodations { get; set; }

    public virtual DbSet<BookPackage> BookPackages { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerCare> CustomerCares { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackageCategory> PackageCategories { get; set; }

    public virtual DbSet<PackageDetail> PackageDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleBooked> VehicleBookeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TravelAwayDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accomodation>(entity =>
        {
            entity.HasKey(e => e.AccomodationId).HasName("pk_AccomodationId");

            entity.ToTable("Accomodation");

            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Booking).WithMany(p => p.Accomodations)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("fk_BookingId");
        });

        modelBuilder.Entity<BookPackage>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("pk_BookingId");

            entity.ToTable("BookPackage");

            entity.HasIndex(e => e.ContactNumber, "UQ__BookPack__570665C6DE653F45").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.DateOfTravel).HasColumnType("date");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Email).WithMany(p => p.BookPackages)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("fk_EmailId");

            entity.HasOne(d => d.Package).WithMany(p => p.BookPackages)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("fk_packId");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("pk_EmailId");

            entity.ToTable("Customer");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_RoleId");
        });

        modelBuilder.Entity<CustomerCare>(entity =>
        {
            entity.HasKey(e => e.QueryId).HasName("pk_QueryId");

            entity.ToTable("CustomerCare");

            entity.Property(e => e.Assignee)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Query)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QueryAnswer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.QueryStatus)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Booking).WithMany(p => p.CustomerCares)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("fk_BId");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("pk_EMPID");

            entity.ToTable("Employee");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_RId");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("pk_HotelId");

            entity.ToTable("Hotel");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeluxeeRoomPrice).HasColumnType("money");
            entity.Property(e => e.DoubleRoomPrice).HasColumnType("money");
            entity.Property(e => e.HotelName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SingleRoomPrice).HasColumnType("money");
            entity.Property(e => e.SuiteRoomPrice).HasColumnType("money");

            entity.HasOne(d => d.Package).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("fk_packId_hotels");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("pk_PackageId");

            entity.ToTable("Package");

            entity.HasIndex(e => e.PackageName, "UQ__Package__73856F7A8EE1C630").IsUnique();

            entity.Property(e => e.PackageName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfPackage)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.PackageCategory).WithMany(p => p.Packages)
                .HasForeignKey(d => d.PackageCategoryId)
                .HasConstraintName("fk_PackageCategoryId");
        });

        modelBuilder.Entity<PackageCategory>(entity =>
        {
            entity.HasKey(e => e.PackageCategoryId).HasName("pk_PackageCategoryId");

            entity.ToTable("PackageCategory");

            entity.HasIndex(e => e.PackageCategoryName, "UQ__PackageC__DD8EB47417947417").IsUnique();

            entity.Property(e => e.PackageCategoryName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PackageDetail>(entity =>
        {
            entity.HasKey(e => e.PackageDetailsId).HasName("pk_PaclageDetailsId");

            entity.Property(e => e.Accomodation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlcesToVisit)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PricePerAdult).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("fk_PackageId");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("pk_PaymentId");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("money");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("fk_PaymentBookId");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("pk_RatingId");

            entity.ToTable("Rating");

            entity.Property(e => e.Comments)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Rating1).HasColumnName("Rating");

            entity.HasOne(d => d.Booking).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("fk_BookId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_RoleId");

            entity.HasIndex(e => e.RoleName, "uq_RoleName").IsUnique();

            entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("pk_VehicleId");

            entity.ToTable("Vehicle");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.RatePerHour).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.RatePerKm).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VehicleType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VehicleBooked>(entity =>
        {
            entity.HasKey(e => e.VehicleBookingId).HasName("pk_VehicleBookingId");

            entity.ToTable("VehicleBooked");

            entity.Property(e => e.BookingDate).HasColumnType("date");
            entity.Property(e => e.PickupTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VehicleStatus)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleBookeds)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("fk_VehicleId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
