import { Injectable } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { DependentContract } from 'src/app/contracts/dependent.contract';
import { EmployeeContract } from 'src/app/contracts/employee.contract';

const FORM_NAME_DEPENDENTS = 'dependents';

@Injectable({
  providedIn: 'root'
})
export class EmployeeFormService {
  private employeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  initForm(): void {
    this.employeeForm = this.formBuilder.group(new EmployeeContract());
    this.employeeForm.setControl(FORM_NAME_DEPENDENTS, this.formBuilder.array([]));
  }

  getForm(): FormGroup {
    return this.employeeForm;
  }

  getEmployee(): EmployeeContract {
    return this.employeeForm.getRawValue() as EmployeeContract;
  }

  getDependents(): FormArray {
    return this.employeeForm.get(FORM_NAME_DEPENDENTS) as FormArray;
  }

  addDependentSlot(): void {
    const dependentArray = this.employeeForm.get(FORM_NAME_DEPENDENTS) as FormArray;
    dependentArray.push(this.formBuilder.group(new DependentContract()));
  }
}
