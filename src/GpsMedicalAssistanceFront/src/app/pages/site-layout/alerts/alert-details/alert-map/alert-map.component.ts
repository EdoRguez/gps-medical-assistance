import { Component, Input, OnInit } from '@angular/core';
import { AlertCoordinates } from '../interfaces/alert-coordinates.interface';
import * as L from 'leaflet';

const iconRetinaUrl = 'assets/marker-icon-2x.png';
const iconUrl = 'assets/marker-icon.png';
const shadowUrl = 'assets/marker-shadow.png';

@Component({
    selector: 'app-alert-map',
    templateUrl: './alert-map.component.html',
    styleUrls: ['./alert-map.component.scss'],
})
export class AlertMapComponent implements OnInit {
    @Input() alertCoordinates!: AlertCoordinates;
    private map: any;

    constructor() {}

    ngOnInit(): void {
        this.initMap();
    }

    private initMap(): void {
        //configuración del mapa
        this.map = L.map('map', {
            center: [
                this.alertCoordinates.currentLocation.latitude,
                this.alertCoordinates.currentLocation.longitude,
            ],
            attributionControl: false,
            zoom: 17,
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
        const markerCurrent = L.marker([
            this.alertCoordinates.currentLocation.latitude,
            this.alertCoordinates.currentLocation.longitude,
        ]).bindPopup(this.alertCoordinates.currentLocation.description, {
            keepInView: false,
            closeButton: false,
            closeOnClick: false,
            autoClose: false,
        });
        markerCurrent.addTo(this.map);
        markerCurrent.openPopup();

        //marca forma de circulo
        const markCurrent = L.circleMarker([
            this.alertCoordinates.currentLocation.latitude,
            this.alertCoordinates.currentLocation.longitude,
        ]).addTo(this.map);
        markCurrent.addTo(this.map);



        //marca con pop up
        const markerDestination = L.marker([
            this.alertCoordinates.destinationLocation.latitude,
            this.alertCoordinates.destinationLocation.longitude,
        ]).bindPopup(this.alertCoordinates.destinationLocation.description, {
            keepInView: false,
            closeButton: false,
            closeOnClick: false,
            autoClose: false,
        });
        markerDestination.addTo(this.map);
        markerDestination.openPopup();

        //marca forma de circulo
        const markDestination = L.circleMarker([
            this.alertCoordinates.destinationLocation.latitude,
            this.alertCoordinates.destinationLocation.longitude,
        ]).addTo(this.map);
        markDestination.addTo(this.map);

        var group = L.featureGroup([markerCurrent, markerDestination]);
        this.map.fitBounds(group.getBounds().pad(0.5));
    }
}
