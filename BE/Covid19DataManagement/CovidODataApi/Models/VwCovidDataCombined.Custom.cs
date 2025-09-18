namespace CovidODataApi.Models;

    public partial class VwCovidDataCombined
    {
        public decimal? Active
        {
            get
            {
                if (Confirmed == null || Deaths == null || Recovered == null)
                {
                    return null;
                }
                return Confirmed - Deaths - Recovered;
            }
        }
    }

