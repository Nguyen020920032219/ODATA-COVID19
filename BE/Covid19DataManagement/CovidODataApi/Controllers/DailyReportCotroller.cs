using CovidODataApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CovidODataApi.Controllers
{
    public class DailyReportCotroller : Controller
    {
        private readonly Covid19DbContext _context;

        public DailyReportCotroller(Covid19DbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.DailyReports);
        }
    }
}
