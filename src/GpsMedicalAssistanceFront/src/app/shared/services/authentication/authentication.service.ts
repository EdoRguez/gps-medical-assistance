import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { AuthenticationLogin } from 'src/app/pages/base-layout/login/interfaces/authentication-login.interface';
import { AuthenticationRegister } from 'src/app/pages/base-layout/register/interfaces/authentication-register.interface';
import { environment } from 'src/environments/environment';
import { User } from '../../interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private baseUrl: string = environment.API_URL;

  private isUserLoggedSubject = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }

  firstLoadValidation(): void {
    this.isUserLoggedSubject.next(
      (localStorage.getItem('user')) ? true : false
    );
  }

  registerUser(auth: AuthenticationRegister): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/authentication/register`, auth).pipe(
      tap((user: User) => {
        if(user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.isUserLoggedSubject.next(true);
        }
      })
    );
  }

  login(auth: AuthenticationLogin): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/authentication/login`, auth).pipe(
      tap((user: User) => {
        if(user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.isUserLoggedSubject.next(true);
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('user');
    this.isUserLoggedSubject.next(false);
  }

  get isUserLogged$(): Observable<boolean> {
    return this.isUserLoggedSubject.asObservable();
  }
}
