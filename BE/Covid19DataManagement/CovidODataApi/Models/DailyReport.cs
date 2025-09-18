using System;
using System.Collections.Generic;

namespace CovidODataApi.Models;

public partial class DailyReport
{
    public long Id { get; set; }

    public string? ProvinceState { get; set; }

    public string? CountryRegion { get; set; }

    public DateTime? LastUpdate { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public long? Confirmed { get; set; }

    public long? Deaths { get; set; }

    public decimal? Recovered { get; set; }

    public decimal? Active { get; set; }

    public string? Fips { get; set; }

    public decimal? IncidentRate { get; set; }

    public decimal? TotalTestResults { get; set; }

    public decimal? PeopleHospitalized { get; set; }

    public decimal? CaseFatalityRatio { get; set; }

    public decimal? Uid { get; set; }

    public string? Iso3 { get; set; }

    public decimal? TestingRate { get; set; }

    public decimal? HospitalizationRate { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? PeopleTested { get; set; }

    public decimal? MortalityRate { get; set; }
}
