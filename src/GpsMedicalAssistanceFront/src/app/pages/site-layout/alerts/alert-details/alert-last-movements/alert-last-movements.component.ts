import { Component, Input, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { MapSearchLocationService } from 'src/app/shared/services/map/map-search-location.service';
import { Alert } from '../../interfaces/alert.interface';
import { AlertCoordinates } from '../interfaces/alert-coordinates.interface';

@Component({
    selector: 'app-alert-last-movements',
    templateUrl: './alert-last-movements.component.html',
    styleUrls: ['./alert-last-movements.component.scss'],
})
export class AlertLastMovementsComponent implements OnInit {
    @Input() alert!: Alert;

    lastMovements!: AlertCoordinates;

    constructor(private mapSearchLocationSvc: MapSearchLocationService) {}

    ngOnInit(): void {
        forkJoin({
            currentLocation: this.mapSearchLocationSvc.searchLocationByCoordinates(this.alert.currentLocationLatitude, this.alert.currentLocationLongitude),
            destinationLocation: this.mapSearchLocationSvc.searchLocationByCoordinates(this.alert.destinationLocationLatitude, this.alert.destinationLocationLongitude)})
            .subscribe(results => {
                this.lastMovements = {
                    currentLocation: {
                        latitude: +results.currentLocation.lat,
                        longitude: +results.currentLocation.lon,
                        description: results.currentLocation.display_name
                    },
                    destinationLocation: {
                        latitude: +results.destinationLocation.lat,
                        longitude: +results.destinationLocation.lon,
                        description: results.destinationLocation.display_name
                    }
                }
          });
    }
}
