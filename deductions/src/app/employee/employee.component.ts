import { ChangeDetectionStrategy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { first } from 'rxjs/operators';
import { DeductionCalculationsService } from '../employeeDeductions/deduction-calculations.service';
import { EmployeeFormService } from './form-service/employee-form.service';
import { CompensationSummaryRequestContract } from '../contracts/compensation-summary-request.contract';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployeeComponent implements OnInit {
  get employeeForm(): FormGroup {
    return this.employeeFormService.getForm();
  }
  get dependentsArray(): FormArray {
    return this.employeeFormService.getDependents();
  }

  constructor(private employeeFormService: EmployeeFormService, private deductionCalculationService: DeductionCalculationsService) { }

  ngOnInit() {
    this.employeeFormService.initForm();
  }

  submit(): void {
    const request = new CompensationSummaryRequestContract();
    request.numberOfPaychecks = 26;
    request.employee = this.employeeFormService.getEmployee();
    this.deductionCalculationService.calculateEmployeeDeductions(request).pipe(first()).subscribe();
  }

  addDependent(): void {
    this.employeeFormService.addDependentSlot();
  }
}
