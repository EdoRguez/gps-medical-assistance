import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IncludesGeneral } from '../../interfaces/includes-general.interface';
import { User } from '../../interfaces/user.interface';
import { FaceRecognitionParameters } from '../request-features/face-recognition-parameters.interface';
import { UserParameters } from '../request-features/user-parameters.interface';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    private API_URL: string = environment.API_URL;

    constructor(private http: HttpClient) {}

    getAll(): Observable<User[]> {
        return this.http.get<User[]>(`${this.API_URL}/user`);
    }

    getAllFilter(parameters: UserParameters): Observable<User[]> {
        return this.http.post<User[]>(`${this.API_URL}/user/filter`, parameters);
    }

    getByFace(parameters: FaceRecognitionParameters): Observable<User> {
        return this.http.post<User>(`${this.API_URL}/user/getByFace`, parameters);
    }
}
