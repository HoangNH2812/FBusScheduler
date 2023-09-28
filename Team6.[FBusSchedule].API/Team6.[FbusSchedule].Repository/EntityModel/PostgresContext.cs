using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Team6._FbusSchedule_.Repository.EntityModel;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DetailTrip> DetailTrips { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Routation> Routations { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketStation> TicketStations { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(GetConnectionStrings());
        }
    }
    private string GetConnectionStrings()
    {
        IConfiguration config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
        return config["ConnectionStrings:DB"];
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn" })
            .HasPostgresEnum("pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" })
            .HasPostgresEnum("pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "pgjwt")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("pgsodium", "pgsodium")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.BusId).HasName("Bus_pkey");

            entity.ToTable("Bus");

            entity.HasIndex(e => e.BusNumber, "Bus_BusNumber_key").IsUnique();

            entity.HasIndex(e => e.BusStatus, "Bus_BusStatus_key").IsUnique();

            entity.HasIndex(e => e.CurretLocation, "Bus_CurretLocation_key").IsUnique();

            entity.Property(e => e.BusId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("BusID");
            entity.Property(e => e.BusNumber)
                .IsRequired()
                .HasColumnType("character varying");
            entity.Property(e => e.BusStatus)
                .IsRequired()
                .HasColumnType("character varying");
            entity.Property(e => e.CurretLocation)
                .IsRequired()
                .HasColumnType("character varying");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("Student_pkey");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "Student_Email_key").IsUnique();

            entity.HasIndex(e => e.CustomerName, "Student_StudentName_key").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasColumnType("character varying");
            entity.Property(e => e.Email).IsRequired();
        });

        modelBuilder.Entity<DetailTrip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("DetailTrip_pkey");

            entity.ToTable("DetailTrip");

            entity.Property(e => e.TripId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TripID");
            entity.Property(e => e.ArrivalTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StationId).HasColumnName("StationID");

            entity.HasOne(d => d.Station).WithMany(p => p.DetailTrips)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DetailTrip_StationID_fkey");

            entity.HasOne(d => d.Trip).WithOne(p => p.DetailTrip)
                .HasForeignKey<DetailTrip>(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DetailTrip_TripID_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("Driver_pkey");

            entity.ToTable("Driver");

            entity.Property(e => e.DriverId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("DriverID");
            entity.Property(e => e.DriverName)
                .IsRequired()
                .HasColumnType("character varying");
        });

        modelBuilder.Entity<Routation>(entity =>
        {
            entity.HasKey(e => new { e.RouteId, e.StationId }).HasName("Routation_pkey");

            entity.ToTable("Routation");

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.StationId).HasColumnName("StationID");

            entity.HasOne(d => d.Route).WithMany(p => p.Routations)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Routation_RouteID_fkey");

            entity.HasOne(d => d.Station).WithMany(p => p.Routations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Routation_StationID_fkey");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("Route_pkey");

            entity.ToTable("Route");

            entity.HasIndex(e => e.StartingLocation, "Route_StartingLocation_key").IsUnique();

            entity.Property(e => e.RouteId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("RouteID");
            entity.Property(e => e.Destination).HasColumnType("character varying");
            entity.Property(e => e.Distance).HasColumnType("character varying");
            entity.Property(e => e.RouteName).HasColumnType("character varying");
            entity.Property(e => e.StartingLocation)
                .IsRequired()
                .HasColumnType("character varying");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("Station_pkey");

            entity.ToTable("Station");

            entity.Property(e => e.StationId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("StationID");
            entity.Property(e => e.Location).HasColumnType("character varying");
            entity.Property(e => e.StationName)
                .IsRequired()
                .HasColumnType("character varying");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("Ticket_pkey");

            entity.ToTable("Ticket");

            entity.HasIndex(e => e.ArrivalTime, "Ticket_ArrivalTime_key").IsUnique();

            entity.HasIndex(e => e.DepartureTime, "Ticket_DepartureTime_key").IsUnique();

            entity.HasIndex(e => e.StudentName, "Ticket_PassengerName_key").IsUnique();

            entity.Property(e => e.TicketId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("TicketID");
            entity.Property(e => e.ArrivalTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DepartureTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StudentName)
                .IsRequired()
                .HasColumnType("character varying");
            entity.Property(e => e.TripId).HasColumnName("TripID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("Ticket_CustomerID_fkey");
        });

        modelBuilder.Entity<TicketStation>(entity =>
        {
            entity.HasKey(e => new { e.TickerId, e.StationId }).HasName("Ticket_Station_pkey");

            entity.ToTable("Ticket_Station");

            entity.Property(e => e.TickerId).HasColumnName("TickerID");
            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.CheckInTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CheckOutTime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Station).WithMany(p => p.TicketStations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ticket_Station_StationID_fkey");

            entity.HasOne(d => d.Ticker).WithMany(p => p.TicketStations)
                .HasForeignKey(d => d.TickerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ticket_Station_TickerID_fkey");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Trip1).HasName("Trip_pkey");

            entity.ToTable("Trip");

            entity.Property(e => e.Trip1).HasColumnName("Trip");
            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.RouteId).HasColumnName("RouteID");
            entity.Property(e => e.RouteName)
                .IsRequired()
                .HasColumnType("character varying");

            entity.HasOne(d => d.Bus).WithMany(p => p.Trips)
                .HasForeignKey(d => d.BusId)
                .HasConstraintName("Trip_BusID_fkey");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("Trip_DriverID_fkey");

            entity.HasOne(d => d.Route).WithMany(p => p.Trips)
                .HasForeignKey(d => d.RouteId)
                .HasConstraintName("Trip_RouteID_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
