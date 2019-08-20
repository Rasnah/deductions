using Deductions.Core.Calculators;
using Deductions.Models.Contracts;

namespace Deductions.Core.Proxies
{
    public interface IEmployeeDeductionProxy
    {
        int CalculateTotalEmployeeDeductions(EmployeeContract employee);
    }

    public class EmployeeDeductionProxy : IEmployeeDeductionProxy
    {
        private readonly IDeductionCalculators _deductionCalculators;
        private readonly IDiscountCalculators _discountCalculators;

        public EmployeeDeductionProxy(IDeductionCalculators deductionCalculators, IDiscountCalculators discountCalculators)
        {
            _deductionCalculators = deductionCalculators;
            _discountCalculators = discountCalculators;
        }

        public int CalculateTotalEmployeeDeductions(EmployeeContract employee)
        {
            decimal totalEmployeeDeductions = _deductionCalculators.CalculateEmployeeAnnualCost(employee);

            return 0;
        }
    }
}