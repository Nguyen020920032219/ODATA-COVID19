using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CovidODataApi.Models;

public partial class Covid19DbContext : DbContext
{
    public Covid19DbContext(DbContextOptions<Covid19DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Confirmed> Confirmeds { get; set; }

    public virtual DbSet<DailyReport> DailyReports { get; set; }

    public virtual DbSet<Death> Deaths { get; set; }

    public virtual DbSet<Recovered> Recovereds { get; set; }

    public virtual DbSet<VwCovidDataCombined> VwCovidDataCombineds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Confirmed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("confirmed_pkey");

            entity.ToTable("confirmed");

            entity.Property(e => e.CountryRegion)
                .HasMaxLength(255)
                .HasColumnName("Country/Region");
            entity.Property(e => e.Lat).HasPrecision(9, 6);
            entity.Property(e => e.Long).HasPrecision(9, 6);
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(255)
                .HasColumnName("Province/State");
        });

        modelBuilder.Entity<DailyReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("daily_reports_pkey");

            entity.ToTable("daily_reports");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CaseFatalityRatio).HasColumnName("case_fatality_ratio");
            entity.Property(e => e.Confirmed).HasColumnName("confirmed");
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(255)
                .HasColumnName("country_region");
            entity.Property(e => e.Deaths).HasColumnName("deaths");
            entity.Property(e => e.Fips)
                .HasMaxLength(20)
                .HasColumnName("fips");
            entity.Property(e => e.HospitalizationRate).HasColumnName("hospitalization_rate");
            entity.Property(e => e.IncidentRate).HasColumnName("incident_rate");
            entity.Property(e => e.Iso3)
                .HasMaxLength(10)
                .HasColumnName("iso3");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_update");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Long).HasColumnName("long_");
            entity.Property(e => e.MortalityRate).HasColumnName("mortality_rate");
            entity.Property(e => e.PeopleHospitalized).HasColumnName("people_hospitalized");
            entity.Property(e => e.PeopleTested).HasColumnName("people_tested");
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(255)
                .HasColumnName("province_state");
            entity.Property(e => e.Recovered).HasColumnName("recovered");
            entity.Property(e => e.TestingRate).HasColumnName("testing_rate");
            entity.Property(e => e.TotalTestResults).HasColumnName("total_test_results");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<Death>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deaths_pkey");

            entity.ToTable("deaths");

            entity.Property(e => e.CountryRegion)
                .HasMaxLength(255)
                .HasColumnName("Country/Region");
            entity.Property(e => e.Lat).HasPrecision(9, 6);
            entity.Property(e => e.Long).HasPrecision(9, 6);
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(255)
                .HasColumnName("Province/State");
        });

        modelBuilder.Entity<Recovered>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recovered_pkey");

            entity.ToTable("recovered");

            entity.Property(e => e.CountryRegion)
                .HasMaxLength(255)
                .HasColumnName("Country/Region");
            entity.Property(e => e.Lat).HasPrecision(9, 6);
            entity.Property(e => e.Long).HasPrecision(9, 6);
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(255)
                .HasColumnName("Province/State");
        });

        modelBuilder.Entity<VwCovidDataCombined>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_covid_data_combined");

            entity.Property(e => e.CountryRegion).HasMaxLength(255);
            entity.Property(e => e.Latitude).HasPrecision(9, 6);
            entity.Property(e => e.Longitude).HasPrecision(9, 6);
            entity.Property(e => e.ProvinceState).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
