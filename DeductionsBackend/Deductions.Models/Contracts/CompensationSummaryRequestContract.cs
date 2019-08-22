namespace Deductions.Models.Contracts
{
    public class CompensationSummaryRequestContract
    {
        public int NumberOfPaychecks { get; set; }
        public EmployeeContract Employee { get; set; }
    }
}
