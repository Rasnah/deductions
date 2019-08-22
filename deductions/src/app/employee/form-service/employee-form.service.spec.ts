import { FormBuilder } from '@angular/forms';
import { EmployeeContract } from 'src/app/contracts/employee.contract';
import { EmployeeFormService } from './employee-form.service';

describe('EmployeeFormService', () => {
  let service: EmployeeFormService;
  let formBuilder: FormBuilder;

  beforeEach(() => {
    formBuilder = new FormBuilder();

    service = new EmployeeFormService(formBuilder);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
    expect(service.initForm).toBeDefined();
    expect(service.getForm).toBeDefined();
    expect(service.getEmployee).toBeDefined();
    expect(service.getDependents).toBeDefined();
    expect(service.addDependentSlot).toBeDefined();
  });

  it('should establish the form', () => {
    const builderSpy = spyOn(formBuilder, 'group').and.callThrough();
    service.initForm();
    expect(builderSpy).toHaveBeenCalledWith(new EmployeeContract());
    const form = service.getForm();
    expect(form.get('dependents')).toBeTruthy();
  });

  it('should add new dependent slots and retrieve them', () => {
    service.initForm();
    expect(service.getDependents().controls.length).toBe(0);
    service.addDependentSlot();
    expect(service.getDependents().controls.length).toBe(1);
  });
});
