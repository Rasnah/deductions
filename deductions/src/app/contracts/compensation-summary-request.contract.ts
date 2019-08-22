import { EmployeeContract } from './employee.contract';

export class CompensationSummaryRequestContract {
  numberOfPaychecks = 0;
  employee = new EmployeeContract();
}
