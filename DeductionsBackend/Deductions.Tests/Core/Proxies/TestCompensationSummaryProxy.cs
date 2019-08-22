using Deductions.Core.Calculators;
using Deductions.Core.Entities;
using Deductions.Core.Proxies;
using Deductions.Models.Contracts;
using Deductions.Tests.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Deductions.Tests.Core.Proxies
{
    public class TestCompensationSummaryProxy
    {
        private CompensationSummaryProxy _compensationSummaryProxy;
        private Mock<IDeductionCalculators> _mockDeductionCalculators;
        private Mock<IDiscountCalculators> _mockDiscountCalculators;
        private Mock<ISummaryRoundingLossCalculators> _mockSummaryRoundingLossCalculators;

        [SetUp]
        public void Setup()
        {
            _mockDeductionCalculators = new Mock<IDeductionCalculators>();
            _mockDiscountCalculators = new Mock<IDiscountCalculators>();
            _mockSummaryRoundingLossCalculators = new Mock<ISummaryRoundingLossCalculators>();
            _compensationSummaryProxy = new CompensationSummaryProxy(_mockDeductionCalculators.Object, _mockDiscountCalculators.Object, _mockSummaryRoundingLossCalculators.Object);
        }

        [Test]
        public void TestCalculateEmployeeAnnualCompensationSummary()
        {
            var request = CompensationSummaryRequestContractData.GetCompensationSummaryRequestContract();
            _mockDeductionCalculators.Setup(x => x.CalculateEmployeePersonalPaycheckDeduction(It.IsAny<EmployeeContract>(), It.IsAny<int>())).Returns(request.Employee.AnnualElectedBenefitsCost);
            _mockDeductionCalculators.Setup(x => x.CalculateEmployeeDependentPaycheckDeduction(It.IsAny<DependentContract>(), It.IsAny<int>())).Returns(request.Employee.Dependents.FirstOrDefault()?.AnnualElectedBenefitsCost ?? 0m);

            var mockDiscountValue = 0.5m;
            _mockDiscountCalculators.Setup(x => x.CalculateBeneficiaryDiscountPaycheckValue(It.IsAny<BeneficiaryContract>(), It.IsAny<IEnumerable<IDiscount>>(), It.IsAny<int>())).Returns(mockDiscountValue);

            _mockSummaryRoundingLossCalculators.Setup(x => x.CorrectRoundingLoss(It.IsAny<CompensationSummaryRequestContract>(), It.IsAny<decimal>(), It.IsAny<IEnumerable<PaycheckContract>>())).Returns(CompensationSummaryResultContractData.GetCompensationSummaryResultContract());

            var result = _compensationSummaryProxy.CalculateEmployeeAnnualCompensationSummary(request);

            var dependentCount = request.Employee.Dependents.Count();
            _mockDeductionCalculators.Verify(x => x.CalculateEmployeePersonalPaycheckDeduction(It.IsAny<EmployeeContract>(), It.IsAny<int>()), Times.Once);
            _mockDeductionCalculators.Verify(x => x.CalculateEmployeeDependentPaycheckDeduction(It.IsAny<DependentContract>(), It.IsAny<int>()), Times.Exactly(dependentCount));

            _mockDiscountCalculators.Verify(x => x.CalculateBeneficiaryDiscountPaycheckValue(It.IsAny<BeneficiaryContract>(), It.IsAny<IEnumerable<IDiscount>>(), It.IsAny<int>()), Times.Exactly(1 + dependentCount));

            _mockSummaryRoundingLossCalculators.Verify(x => x.CorrectRoundingLoss(It.IsAny<CompensationSummaryRequestContract>(), It.IsAny<decimal>(), It.IsAny<IEnumerable<PaycheckContract>>()), Times.Once);
        }
    }
}