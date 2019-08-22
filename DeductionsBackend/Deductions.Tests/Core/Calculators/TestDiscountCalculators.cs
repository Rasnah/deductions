using Deductions.Core.Calculators;
using Deductions.Core.Entities;
using Deductions.Models.Contracts;
using Deductions.Tests.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Deductions.Tests.Core.Calculators
{
    public class TestDiscountCalculators
    {
        private DiscountCalculators _discountCalculators;
        private Mock<IDiscount> _mockDiscount;
        private readonly Random _random = new Random();

        [SetUp]
        public void Setup()
        {
            _discountCalculators = new DiscountCalculators();
            _mockDiscount = new Mock<IDiscount>();
        }

        [Test]
        public void CalculateBeneficiaryDiscountPaycheckValue_WithDiscount()
        {
            decimal randomDiscount = _random.Next(1, 10);
            _mockDiscount.Setup(x => x.CalculateValue(It.IsAny<BeneficiaryContract>())).Returns(randomDiscount);
            _mockDiscount.Setup(x => x.CheckIfApplicable(It.IsAny<BeneficiaryContract>())).Returns(true);

            var employee = EmployeeContractData.GetEmployeeContractExpectedDiscount();
            var numberOfPaychecks = 26;

            var discount = _discountCalculators.CalculateBeneficiaryDiscountPaycheckValue(employee, new List<IDiscount> { _mockDiscount.Object }, numberOfPaychecks);

            var expectedDiscount = decimal.Round(randomDiscount / numberOfPaychecks, 2, MidpointRounding.AwayFromZero);
            Assert.AreEqual(expectedDiscount, discount);

            _mockDiscount.Verify(x => x.CheckIfApplicable(It.IsAny<BeneficiaryContract>()), Times.Once);
            _mockDiscount.Verify(x => x.CalculateValue(It.IsAny<BeneficiaryContract>()), Times.Once);
        }

        [Test]
        public void CalculateBeneficiaryDiscountPaycheckValue_WithNoDiscount()
        {
            var randomDiscount = 0m;
            _mockDiscount.Setup(x => x.CalculateValue(It.IsAny<BeneficiaryContract>())).Returns(randomDiscount);
            _mockDiscount.Setup(x => x.CheckIfApplicable(It.IsAny<BeneficiaryContract>())).Returns(false);

            var employee = EmployeeContractData.GetEmployeeContractNoExpectedDiscount();
            var numberOfPaychecks = 26;

            var discount = _discountCalculators.CalculateBeneficiaryDiscountPaycheckValue(employee, new List<IDiscount> { _mockDiscount.Object }, numberOfPaychecks);

            var expectedDiscount = decimal.Round(randomDiscount / numberOfPaychecks, 2, MidpointRounding.AwayFromZero);
            Assert.AreEqual(expectedDiscount, discount);

            _mockDiscount.Verify(x => x.CheckIfApplicable(It.IsAny<BeneficiaryContract>()), Times.Once);
            _mockDiscount.Verify(x => x.CalculateValue(It.IsAny<BeneficiaryContract>()), Times.Never);
        }
    }
}