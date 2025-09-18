using CovidODataApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace CovidODataApi.Controllers
{
    public class ConfirmedController : ODataController
    {
        private readonly Covid19DbContext _context;

        public ConfirmedController(Covid19DbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Confirmeds);
        }
    }
}
