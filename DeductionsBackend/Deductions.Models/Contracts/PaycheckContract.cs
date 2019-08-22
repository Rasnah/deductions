namespace Deductions.Models.Contracts
{
    public class PaycheckContract
    {
        public int PayPeriodOrdinal { get; set; }
        public decimal GrossPayAmount { get; set;}
        public decimal DeductionsAmount { get; set; }
        public decimal NetPayAmount { get; set; }
    }
}
