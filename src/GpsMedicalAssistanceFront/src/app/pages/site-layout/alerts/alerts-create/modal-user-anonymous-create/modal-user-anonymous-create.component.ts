import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserAnonymous } from '../../interfaces/user-anonymous.interface';

@Component({
    selector: 'app-modal-user-anonymous-create',
    templateUrl: './modal-user-anonymous-create.component.html',
    styleUrls: ['./modal-user-anonymous-create.component.scss'],
})
export class ModalUserAnonymousCreateComponent implements OnInit {
    @Input() isCreationUserAnonymous: boolean = true;
    isFormSubmitted: boolean = false;

    form: FormGroup = new FormGroup({
        name: new FormControl(null, [
            Validators.minLength(4),
            Validators.maxLength(50),
            Validators.pattern(/^[a-zA-Z\s]*$/),
        ]),
        identification: new FormControl(null, [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(9),
            Validators.pattern(/^[0-9]*$/),
        ]),
        identificationType: new FormControl(''),
        phone: new FormControl(null, [
            Validators.required,
            Validators.minLength(7),
            Validators.maxLength(7),
            Validators.pattern(/^[0-9]*$/),
        ]),
        phoneType: new FormControl(''),
        age: new FormControl(null),
        gender: new FormControl(''),
        height: new FormControl(null),
    });

    constructor(public activeModal: NgbActiveModal, private router: Router) {}

    ngOnInit(): void {}

    onNavigateToLogin(): void {
        this.activeModal.dismiss();
        this.router.navigate(['/login']);
    }

    onSaveAnonymousData(): void {
        const userAnonymous: UserAnonymous = {
            ...this.form.value,
            gender: this.form.controls['gender'].value
                ? `${this.form.controls['gender'].value}`
                : null,
            identification:
                this.form.controls['identification'].value &&
                this.form.controls['identificationType'].value
                    ? `${this.form.controls['identificationType'].value}-${this.form.controls['identification'].value}`
                    : null,
            phone:
                this.form.controls['phone'].value &&
                this.form.controls['phoneType'].value
                    ? `${this.form.controls['phoneType'].value}-${this.form.controls['phone'].value}`
                    : null,
        };

        this.activeModal.close(userAnonymous);
    }

    onlyNumber(event: any): void {
        const keyCode = event.keyCode;
        const excludedKeys = [8, 37, 39, 46];

        if (
            !(
                (keyCode >= 48 && keyCode <= 57) ||
                (keyCode >= 96 && keyCode <= 105) ||
                excludedKeys.includes(keyCode)
            )
        ) {
            event.preventDefault();
        }
    }

    onlyDecimals(element: HTMLInputElement, event: any): void {
        let keyCode: number = event.which ? event.which : event.keyCode;
        const excludedKeys = [8, 37, 39, 46];

        if (keyCode === 190) {
            if (
                element.value.indexOf('.') !== -1 ||
                element.value.length >= 3 ||
                element.value.length === 0
            )
                event.preventDefault();
        } else {
            if (
                !(
                    (keyCode >= 48 && keyCode <= 57) ||
                    (keyCode >= 96 && keyCode <= 105) ||
                    excludedKeys.includes(keyCode)
                )
            )
                event.preventDefault();

            if (element.value.indexOf('.') !== -1) {
                const substringDecimals: string = element.value.substring(
                    element.value.indexOf('.') + 1
                );

                if (
                    substringDecimals.length >= 2 &&
                    !excludedKeys.includes(keyCode)
                )
                    event.preventDefault();
            }
        }
    }
}
