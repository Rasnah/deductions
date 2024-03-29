﻿using System.Collections.Generic;

namespace Deductions.Models.Contracts
{
    public class EmployeeContract : BeneficiaryContract
    {
        public EmployeeContract() : base()
        {
            Dependents = new List<DependentContract>();
        }

        public decimal AnnualSalary { get; set; }
        public IEnumerable<DependentContract> Dependents { get; set; }
    }
}