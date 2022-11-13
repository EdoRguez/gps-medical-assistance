import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
    NgbDateAdapter,
    NgbDateParserFormatter,
    NgbDateStruct,
} from '@ng-bootstrap/ng-bootstrap';
import {
    CustomAdapter,
    CustomDateParserFormatter,
} from 'src/app/shared/services/general/ngb-date-custom.service';
import { AlertsFilter } from '../interfaces/alerts-filter.interface';
import { AlertManagerService } from '../services/alert-manager.service';

@Component({
    selector: 'app-alerts-filter',
    templateUrl: './alerts-filter.component.html',
    styleUrls: ['./alerts-filter.component.scss'],
    providers: [
        { provide: NgbDateAdapter, useClass: CustomAdapter },
        {
            provide: NgbDateParserFormatter,
            useClass: CustomDateParserFormatter,
        },
    ],
})
export class AlertsFilterComponent implements OnInit {
    form: FormGroup = new FormGroup({
        name: new FormControl(null),
        lastName: new FormControl(null),
        identification: new FormControl(null),
        identificationType: new FormControl(null),
        age: new FormControl(null),
        initDate: new FormControl(null),
        endDate: new FormControl(null),
    });

    constructor(private alertManager: AlertManagerService) {}

    ngOnInit(): void {}

    onClickFilter(): void {
        const alertsFilter: AlertsFilter = {
            ...this.form.value,
            initDate: this.formatDateFromControl('initDate'),
            endDate: this.formatDateFromControl('endDate'),
            alertUserTypeId: 2, // User in risk
        };

        this.alertManager.emitAlertFilter(alertsFilter);
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

    onClearFields(): void {
        this.form.reset();

        const alertsFilter: AlertsFilter = {
            ...this.form.value,
            initDate: this.formatDateFromControl('initDate'),
            endDate: this.formatDateFromControl('endDate'),
            alertUserTypeId: 2, // User in risk
        };

        this.alertManager.emitAlertFilter(alertsFilter);
    }

    private formatDateFromControl(controlName: string): Date | null {
        const controlValue: string = this.form.controls[controlName].value;

        if (!controlValue) return null;

        const splittedDate: string[] = controlValue.split('-');

        const formattedDate: Date = new Date(
            +splittedDate[2],
            +splittedDate[1] - 1,
            +splittedDate[0]
        );

        return formattedDate;
    }
}
