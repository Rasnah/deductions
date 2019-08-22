using Deductions.Models.Contracts;
using System;

namespace Deductions.Core.Calculators
{
    public interface IDeductionCalculators
    {
        decimal CalculateEmployeePersonalPaycheckDeduction(EmployeeContract employee, int numberOfPaychecks);
        decimal CalculateEmployeeDependentPaycheckDeduction(DependentContract dependent, int numberOfPaychecks);
    }

    public class DeductionCalculators : IDeductionCalculators
    {
        public decimal CalculateEmployeePersonalPaycheckDeduction(EmployeeContract employee, int numberOfPaychecks)
        {
            return decimal.Round(employee.AnnualElectedBenefitsCost / numberOfPaychecks, 2, MidpointRounding.AwayFromZero);
        }

        public decimal CalculateEmployeeDependentPaycheckDeduction(DependentContract dependent, int numberOfPaychecks)
        {
            return decimal.Round(dependent.AnnualElectedBenefitsCost / numberOfPaychecks, 2, MidpointRounding.AwayFromZero);
        }
    }
}