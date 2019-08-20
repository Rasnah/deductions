import { DependentContract } from './dependent.contract';

export class EmployeeContract {
  firstName = '';
  lastName = '';
  dependents = Array<DependentContract>();
}
