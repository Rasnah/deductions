namespace Deductions.Core.Calculators
{
    public interface IDeductionCalculators
    {
        decimal CalculateAnnualCost(string employeeName);
    }

    public class DeductionCalculators : IDeductionCalculators
    {
        public decimal CalculateAnnualCost(string employeeName)
        {
            decimal employeeCost = 1000.00m;
            decimal discountPercentage = 0.0m;
            if (employeeName.ToLower().StartsWith("a"))
            {
                discountPercentage = 0.1m;
            }

            decimal totalDiscount = employeeCost * discountPercentage;
            return employeeCost - totalDiscount;
        }
    }
}