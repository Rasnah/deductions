import { BeneficiaryContract } from './beneficiary.contract';

export class DependentContract extends BeneficiaryContract {
  constructor() {
    super();
    this.annualElectedBenefitsCost = 500;
  }
}
