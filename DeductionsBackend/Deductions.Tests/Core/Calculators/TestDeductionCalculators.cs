using Deductions.Core.Calculators;
using Deductions.Tests.Data;
using NUnit.Framework;
using System;
using System.Linq;

namespace Deductions.Tests.Core.Calculators
{
    public class TestDeductionCalculators
    {
        private DeductionCalculators _deductionCalculators;

        [SetUp]
        public void Setup()
        {
            _deductionCalculators = new DeductionCalculators();
        }

        [Test]
        public void TestCalculateEmployeePersonalPaycheckDeduction()
        {
            var employee = EmployeeContractData.GetEmployeeContractNoExpectedDiscount();
            var numberOfPaychecks = 26;

            var deduction = _deductionCalculators.CalculateEmployeePersonalPaycheckDeduction(employee, numberOfPaychecks);

            var expectedDeduction = decimal.Round(employee.AnnualElectedBenefitsCost / numberOfPaychecks, 2, MidpointRounding.AwayFromZero);
            Assert.AreEqual(deduction, expectedDeduction);
        }

        [Test]
        public void TestCalculateEmployeeDependentPaycheckDeduction()
        {
            var employee = EmployeeContractData.GetEmployeeContractNoExpectedDiscount().WithDependentNoExpectedDiscount();
            var numberOfPaychecks = 26;

            var deduction = _deductionCalculators.CalculateEmployeeDependentPaycheckDeduction(employee.Dependents.First(), numberOfPaychecks);

            var expectedDeduction = decimal.Round(employee.Dependents.First().AnnualElectedBenefitsCost / numberOfPaychecks, 2, MidpointRounding.AwayFromZero);
            Assert.AreEqual(expectedDeduction, deduction);
        }
    }
}