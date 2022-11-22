import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as dayjs from 'dayjs';
import { map, tap } from 'rxjs';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { AlertParameters } from '../interfaces/alert-parameters.interface';
import { Alert } from '../interfaces/alert.interface';
import { AlertsFilter } from '../interfaces/alerts-filter.interface';
import { AlertManagerService } from '../services/alert-manager.service';
import { AlertService } from '../services/alert.service';

@Component({
    selector: 'app-alerts-list',
    templateUrl: './alerts-list.component.html',
    styleUrls: ['./alerts-list.component.scss'],
})
export class AlertsListComponent implements OnInit {
    isPageLoading: boolean = true;

    alertsList: Alert[] = [];

    constructor(
        private alertSvc: AlertService,
        private loaderSvc: LoaderService,
        private router: Router,
        private alertManager: AlertManagerService
    ) {
        this.loaderSvc.toggleLoader(true);
    }

    ngOnInit(): void {
        this.alertManager.alertFilterAction$
            .pipe(
                tap((x: AlertsFilter | null) => {
                    this.searchAlerts(x);
                })
            )
            .subscribe();
    }

    navigateToDetails(id: number): void {
        this.router.navigate(['alerts', id]);
    }

    private searchAlerts(filter: AlertsFilter | null): void {
        const alertParameters: AlertParameters = {
            orderBy: 1,
            includes: [
                {
                    name: 'AlertUsers',
                    children: [
                        {
                            name: 'User',
                            children: [],
                        },
                        {
                            name: 'UserAnonymous',
                            children: []
                        }
                    ],
                },
            ],
            name: filter?.name || null,
            lastName: filter?.lastName || null,
            identification: filter?.identification?.toString() || null,
            identificationType: filter?.identificationType || null,
            age: filter?.age || filter?.age === 0 ? filter?.age : null,
            initDate: filter?.initDate || null,
            endDate: filter?.endDate || null,
            alertUserTypeId: filter?.alertUserTypeId || 2,
        };

        this.alertSvc
            .getAllFilter(alertParameters)
            .pipe(
                tap((alerts: Alert[]) => {
                    this.alertsList = alerts;
                    this.isPageLoading = false;
                    this.loaderSvc.toggleLoader(false);
                })
            )
            .subscribe();
    }

    getAlertUserName(alert: Alert): string {
        if(alert.alertUsers[0].user) {
            return `${alert.alertUsers[0].user.name} ${alert.alertUsers[0].user.lastName}`;
        } else {
            return (alert.alertUsers[0].userAnonymous?.name) ? alert.alertUsers[0].userAnonymous.name : 'Usuario Anónimo';
        }
    }
}
