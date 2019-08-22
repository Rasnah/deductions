import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { EmployeeContract } from 'src/app/contracts/employee.contract';

export class EmployeeFormServiceMock {
  form: FormGroup;
  formArray: FormArray;

  initForm = jasmine.createSpy('initForm').and.callFake(() => {});
  getForm = jasmine.createSpy('getForm').and.returnValue(this.form);
  getEmployee = jasmine.createSpy('getEmployee').and.returnValue(new EmployeeContract());
  getDependents = jasmine.createSpy('getDependents').and.returnValue(this.formArray);
  addDependentSlot = jasmine.createSpy('addDependentSlot').and.callFake(() => {});

  constructor() {
    this.form = new FormGroup({ fake: new FormControl() });
    this.formArray = new FormArray([]);
  }
}
