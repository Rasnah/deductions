using Deductions.Models.Contracts;
using System.Linq;

namespace Deductions.Tests.Data
{
    public static class CompensationSummaryResultContractData
    {
        public static CompensationSummaryResultContract GetCompensationSummaryResultContract()
        {
            var paychecks = Enumerable.Range(0, 26).Select(i =>
            {
                return PaycheckContractData.GetPaycheckContract(i);
            }).ToList();

            return new CompensationSummaryResultContract
            {
                AnnualSalary = 52000.00m,
                AnnualDeductions = 1000.00m,
                AnnualNetPay = 51000.00m,
                Paychecks = paychecks
            };
        }
    }
}