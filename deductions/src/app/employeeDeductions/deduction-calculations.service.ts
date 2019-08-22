import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CompensationSummaryRequestContract } from '../contracts/compensation-summary-request.contract';
import { CompensationSummaryResultContract } from '../contracts/compensation-summary-result.contract';

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

  calculateEmployeeDeductions(request: CompensationSummaryRequestContract): Observable<CompensationSummaryResultContract> {
    return this.http.post<CompensationSummaryResultContract>('http://localhost:4201/api/CompensationSummary', request, httpOptions);
  }
}
