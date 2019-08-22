import { of } from 'rxjs';
import { CompensationSummaryResultContract } from 'src/app/contracts/compensation-summary-result.contract';

export class DeductionCalculationServiceMock {
  calculateEmployeeDeductions = jasmine.createSpy('calculateEmployeeDeductions')
    .and.returnValue(of(new CompensationSummaryResultContract()));
}
