import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AlertCreate } from '../interfaces/alert-create.interface';
import { AlertParameters } from '../interfaces/alert-parameters.interface';
import { Alert } from '../interfaces/alert.interface';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  private baseUrl: string = environment.API_URL;

  constructor(private _http: HttpClient) { }

  getAllFilter(parameters: AlertParameters): Observable<Alert[]> {
    return this._http.post<Alert[]>(`${this.baseUrl}/Alert/Filter`, parameters);
  }

  create(model: AlertCreate): Observable<Alert> {
    return this._http.post<Alert>(`${this.baseUrl}/Alert`, model);
  }
}
