using Deductions.Models.Contracts;

namespace Deductions.Core.Calculators
{
    public interface IDiscountCalculators
    {
        decimal CalculateDiscountValue(EmployeeContract employee);
    }

    public class DiscountCalculators : IDiscountCalculators
    {
        const decimal NAME_DISCOUNT_PERCENTAGE = 0.1m;

        public decimal CalculateDiscountValue(EmployeeContract employee)
        {
            return 0m;
        }

        private bool CheckForNameDiscount(string name)
        {
            return name.ToLower().StartsWith("a");
        }
    }
}