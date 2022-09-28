import { Component, Injectable, Input, OnInit } from '@angular/core';
import { MapSearchLocationService } from 'src/app/shared/services/map/map-search-location.service';
import {
    catchError,
    debounceTime,
    distinctUntilChanged,
    Observable,
    of,
    tap,
    switchMap,
} from 'rxjs';
import { MapSearchLocation } from 'src/app/shared/interfaces/mapSearchLocation.interface';
import * as L from 'leaflet';

const iconRetinaUrl = 'assets/marker-icon-2x.png';
const iconUrl = 'assets/marker-icon.png';
const shadowUrl = 'assets/marker-shadow.png';

@Component({
    selector: 'app-alerts-create',
    templateUrl: './alerts-create.component.html',
    styleUrls: ['./alerts-create.component.scss']
})
export class AlertsCreateComponent implements OnInit {
    isMapLoading: boolean = true;

    model: any;
    searchingTextField = false;
    searchFailedTextField = false;

    private map: any;
    private lat!: number;
    private lon!: number;
    private zoom!: number;

    constructor(
        private _mapSearchLocationService: MapSearchLocationService,
    ) {
        // navigator.geolocation.getCurrentPosition(
        //     (result: GeolocationPosition) => {
        //         this.isMapLoading = false;

        //         this.lat = result.coords.latitude;
        //         this.lon = result.coords.longitude;
        //         this.zoom = 17;
        //         this.initMap();
        //     },
        //     (error) => {
        //         console.log(error);
        //         alert('Hubo un error al obtener tu ubicacón, refresca la página');
        //     }
        // );
    }

    ngOnInit(): void {
        this.isMapLoading = false;
        this.lat = 10.4834659;
        this.lon = -66.8091149;
        this.zoom = 17;

        this.initMap();
    }

    private initMap(): void {
        //configuración del mapa
        this.map = L.map('map', {
            center: [this.lat, this.lon],
            attributionControl: false,
            zoom: this.zoom,
        });

        //iconos personalizados
        var iconDefault = L.icon({
            iconRetinaUrl,
            iconUrl,
            shadowUrl,
            iconSize: [25, 41],
            iconAnchor: [12, 41],
            popupAnchor: [1, -34],
            tooltipAnchor: [16, -28],
            shadowSize: [41, 41],
        });
        L.Marker.prototype.options.icon = iconDefault;

        //titulo
        const tiles = L.tileLayer(
            'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
            {
                minZoom: 12.5,
                maxZoom: 18,
            }
        );
        tiles.addTo(this.map);

        //marca con pop up
        const marker = L.marker([this.lat, this.lon]).bindPopup('Ubicación Actual', {
            keepInView: false,
            closeButton: false,
            closeOnClick: false,
            autoClose: false
        });
        marker.addTo(this.map);
        marker.openPopup();

        //marca forma de circulo
        const mark = L.circleMarker([this.lat, this.lon]).addTo(this.map);
        mark.addTo(this.map);

        var group = L.featureGroup([marker]);
        this.map.fitBounds(group.getBounds().pad(0.5));
    }

    onSelectDestination(event: any): void {
        const mapDestination: MapSearchLocation = event.item;

        const marker = L.marker([
            Number(mapDestination.lat),
            Number(mapDestination.lon),
        ]).bindPopup('Destino', {
            keepInView: false,
            closeButton: false,
            closeOnClick: false,
            autoClose: false
        });

        
        marker.addTo(this.map);
        marker.openPopup();

        const mark = L.circleMarker([Number(mapDestination.lat), Number(mapDestination.lon)]).addTo(this.map);
        mark.addTo(this.map);

        let markerList: L.Layer[] = [];
        let circleMarkerList: L.CircleMarker[] = [];
        this.map.eachLayer((layer: any) => {
            if (layer instanceof L.Marker) {
                markerList.push(layer);
            };

            if(layer instanceof L.CircleMarker) {
                circleMarkerList.push(layer);
            }
        });
        
        if(markerList.length > 2) {
            this.map.removeLayer(markerList[1]);
        }

        if(circleMarkerList.length > 2) {
            this.map.removeLayer(circleMarkerList[1]);
        }
        
        var group = L.featureGroup(markerList);
        this.map.fitBounds(group.getBounds());
    }

    search = (text$: Observable<string>) =>
        text$.pipe(
            debounceTime(500),
            distinctUntilChanged(),
            tap(() => (this.searchingTextField = true)),
            switchMap((term) =>
                this._mapSearchLocationService.searchLocationByQuery(term).pipe(
                    tap(() => (this.searchFailedTextField = false)),
                    catchError((e) => {
                        this.searchFailedTextField = true;
                        return of([]);
                    })
                )
            ),
            tap(() => (this.searchingTextField = false))
        );

    formatter = (x: MapSearchLocation) => x.display_name;
}
