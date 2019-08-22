using Deductions.Models.Contracts;

namespace Deductions.Models.Entities
{
    public interface IDiscount
    {
        bool CheckIfApplicable(BeneficiaryContract beneficiary);
        decimal CalculateValue(BeneficiaryContract beneficiary);
    }
}
