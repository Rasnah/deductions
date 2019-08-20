import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmployeeContract } from 'src/app/contracts/employee.contract';

@Injectable({
  providedIn: 'root'
})
export class EmployeeFormService {
  private employeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  initForm(): void {
    this.employeeForm = this.formBuilder.group(new EmployeeContract());
  }

  getEmployeeForm(): FormGroup {
    return this.employeeForm;
  }

  getEmployee(): EmployeeContract {
    return this.employeeForm.getRawValue() as EmployeeContract;
  }
}
