import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { DeductionCalculationsService } from '../employeeDeductions/deduction-calculations.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  constructor(private deductionCalculationService: DeductionCalculationsService) { }

  ngOnInit() {
    this.deductionCalculationService.testEndPoints().pipe(first()).subscribe();
  }

}
