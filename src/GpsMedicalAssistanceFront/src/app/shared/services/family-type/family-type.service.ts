import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FamilyType } from '../../interfaces/family-type.interface';

@Injectable({
  providedIn: 'root'
})
export class FamilyTypeService {

  private API_URL: string = environment.API_URL;

  constructor(private http: HttpClient) { }

  getFamilyTypes(): Observable<FamilyType[]> {
    return this.http.get<FamilyType[]>(`${this.API_URL}/familyType`);
  }
}
