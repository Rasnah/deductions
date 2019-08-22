import { BeneficiaryContract } from './beneficiary.contract';
import { DependentContract } from './dependent.contract';

export class EmployeeContract extends BeneficiaryContract {
  annualSalary = 0;
  dependents = Array<DependentContract>();
}
