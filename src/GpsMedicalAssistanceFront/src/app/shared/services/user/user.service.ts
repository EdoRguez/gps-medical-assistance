import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../../interfaces/user.interface';
import { UserParameters } from '../request-features/user-parameters.interface';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    private API_URL: string = environment.API_URL;

    constructor(private http: HttpClient) {}

    getAll(parameters: UserParameters): Observable<User[]> {
        const options = {
          params: new HttpParams()
                        .set('identificationType', parameters.identificationType)
                        .set('identification', parameters.identification)
        }

        if(parameters.includes) {
            parameters.includes.forEach((include: string) =>{
              options.params = options.params.append(`includes`, include);
            });
        }

        return this.http.get<User[]>(`${this.API_URL}/user`, options);
    }
}
