import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
   providedIn: 'root'
})
export class DeductionCalculationsService {

  constructor(private http: HttpClient) { }

  testEndPoints(): Observable<string> {
    return this.http.get<string>('http://localhost:4201/api/values');
  }
}
