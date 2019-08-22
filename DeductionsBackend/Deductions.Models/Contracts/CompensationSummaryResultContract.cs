using System.Collections.Generic;

namespace Deductions.Models.Contracts
{
    public class CompensationSummaryResultContract
    {
        public decimal AnnualSalary { get; set; }
        public decimal AnnualDeductions { get; set; }
        public decimal AnnualNetPay { get; set; }
        public IEnumerable<PaycheckContract> Paychecks { get; set; }
    }
}
