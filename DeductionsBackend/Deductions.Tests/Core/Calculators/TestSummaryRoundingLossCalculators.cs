using Deductions.Core.Calculators;
using Deductions.Tests.Data;
using NUnit.Framework;
using System;
using System.Linq;

namespace Deductions.Tests.Core.Calculators
{
    public class TestSummaryRoundingLossCalculators
    {
        private SummaryRoundingLossCalculators _summaryRoundingLossCalculators;

        [SetUp]
        public void Setup()
        {
            _summaryRoundingLossCalculators = new SummaryRoundingLossCalculators();
        }

        [Test]
        public void TestCorrectRoundingLoss()
        {
            var request = CompensationSummaryRequestContractData.GetCompensationSummaryRequestContract();
            var paychecks = CompensationSummaryResultContractData.GetCompensationSummaryResultContract().Paychecks;
            var totalAnnualDiscounts = 0.0m;

            var expectedDifference = Math.Abs(request.Employee.AnnualElectedBenefitsCost - paychecks.Select(x => x.DeductionsAmount).Sum());

            var result = _summaryRoundingLossCalculators.CorrectRoundingLoss(request, totalAnnualDiscounts, paychecks);
            
            var adjustedAmmount = Math.Abs(result.Paychecks.Where(x => x.PayPeriodOrdinal == 0).FirstOrDefault().DeductionsAmount -
                result.Paychecks.Where(x => x.PayPeriodOrdinal == 25).FirstOrDefault().DeductionsAmount);

            Assert.AreEqual(expectedDifference, adjustedAmmount);
        }
    }
}