import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    CanActivate,
    Router,
    RouterStateSnapshot,
    UrlTree,
} from '@angular/router';
import { map, Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication/authentication.service';

@Injectable({
    providedIn: 'root',
})
export class IsAuthenticatedGuard implements CanActivate {
    constructor(private authSvc: AuthenticationService,
                private router: Router) {}

    canActivate():
        | Observable<boolean | UrlTree>
        | Promise<boolean | UrlTree>
        | boolean
        | UrlTree {

          return this.authSvc.isUserLogged$.pipe(
            map(isLoggedIn => {
              if (isLoggedIn) {
                return this.router.parseUrl('');
              }
      
              return true;
            })
          );
    }
}
