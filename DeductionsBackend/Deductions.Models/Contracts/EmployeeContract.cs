using System.Collections.Generic;

namespace Deductions.Models.Contracts
{
    public class EmployeeContract
    {
        EmployeeContract()
        {
            Dependents = new List<DependentContract>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<DependentContract> Dependents { get; set; }
    }
}