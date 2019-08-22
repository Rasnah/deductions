using Deductions.Models.Contracts;

namespace Deductions.Tests.Data
{
    public static class CompensationSummaryRequestContractData
    {
        public static CompensationSummaryRequestContract GetCompensationSummaryRequestContract()
        {
            return new CompensationSummaryRequestContract
            {
                NumberOfPaychecks = 26,
                Employee = EmployeeContractData.GetEmployeeContractExpectedDiscount()
            };
        }
    }
}