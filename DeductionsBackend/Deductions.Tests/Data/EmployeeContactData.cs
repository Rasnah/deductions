using Deductions.Models.Contracts;
using System.Collections.Generic;

namespace Deductions.Tests.Data
{
    public static class EmployeeContractData
    {
        public static EmployeeContract GetEmployeeContractNoExpectedDiscount()
        {
            return new EmployeeContract
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualElectedBenefitsCost = 1000.00m,
                AnnualSalary = 52000.00m
            };
        }

        public static EmployeeContract GetEmployeeContractExpectedDiscount()
        {
            return new EmployeeContract
            {
                FirstName = "Amy",
                LastName = "Doe",
                AnnualElectedBenefitsCost = 1000.00m,
                AnnualSalary = 52000.00m
            };
        }

        public static EmployeeContract WithDependentNoExpectedDiscount(this EmployeeContract employee)
        {
            employee.Dependents = new List<DependentContract>
            {
                DependentContractData.GetDependentContractNoExpectedDiscount()
            };
            return employee;
        }

        public static EmployeeContract WithDependentExpectedDiscount(this EmployeeContract employee)
        {
            employee.Dependents = new List<DependentContract>
            {
                DependentContractData.GetDependentContractExpectedDiscount()
            };
            return employee;
        }
    }
}