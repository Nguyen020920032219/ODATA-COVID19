namespace CovidODataApi.Models
{
    public partial class VwCovidDataCombined
    {
        public decimal? Active => Confirmed - Deaths - Recovered;
    }
}
