import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Status } from '../../models/status.model';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  private apiUrl = `${environment.apiUrl}/Status`;

  constructor(private http: HttpClient) {}

  // dropdown list
  getStatuses(): Observable<Status[]> {
    return this.http.get<Status[]>(`${this.apiUrl}/Get`);
  }
}
