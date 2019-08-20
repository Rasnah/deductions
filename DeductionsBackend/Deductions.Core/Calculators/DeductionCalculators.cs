using Deductions.Models.Contracts;

namespace Deductions.Core.Calculators
{
    public interface IDeductionCalculators
    {
        decimal CalculateEmployeeAnnualCost(EmployeeContract employee);
        decimal CalculateDependentAnnualCost(DependentContract dependent);
    }

    public class DeductionCalculators : IDeductionCalculators
    {
        const decimal EMPLOYEE_ANNUAL_DEDUCTIONS = 1000.00m;
        const decimal DEPENDENT_ANNUAL_DEDUCTIONS = 500.00m;

        public decimal CalculateEmployeeAnnualCost(EmployeeContract employee)
        {
            return EMPLOYEE_ANNUAL_DEDUCTIONS;
        }

        public decimal CalculateDependentAnnualCost(DependentContract dependent)
        {
            return DEPENDENT_ANNUAL_DEDUCTIONS;
        }
    }
}