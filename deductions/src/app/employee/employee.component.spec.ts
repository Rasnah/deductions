import { async, TestBed } from '@angular/core/testing';
import { DeductionCalculationServiceMock } from 'src/mocks/deduction-calculation-service.mock';
import { EmployeeFormServiceMock } from 'src/mocks/employee-form-service.mock';
import { DeductionCalculationsService } from '../employeeDeductions/deduction-calculations.service';
import { EmployeeComponent } from './employee.component';
import { EmployeeFormService } from './form-service/employee-form.service';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let employeeFormServiceMock: EmployeeFormServiceMock;
  let deductionCalculationServiceMock: DeductionCalculationServiceMock;

  beforeEach(() => {
    employeeFormServiceMock = new EmployeeFormServiceMock();
    deductionCalculationServiceMock = new DeductionCalculationServiceMock();
  });

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeComponent ]
    })
    .overrideComponent(EmployeeComponent, {
      set: {
        template: '',
        providers: [
          { provide: EmployeeFormService, useValue: employeeFormServiceMock },
          { provide: DeductionCalculationsService, useValue: deductionCalculationServiceMock }
        ]
      }
    });

    const fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.submit).toBeDefined();
    expect(component.addDependent).toBeDefined();
  });

  it('should call into the form service to add dependents', () => {
    component.addDependent();
    expect(employeeFormServiceMock.addDependentSlot).toHaveBeenCalled();
  });

  it('should call into the deduction calculation service to submit', () => {
    component.submit();
    expect(deductionCalculationServiceMock.calculateEmployeeDeductions).toHaveBeenCalled();
  });
});
