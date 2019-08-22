using Deductions.Models.Contracts;
using Deductions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deductions.Core.Calculators
{
    public interface IDiscountCalculators
    {
        decimal CalculateBeneficiaryDiscountPaycheckValue(BeneficiaryContract beneficiary, IEnumerable<IDiscount> potentialDiscounts, int numberOfPaychecks);
    }

    public class DiscountCalculators : IDiscountCalculators
    {
        public decimal CalculateBeneficiaryDiscountPaycheckValue(BeneficiaryContract beneficiary, IEnumerable<IDiscount> potentialDiscounts, int numberOfPaychecks)
        {
            return decimal.Round(
                potentialDiscounts.Where(x => x.CheckIfApplicable(beneficiary))
                .Select(x => decimal.Round(x.CalculateValue(beneficiary) / numberOfPaychecks, 2, MidpointRounding.AwayFromZero)
            ).Sum(), 2, MidpointRounding.AwayFromZero);
        }
    }
}