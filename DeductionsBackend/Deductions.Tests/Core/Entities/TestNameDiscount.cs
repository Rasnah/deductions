using Deductions.Core.Entities;
using Deductions.Tests.Data;
using NUnit.Framework;
using System;

namespace Deductions.Tests.Core.Entities
{
    public class TestNameDiscount
    {
        private NameDiscount _nameDiscount;

        [SetUp]
        public void Setup()
        {
            _nameDiscount = new NameDiscount();
        }

        [Test]
        public void TestCalculateValue()
        {
            var employee = EmployeeContractData.GetEmployeeContractExpectedDiscount();

            var discountValue = _nameDiscount.CalculateValue(employee);

            var expectedValue = decimal.Round(employee.AnnualElectedBenefitsCost * NameDiscount.NAME_DISCOUNT_PERCENTAGE, 2, MidpointRounding.AwayFromZero);

            Assert.AreEqual(expectedValue, discountValue);
        }

        [Test]
        public void TestCheckIfApplicable_IsApplicable()
        {
            var employee = EmployeeContractData.GetEmployeeContractExpectedDiscount();

            var isApplicable = _nameDiscount.CheckIfApplicable(employee);

            Assert.IsTrue(isApplicable);
        }

        [Test]
        public void TestCheckIfApplicable_IsNotApplicable()
        {
            var employee = EmployeeContractData.GetEmployeeContractNoExpectedDiscount();

            var isApplicable = _nameDiscount.CheckIfApplicable(employee);

            Assert.IsFalse(isApplicable);
        }
    }
}