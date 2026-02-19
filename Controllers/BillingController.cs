using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DecoupledBoundaries.Services;

namespace ModularMonolith_DecoupledBoundaries.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/billing")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class BillingController : ControllerBase
    {
        private readonly BillingService _billing;

        public BillingController(BillingService billing)
        {
            _billing = billing;
        }

        [HttpPost("charge")]
        public IActionResult ChargeCustomer(int customerId, decimal amount)
        {
            var res = _billing.ChargeCustomer(customerId, amount);
            return Ok(res);
        }

        [HttpPost("invoice")]
        public IActionResult SendInvoice(int invoiceId)
        {
            var res = _billing.SendInvoice(invoiceId);
            return Ok(res);
        }
    }

}
