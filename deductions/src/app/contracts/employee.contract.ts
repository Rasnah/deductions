import { BeneficiaryContract } from './beneficiary.contract';
import { DependentContract } from './dependent.contract';

export class EmployeeContract extends BeneficiaryContract {
  constructor() {
    super();
    this.annualElectedBenefitsCost = 1000;
  }
  annualSalary = 52000;
  dependents = Array<DependentContract>();
}
