using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DecoupledBoundaries.Services;

namespace ModularMonolith_DecoupledBoundaries.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/reports")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ReportingController : ControllerBase
    {
        private readonly ReportingService _reporting;

        public ReportingController(ReportingService reporting)
        {
            _reporting = reporting;
        }

        [HttpGet("monthly")]
        public IActionResult GenerateMonthlyReport()
        {   var endDate = DateTime.UtcNow;
            var report = _reporting.GenerateMonthlyReport(endDate);
            return Ok(report);
        }
    }
}
