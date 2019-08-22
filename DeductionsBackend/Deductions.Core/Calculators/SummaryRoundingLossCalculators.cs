using Deductions.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Deductions.Core.Calculators
{
    public interface ISummaryRoundingLossCalculators
    {
        CompensationSummaryResultContract CorrectRoundingLoss(CompensationSummaryRequestContract request, decimal totalAnnualDiscounts, IEnumerable<PaycheckContract> paychecks);
    }
    public class SummaryRoundingLossCalculators : ISummaryRoundingLossCalculators
    {
        public CompensationSummaryResultContract CorrectRoundingLoss(CompensationSummaryRequestContract request, decimal totalAnnualDiscounts, IEnumerable<PaycheckContract> paychecks)
        {
            var totalAnnualDeductions = paychecks.Select(x => x.DeductionsAmount).Sum();
            var totalUndiscountedDeductions = request.Employee.AnnualElectedBenefitsCost + request.Employee.Dependents.Select(x => x.AnnualElectedBenefitsCost).Sum();
            var roundingLoss = totalUndiscountedDeductions - totalAnnualDiscounts - totalAnnualDeductions;
            if (roundingLoss != 0m)
            {
                var lastPaycheck = paychecks.Where(x => x.PayPeriodOrdinal == request.NumberOfPaychecks - 1).FirstOrDefault();
                lastPaycheck.DeductionsAmount += roundingLoss;
                lastPaycheck.NetPayAmount -= roundingLoss;
                totalAnnualDeductions += roundingLoss;
            }

            return new CompensationSummaryResultContract
            {
                AnnualSalary = request.Employee.AnnualSalary,
                AnnualDeductions = totalAnnualDeductions,
                AnnualNetPay = paychecks.Select(x => x.NetPayAmount).Sum(),
                Paychecks = paychecks
            };
        }
    }
}
