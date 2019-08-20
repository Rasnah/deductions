using Deductions.Core.Proxies;
using Deductions.Models.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<decimal> Get(string id)
        {
            return 0m;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] EmployeeContract value)
        {
            //_employeeDeductionsProxy.thing("poop");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
