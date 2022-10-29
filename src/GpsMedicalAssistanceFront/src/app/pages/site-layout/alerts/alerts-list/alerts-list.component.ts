import { Component, OnInit } from '@angular/core';
import * as dayjs from 'dayjs';
import { map, tap } from 'rxjs';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { AlertParameters } from '../interfaces/alert-parameters.interface';
import { Alert } from '../interfaces/alert.interface';
import { AlertService } from '../services/alert.service';

@Component({
    selector: 'app-alerts-list',
    templateUrl: './alerts-list.component.html',
    styleUrls: ['./alerts-list.component.scss'],
})
export class AlertsListComponent implements OnInit {
    isPageLoading: boolean = true;

    alertsList: Alert[] = [
        // { id: 1, imageUrl: 'assets/icons/user.png', name: 'Eduardo', lastName: 'Rodriguez', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 2, imageUrl: 'assets/icons/user.png', name: 'Pedro', lastName: 'Salas', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM- YYYY') },
        // { id: 3, imageUrl: 'assets/icons/user.png', name: 'Juan', lastName: 'Fuentes', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 4, imageUrl: 'assets/icons/user.png', name: 'María', lastName: 'Estela', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 5, imageUrl: 'assets/icons/user.png', name: 'Alexandra', lastName: 'Parra', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 6, imageUrl: 'assets/icons/user.png', name: 'Pablo', lastName: 'Aguiar', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 7, imageUrl: 'assets/icons/user.png', name: 'Isabella', lastName: 'Castillos', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 8, imageUrl: 'assets/icons/user.png', name: 'Carlos', lastName: 'Perez', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
        // { id: 8, imageUrl: 'assets/icons/user.png', name: 'Carlos', lastName: 'Perez', identification: 'V - 27.246.754', creationDate: dayjs().format('DD - MM - YYYY') },
    ];

    constructor(
        private alertSvc: AlertService,
        private loaderSvc: LoaderService
    ) {
        this.loaderSvc.toggleLoader(true);
    }

    ngOnInit(): void {
        const alertParameters: AlertParameters = {
            includes: [
                {
                    name: 'AlertUsers',
                    children: [
                        {
                            name: 'User',
                            children: [],
                        },
                    ],
                },
            ],
        };

        this.alertSvc
            .getAllFilter(alertParameters)
            .pipe(
                map((alerts: Alert[]) => {
                    const returnedValue: Alert[] = alerts.map((alert: Alert) => {
                        return {
                            id: alert.id,
                            currentLocationLatitude: alert.currentLocationLatitude,
                            currentLocationLongitude:
                                alert.currentLocationLongitude,
                            destinationLocationLatitude:
                                alert.destinationLocationLatitude,
                            destinationLocationLongitude:
                                alert.destinationLocationLongitude,
                            creationDate: alert.creationDate,
                            alertUsers: alert.alertUsers.filter(
                                (x) => x.id_AlertUserType === 2
                            ),
                        };
                    });

                    return returnedValue;
                }),
                tap((alerts: Alert[]) => {
                    this.alertsList = alerts;
                    this.isPageLoading = false;
                    this.loaderSvc.toggleLoader(false);
                })
            )
            .subscribe();
    }
}
