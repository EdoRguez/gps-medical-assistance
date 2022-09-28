import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/interfaces/user.interface';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { AuthenticationLogin } from '../interfaces/authentication-login.interface';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent implements OnInit {
    isFormSubmitted: boolean = false;
    isLoginError: boolean = false;

    form: FormGroup = new FormGroup({
        email: new FormControl(null, [
            Validators.required,
            Validators.email,
            Validators.maxLength(50),
            Validators.pattern(
                /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            ),
        ]),
        password: new FormControl(null, [
            Validators.required,
            Validators.minLength(6),
        ])
    });

    constructor(
        private authSvc: AuthenticationService,
        private loaderSvc: LoaderService,
        private router: Router
    ) {}

    ngOnInit(): void {}

    onSubmitForm(): void {
      this.isFormSubmitted = true;
      this.isLoginError = false;

      if(this.form.valid) {
        this.loaderSvc.toggleLoader(true);

        const authLogin: AuthenticationLogin = {
          email: this.form.controls['email'].value,
          password: this.form.controls['password'].value
        }

        this.authSvc.login(authLogin).subscribe({
          next: () => {
            this.loaderSvc.toggleLoader(false);
            this.router.navigate(['']);
          },
          error: () => {
            this.isLoginError = true;
            this.loaderSvc.toggleLoader(false);
          }
        });
      }
    }
}
