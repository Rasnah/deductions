﻿using Deductions.Models.Contracts;
using System;

namespace Deductions.Core.Entities
{
    public class NameDiscount : IDiscount
    {
        public const decimal NAME_DISCOUNT_PERCENTAGE = 0.1m;

        public decimal CalculateValue(BeneficiaryContract beneficiary)
        {
            return decimal.Round(beneficiary.AnnualElectedBenefitsCost * NAME_DISCOUNT_PERCENTAGE, 2, MidpointRounding.AwayFromZero);
        }

        public bool CheckIfApplicable(BeneficiaryContract beneficiary)
        {
            return beneficiary.FirstName.ToLower().StartsWith("a");
        }
    }
}
