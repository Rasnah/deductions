import { TestBed } from '@angular/core/testing';

import { DeductionCalculationsService } from './deduction-calculations.service';

describe('DeductionCalculationsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DeductionCalculationsService = TestBed.get(DeductionCalculationsService);
    expect(service).toBeTruthy();
  });
});
