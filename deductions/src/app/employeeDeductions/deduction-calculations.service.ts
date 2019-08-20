import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeContract } from '../contracts/employee.contract';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
   providedIn: 'root'
})
export class DeductionCalculationsService {

  constructor(private http: HttpClient) { }

  calculateEmployeeDeductions(employee: EmployeeContract): Observable<number> {
    //return this.http.post<number>('http://localhost:4201/api/DeductionCalculations', employee, httpOptions);
    return this.http.get<number>('http://localhost:4201/api/DeductionCalculations');
  }
}
