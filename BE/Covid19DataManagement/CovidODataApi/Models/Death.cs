using System;
using System.Collections.Generic;

namespace CovidODataApi.Models;

public partial class Death
{
    public long Id { get; set; }

    public string? ProvinceState { get; set; }

    public string? CountryRegion { get; set; }

    public decimal? Lat { get; set; }

    public decimal? Long { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Cases { get; set; }
}
