using Deductions.Core.Proxies;
using Deductions.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Deductions.Service.Controllers
{
    [Route("api/CompensationSummary")]
    [ApiController]
    public class CompensationSummaryController : ControllerBase
    {
        private readonly ICompensationSummaryProxy _compensationSummaryProxy;

        public CompensationSummaryController(ICompensationSummaryProxy compensationSummaryProxy) : base()
        {
            _compensationSummaryProxy = compensationSummaryProxy;
        }

        [HttpPost]
        public ActionResult<CompensationSummaryResultContract> Post([FromBody] CompensationSummaryRequestContract request)
        {
            return _compensationSummaryProxy.CalculateEmployeeAnnualCompensationSummary(request);
        }
    }
}
