import { PaycheckContract } from './paycheck.contract';

export class CompensationSummaryResultContract {
  annualSalary = 0;
  annualDeductions = 0;
  annualGrossPay = 0;
  paychecks = Array<PaycheckContract>();
}
