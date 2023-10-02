using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User Id=postgres;Password=mwJvgQqPzjhXwWrb;Server=db.lnyxdixalclqvtxigwnl.supabase.co;Port=5432;Database=postgres");

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

            entity.Property(e => e.BusId).HasColumnName("BusID");
            entity.Property(e => e.BusStatus).HasColumnType("character varying");
            entity.Property(e => e.CurrentLocation).HasColumnType("character varying");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("Customer_pkey");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerName, "Customer_CustomerName_key").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasColumnType("character varying");
            entity.Property(e => e.Email).HasColumnType("character varying");
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

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.DriverName)
                .IsRequired()
                .HasColumnType("character varying");
        });

        modelBuilder.Entity<Routation>(entity =>
        {
            entity.HasKey(e => new { e.RouteId, e.StationId }).HasName("Routation_pkey");

            entity.ToTable("Routation");

            entity.Property(e => e.RouteId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RouteID");
            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.DefaultDuration).HasColumnType("timestamp without time zone");

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

            entity.Property(e => e.RouteId).HasColumnName("RouteID");
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

            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.Location).HasColumnType("character varying");
            entity.Property(e => e.StationName).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("Ticket_pkey");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.ArrivalTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasColumnType("character varying");
            entity.Property(e => e.DeparturTime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("Ticket_CustomerID_fkey");
        });

        modelBuilder.Entity<TicketStation>(entity =>
        {
            entity.HasKey(e => new { e.TicketId, e.StationId }).HasName("TicketStation_pkey");

            entity.ToTable("TicketStation");

            entity.Property(e => e.TicketId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TicketID");
            entity.Property(e => e.StationId).HasColumnName("StationID");
            entity.Property(e => e.CheckInTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.CheckOutTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("CheckOutTIme");

            entity.HasOne(d => d.Station).WithMany(p => p.TicketStations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TicketStation_StationID_fkey");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketStations)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TicketStation_TicketID_fkey");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("Trip_pkey");

            entity.ToTable("Trip");

            entity.Property(e => e.TripId).HasColumnName("TripID");
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
