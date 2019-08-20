using Deductions.Core.Calculators;

namespace Deductions.Core.Proxies
{
    public interface IEmployeeDeductionProxy
    {
        int thing(string thinger);
    }

    public class EmployeeDeductionProxy : IEmployeeDeductionProxy
    {
        private readonly IDeductionCalculators _deductionCalculators;

        public EmployeeDeductionProxy(IDeductionCalculators deductionCalculators)
        {
            _deductionCalculators = deductionCalculators;
        }

        public int thing(string thinger)
        {
            return 0;
        }
    }
}