import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/shared/interfaces/user.interface';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { MapSearchLocationService } from 'src/app/shared/services/map/map-search-location.service';
import { Alert } from '../interfaces/alert.interface';
import { AlertService } from '../services/alert.service';
import { AlertCoordinates } from './interfaces/alert-coordinates.interface';

@Component({
    selector: 'app-alert-details',
    templateUrl: './alert-details.component.html',
    styleUrls: ['./alert-details.component.scss'],
})
export class AlertDetailsComponent implements OnInit {
    isPageLoading: boolean = true;
    alert!: Alert;

    constructor(
        private alertSvc: AlertService,
        private loaderSvc: LoaderService,
        private route: ActivatedRoute
    ) {
        this.loaderSvc.toggleLoader(true);
        this.loadData();
    }

    ngOnInit(): void {}

    private loadData(): void {
        const id: number = +this.route.snapshot.params['id'];
        this.alertSvc.get(id).subscribe({
            next: (alert: Alert) => {
                this.alert = alert;
                this.isPageLoading = false;
                this.loaderSvc.toggleLoader(false);
            },
            error: (err) => {
                console.log('error');
                console.log(err);
            }
        });
    }

    getUser(alertUserType: number): User | null {
        const user = this.alert.alertUsers.find(x => x.id_AlertUserType === alertUserType)?.user;
        return user ?? null;
    }

    getAlertMovements(): Alert {
        const alert: Alert = {
            ...this.alert,
            alertUsers: []
        }

        return alert;
    }

    getAlertCoordinates(): AlertCoordinates {
        const alertCoordinates: AlertCoordinates = {
            currentLocation: {
                latitude: this.alert.currentLocationLatitude,
                longitude: this.alert.currentLocationLongitude,
                description: 'Accidente'
            },
            destinationLocation: {
                latitude: this.alert.destinationLocationLatitude,
                longitude: this.alert.destinationLocationLongitude,
                description: 'Destino'
            }
        }

        return alertCoordinates;
    }
}
