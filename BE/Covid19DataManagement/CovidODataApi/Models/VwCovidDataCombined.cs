using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CovidODataApi.Models;

public partial class VwCovidDataCombined
{
    [Key]
    public long? Id { get; set; }

    public string? CountryRegion { get; set; }

    public string? ProvinceState { get; set; }

    public DateOnly? RecordDate { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public decimal? Confirmed { get; set; }

    public decimal? Deaths { get; set; }

    public decimal? Recovered { get; set; }
}
