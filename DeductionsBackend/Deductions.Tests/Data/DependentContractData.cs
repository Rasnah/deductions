using Deductions.Models.Contracts;

namespace Deductions.Tests.Data
{
    public static class DependentContractData
    {
        public static DependentContract GetDependentContractNoExpectedDiscount()
        {
            return new DependentContract
            {
                FirstName = "Jim",
                LastName = "Doe",
                AnnualElectedBenefitsCost = 500.00m
            };
        }

        public static DependentContract GetDependentContractExpectedDiscount()
        {
            return new DependentContract
            {
                FirstName = "Anna",
                LastName = "Doe",
                AnnualElectedBenefitsCost = 500.00m
            };
        }
    }
}