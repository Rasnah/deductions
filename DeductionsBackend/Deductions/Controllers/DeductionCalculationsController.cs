using Deductions.Core.Proxies;
using Deductions.Models.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Deductions.Service.Controllers
{
    [Route("api/DeductionCalculations")]
    [ApiController]
    public class DeductionCalculationsController : ControllerBase
    {
        private readonly IEmployeeDeductionProxy _employeeDeductionProxy;

        public DeductionCalculationsController(IEmployeeDeductionProxy employeeDeductionProxy) : base()
        {
            _employeeDeductionProxy = employeeDeductionProxy;
        }

        [HttpPost]
        public void Post([FromBody] EmployeeContract employee)
        {
            _employeeDeductionProxy.CalculateTotalEmployeeDeductions(employee);
        }
    }
}
