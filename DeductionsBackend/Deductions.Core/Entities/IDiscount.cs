using Deductions.Models.Contracts;

namespace Deductions.Core.Entities
{
    public interface IDiscount
    {
        bool CheckIfApplicable(BeneficiaryContract beneficiary);
        decimal CalculateValue(BeneficiaryContract beneficiary);
    }
}
