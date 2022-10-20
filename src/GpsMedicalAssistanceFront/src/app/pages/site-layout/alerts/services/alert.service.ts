import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AlertCreate } from '../interfaces/alert-create.interface';
import { Alert } from '../interfaces/alert.interface';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  private baseUrl: string = environment.API_URL;

  constructor(private _http: HttpClient) { }

  create(model: AlertCreate): Observable<Alert> {
    return this._http.post<AlertCreate>(`${this.baseUrl}/Alert`, model);
  }
}
