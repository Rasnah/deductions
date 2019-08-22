using Deductions.Core.Calculators;
using Deductions.Models.Contracts;
using Deductions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deductions.Core.Proxies
{
    public interface ICompensationSummaryProxy
    {
        CompensationSummaryResultContract CalculateEmployeeAnnualCompensationSummary(CompensationSummaryRequestContract request);
    }

    public class CompensationSummaryProxy : ICompensationSummaryProxy
    {
        private readonly IDeductionCalculators _deductionCalculators;
        private readonly IDiscountCalculators _discountCalculators;
        private readonly ISummaryRoundingLossCalculators _summaryRoundingLossCalculators;

        public CompensationSummaryProxy(IDeductionCalculators deductionCalculators, IDiscountCalculators discountCalculators, ISummaryRoundingLossCalculators summaryRoundingLossCalculators)
        {
            _deductionCalculators = deductionCalculators;
            _discountCalculators = discountCalculators;
            _summaryRoundingLossCalculators = summaryRoundingLossCalculators;
        }

        public CompensationSummaryResultContract CalculateEmployeeAnnualCompensationSummary(CompensationSummaryRequestContract request)
        {
            var personalPayPeriodDeductions = _deductionCalculators.CalculateEmployeePersonalPaycheckDeduction(request.Employee, request.NumberOfPaychecks);
            var totalDependentPayPeriodDeductions = request.Employee.Dependents.Select(x => _deductionCalculators.CalculateEmployeeDependentPaycheckDeduction(x, request.NumberOfPaychecks)).Sum();

            var availableDiscounts = new List<IDiscount> { new NameDiscount() };

            var personalPayPeriodDiscount = _discountCalculators.CalculateBeneficiaryDiscountPaycheckValue(request.Employee, availableDiscounts, request.NumberOfPaychecks);
            var totalDependentPayPeriodDiscount = request.Employee.Dependents.Select(x => _discountCalculators.CalculateBeneficiaryDiscountPaycheckValue(x, availableDiscounts, request.NumberOfPaychecks)).Sum();

            var paychecks = Enumerable.Range(0, request.NumberOfPaychecks).Select(i =>
            {
                var grossPay = decimal.Round(request.Employee.AnnualSalary / request.NumberOfPaychecks, 2, MidpointRounding.AwayFromZero);
                var deductions = (personalPayPeriodDeductions - personalPayPeriodDiscount) + (totalDependentPayPeriodDeductions - totalDependentPayPeriodDiscount);
                return new PaycheckContract
                {
                    PayPeriodOrdinal = i,
                    GrossPayAmount = grossPay,
                    DeductionsAmount = deductions,
                    NetPayAmount = grossPay - deductions
                };
            }).ToList();

            var totalAnnualDiscounts = (personalPayPeriodDiscount + totalDependentPayPeriodDiscount) * request.NumberOfPaychecks;

            return _summaryRoundingLossCalculators.CorrectRoundingLoss(request, totalAnnualDiscounts, paychecks);
        }
    }
}