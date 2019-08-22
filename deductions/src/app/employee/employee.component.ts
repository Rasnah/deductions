import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { first, map } from 'rxjs/operators';
import { CompensationSummaryRequestContract } from '../contracts/compensation-summary-request.contract';
import { CompensationSummaryResultContract } from '../contracts/compensation-summary-result.contract';
import { PaycheckContract } from '../contracts/paycheck.contract';
import { DeductionCalculationsService } from '../employeeDeductions/deduction-calculations.service';
import { EmployeeFormService } from './form-service/employee-form.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
  annualSalary = 0;
  annualDeductions = 0;
  annualNetPay = 0;
  paychecks = new Array<PaycheckContract>();

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
    this.deductionCalculationService.calculateEmployeeDeductions(request)
      .pipe(first(), map((result: CompensationSummaryResultContract) => {
        this.annualSalary = result.annualSalary;
        this.annualDeductions = result.annualDeductions;
        this.annualNetPay = result.annualNetPay;
        this.paychecks = result.paychecks;
      }))
      .subscribe();
  }

  addDependent(): void {
    this.employeeFormService.addDependentSlot();
  }
}
