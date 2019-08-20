import { ChangeDetectionStrategy } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { first } from 'rxjs/operators';
import { DeductionCalculationsService } from '../employeeDeductions/deduction-calculations.service';
import { EmployeeFormService } from './form-service/employee-form.service';
import { EmployeeContract } from '../contracts/employee.contract';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployeeComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(private employeeFormService: EmployeeFormService, private deductionCalculationService: DeductionCalculationsService) { }

  ngOnInit() {
    //this.deductionCalculationService.testEndPoints().pipe(first()).subscribe();
    this.employeeFormService.initForm();
    this.employeeForm = this.employeeFormService.getEmployeeForm();
  }

  submit(): void {
    this.deductionCalculationService.calculateEmployeeDeductions(this.employeeFormService.getEmployee()).pipe(first()).subscribe();
  }

}
