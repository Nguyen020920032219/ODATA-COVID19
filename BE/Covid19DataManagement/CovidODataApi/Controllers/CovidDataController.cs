using CovidODataApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace CovidODataApi.Controllers
{
    public class CovidDataController : ODataController
    {
        private readonly Covid19DbContext _context;

        public CovidDataController(Covid19DbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.VwCovidDataCombineds);
        }
    }
}
