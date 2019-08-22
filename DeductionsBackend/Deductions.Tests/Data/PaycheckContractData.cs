using Deductions.Models.Contracts;

namespace Deductions.Tests.Data
{
    public static class PaycheckContractData
    {
        public static PaycheckContract GetPaycheckContract(int payPeriodOrdinal)
        {
            return new PaycheckContract
            {
                PayPeriodOrdinal = payPeriodOrdinal,
                GrossPayAmount = 2000.00m,
                DeductionsAmount = 38.46m,
                NetPayAmount = 1962.54m
            };
        }
    }
}