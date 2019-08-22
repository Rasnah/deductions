import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { getTestBed, TestBed } from '@angular/core/testing';
import { first } from 'rxjs/operators';
import { CompensationSummaryRequestContract } from '../contracts/compensation-summary-request.contract';
import { CompensationSummaryResultContract } from '../contracts/compensation-summary-result.contract';
import { DeductionCalculationsService } from './deduction-calculations.service';

describe('DeductionCalculationsService', () => {
  let injector: TestBed;
  let service: DeductionCalculationsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DeductionCalculationsService]
    });

    injector = getTestBed();
    service = injector.get(DeductionCalculationsService);
    httpMock = injector.get(HttpTestingController)
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
    expect(service.calculateEmployeeDeductions).toBeDefined();
  });

  it('should get compensation summary results', done => {
    const fakeRequest = new CompensationSummaryRequestContract();
    const fakeResult = new CompensationSummaryResultContract();
    service.calculateEmployeeDeductions(fakeRequest)
    .pipe(first())
    .subscribe(data => {
      expect(data).toEqual(fakeResult);
      done();
    });

    const request = httpMock.expectOne('http://localhost:4201/api/CompensationSummary');
    expect(request.request.method).toBe('POST');
    expect(request.request.body).toEqual(fakeRequest);
    request.flush(fakeResult);
  });
});
