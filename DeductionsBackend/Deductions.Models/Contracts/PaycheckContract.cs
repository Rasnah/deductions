namespace Deductions.Models.Contracts
{
    public class PaycheckContract
    {
        public int PayPeriodOrdinal { get; set; }
        public decimal GrossPayAmount { get; set;}
        public decimal DeductionsAmout { get; set; }
        public decimal NetPayAmount { get; set; }
    }
}
