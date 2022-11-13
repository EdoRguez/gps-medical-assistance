import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
    AbstractControl,
    FormControl,
    FormGroup,
    ValidationErrors,
    ValidatorFn,
    Validators,
} from '@angular/forms';
import {
    NgbDateAdapter,
    NgbDateParserFormatter,
} from '@ng-bootstrap/ng-bootstrap';
import { Subject, tap } from 'rxjs';
import {
    CustomAdapter,
    CustomDateParserFormatter,
} from 'src/app/shared/services/general/ngb-date-custom.service';
import { AuthenticationRegister } from '../interfaces/authentication-register.interface';
import { UserCreate } from '../interfaces/user-create.interface';
import { RegisterManagerService } from '../services/register-manager.service';
import * as dayjs from 'dayjs';

@Component({
    selector: 'app-register-personal-info',
    templateUrl: './register-personal-info.component.html',
    styleUrls: ['./register-personal-info.component.scss'],
    providers: [
        { provide: NgbDateAdapter, useClass: CustomAdapter },
        {
            provide: NgbDateParserFormatter,
            useClass: CustomDateParserFormatter,
        },
    ],
})
export class RegisterPersonalInfoComponent implements OnInit {
    @Output() changeStepClick = new Subject<boolean>();

    readonly currentDate: Date = new Date();

    isFormSubmitted: boolean = false;

    form: FormGroup = new FormGroup(
        {
            name: new FormControl(null, [
                Validators.required,
                Validators.minLength(4),
                Validators.maxLength(20),
                Validators.pattern(/^[a-zA-Z\s]*$/),
            ]),
            lastName: new FormControl(null, [
                Validators.required,
                Validators.minLength(4),
                Validators.maxLength(20),
                Validators.pattern(/^[a-zA-Z\s]*$/),
            ]),
            email: new FormControl(null, [
                Validators.required,
                Validators.email,
                Validators.maxLength(50),
                Validators.pattern(
                    /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
                ),
            ]),
            identification: new FormControl(null, [
                Validators.required,
                Validators.minLength(2),
                Validators.maxLength(9),
                Validators.pattern(/^[0-9]*$/),
            ]),
            identificationType: new FormControl("", [Validators.required]),
            phone: new FormControl(null, [
                Validators.required,
                Validators.minLength(7),
                Validators.maxLength(7),
                Validators.pattern(/^[0-9]*$/),
            ]),
            phoneType: new FormControl("", [Validators.required]),
            birthDate: new FormControl(null, [Validators.required]),
            imagePath: new FormControl(null),
            password: new FormControl(null, [
                Validators.required,
                Validators.minLength(6),
            ]),
            confirmPassword: new FormControl(null, [
                Validators.required,
                Validators.minLength(6),
            ]),
        },
        [this.MatchValidator('password', 'confirmPassword')]
    );

    constructor(private registerManagerSvc: RegisterManagerService) {}

    ngOnInit(): void {
        const personalInfo: AuthenticationRegister = this.registerManagerSvc.getPersonalInfo();

        if(personalInfo.user.email) {
            this.form.controls['name'].setValue(personalInfo.user.name);
            this.form.controls['lastName'].setValue(personalInfo.user.lastName);
            this.form.controls['email'].setValue(personalInfo.user.email);
            const splittedIdentification: string[] = personalInfo.user.identification.split('-')
            this.form.controls['identificationType'].setValue(splittedIdentification[0]);
            this.form.controls['identification'].setValue(splittedIdentification[1]);
            const formattedBirthDate: string = `${dayjs(personalInfo.user.birthDate).get('day')}-${dayjs(personalInfo.user.birthDate).get('month') + 1}-${dayjs(personalInfo.user.birthDate).get('year')}`
            this.form.controls['birthDate'].setValue(formattedBirthDate);
            const splittedPhone: string[] = personalInfo.user.phone.split('-');
            this.form.controls['phoneType'].setValue(splittedPhone[0]);
            this.form.controls['phone'].setValue(splittedPhone[1]);
            this.form.controls['imagePath'].setValue(personalInfo.user.imagePath);
            this.form.controls['password'].setValue(personalInfo.password);
            this.form.controls['confirmPassword'].setValue(personalInfo.password);
        }
    }

    onSubmitForm(): void {
        this.isFormSubmitted = true;

        if (this.form.valid) {
            const splittedBirthDate: string[] = (<string>(
                this.form.controls['birthDate'].value
            )).split('-');

            const formattedBirthDate: Date = new Date(
                +splittedBirthDate[2],
                +splittedBirthDate[1] - 1,
                +splittedBirthDate[0]
            );
            const formattedIdentification: string = `${this.form.controls['identificationType'].value}-${this.form.controls['identification'].value}`;
            const formattedPhone: string = `${this.form.controls['phoneType'].value}-${this.form.controls['phone'].value}`;

            const userCreate: UserCreate = {
                name: this.form.controls['name'].value,
                lastName: this.form.controls['lastName'].value,
                email: this.form.controls['email'].value,
                identification: formattedIdentification,
                phone: formattedPhone,
                birthDate: formattedBirthDate,
                imagePath: this.form.controls['imagePath'].value,
                families: [],
                favoritePlaces: []
            };

            const authenticationRegister: AuthenticationRegister = {
                user: userCreate,
                password: this.form.controls['password'].value,
            };

            this.registerManagerSvc.updatePersonalInfo(authenticationRegister);
            this.changeStepClick.next(true);
        }
    }

    MatchValidator(source: string, target: string): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            const sourceCtrl = control.get(source);
            const targetCtrl = control.get(target);

            return sourceCtrl &&
                targetCtrl &&
                sourceCtrl.value !== targetCtrl.value
                ? { mismatch: true }
                : null;
        };
    }

    goBack(): void {
        this.changeStepClick.next(false);
    }
}
