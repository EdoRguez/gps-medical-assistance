import { Component, Injectable, Input, OnDestroy, OnInit } from '@angular/core';
import { MapSearchLocationService } from 'src/app/shared/services/map/map-search-location.service';
import {
    catchError,
    debounceTime,
    distinctUntilChanged,
    Observable,
    of,
    tap,
    switchMap,
    firstValueFrom,
} from 'rxjs';
import { MapSearchLocation } from 'src/app/shared/interfaces/mapSearchLocation.interface';
import * as L from 'leaflet';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from 'src/app/shared/services/user/user.service';
import { UserParameters } from 'src/app/shared/services/request-features/user-parameters.interface';
import { User } from 'src/app/shared/interfaces/user.interface';
import { ModalAlertUserComponent } from 'src/app/pages/site-layout/alerts/alerts-create/modal-alert-user/modal-alert-user.component';
import { AlertCreate } from '../interfaces/alert-create.interface';
import { AlertUserCreate } from '../interfaces/alert-user-create.interface';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';
import { AlertService } from '../services/alert.service';
import { Alert } from '../interfaces/alert.interface';
import { ModalAlertCreatedComponent } from './modal-alert-created/modal-alert-created.component';
import { ModalUserAnonymousCreateComponent } from './modal-user-anonymous-create/modal-user-anonymous-create.component';
import { UserAnonymous } from '../interfaces/user-anonymous.interface';

const iconRetinaUrl = 'assets/marker-icon-2x.png';
const iconUrl = 'assets/marker-icon.png';
const shadowUrl = 'assets/marker-shadow.png';

@Component({
    selector: 'app-alerts-create',
    templateUrl: './alerts-create.component.html',
    styleUrls: ['./alerts-create.component.scss'],
})
export class AlertsCreateComponent implements OnInit, OnDestroy {
    isMapLoading: boolean = true;
    isPageLoading: boolean = false;
    isDestinationSelected: boolean = false;
    isFormSubmitted: boolean = false;

    destinationSelectedCoordinates!: { lat: number; lon: number };
    creationUserAnonymous: UserAnonymous | null = null;

    form: FormGroup = new FormGroup({
        destination: new FormControl(null, [Validators.required]),
        identificationType: new FormControl('', [Validators.required]),
        identification: new FormControl(null, [Validators.required]),
    });

    searchingTextField = false;
    searchFailedTextField = false;

    private map: any;
    private lat!: number;
    private lon!: number;
    private zoom!: number;

    constructor(
        private _mapSearchLocationSvc: MapSearchLocationService,
        private loaderSvc: LoaderService,
        private modalService: NgbModal,
        private userSvc: UserService,
        private authSvc: AuthenticationService,
        private alertSvc: AlertService
    ) {}

    ngOnInit(): void {
        this.isMapLoading = false;
        this.lat = 10.4834659;
        this.lon = -66.8091149;
        this.zoom = 17;

        this.initMap();
    }

    ngOnDestroy(): void {
        this.modalService.dismissAll();
    }

    async onSubmitForm(): Promise<void> {
        this.isFormSubmitted = true;
        this.creationUserAnonymous = null;

        if (
            this.form.controls['identification'].valid &&
            this.isDestinationSelected
        ) {
            this.loaderSvc.toggleLoader(true, 'Creando alerta..');
            this.isPageLoading = true;

            let isUserLogged = await firstValueFrom(
                this.authSvc.isUserLogged$
            ).then((result: boolean) => result);

            if (isUserLogged) {
                this.creationUserAnonymous = null;

                const params: UserParameters = {
                    identificationType:
                        this.form.controls['identificationType'].value,
                    identification: this.form.controls['identification'].value,
                    includes: [
                        {
                            name: 'FavoritePlaces',
                            children: [],
                        },
                    ],
                };

                this.userSvc.getAllFilter(params).subscribe((users: User[]) => {
                    this.isPageLoading = false;
                    this.loaderSvc.toggleLoader(false);

                    if (users.length > 0) {
                        const modalAlertUserRef = this.modalService.open(
                            ModalAlertUserComponent,
                            {
                                backdrop: 'static',
                                keyboard: false,
                                size: 'lg',
                            }
                        );
                        modalAlertUserRef.componentInstance.user = users[0];

                        modalAlertUserRef.result.then(
                            (idPlace: number) => {
                                if (idPlace) {
                                    const destinationLocation =
                                        users[0].favoritePlaces.find(
                                            (x) => x.id === idPlace
                                        );
                                    if (destinationLocation) {
                                        const alertCreate: AlertCreate = {
                                            currentLocationLatitude: this.lat,
                                            currentLocationLongitude: this.lon,
                                            destinationLocationLatitude:
                                                destinationLocation.latitude,
                                            destinationLocationLongitude:
                                                destinationLocation.longitude,
                                            alertUsers:
                                                this.buildAlertUserCreate(
                                                    users[0],
                                                    null
                                                ),
                                        };

                                        this.createAlert(alertCreate);
                                    }
                                } else {
                                    const alertCreate: AlertCreate = {
                                        currentLocationLatitude: this.lat,
                                        currentLocationLongitude: this.lon,
                                        destinationLocationLatitude:
                                            this.destinationSelectedCoordinates
                                                .lat,
                                        destinationLocationLongitude:
                                            this.destinationSelectedCoordinates
                                                .lon,
                                        alertUsers: this.buildAlertUserCreate(
                                            users[0],
                                            null
                                        ),
                                    };

                                    this.createAlert(alertCreate);
                                }
                            },
                            () => {}
                        );
                    } else {
                        const modalUserAnonymousRef = this.modalService.open(
                            ModalUserAnonymousCreateComponent
                        );
                        modalUserAnonymousRef.componentInstance.isCreationUserAnonymous =
                            false;

                        modalUserAnonymousRef.result.then(
                            (userAnonymousRisk: UserAnonymous) => {
                                if (userAnonymousRisk) {
                                    const alertCreate: AlertCreate = {
                                        currentLocationLatitude: this.lat,
                                        currentLocationLongitude: this.lon,
                                        destinationLocationLatitude:
                                            this.destinationSelectedCoordinates
                                                .lat,
                                        destinationLocationLongitude:
                                            this.destinationSelectedCoordinates
                                                .lon,
                                        alertUsers: this.buildAlertUserCreate(
                                            null,
                                            userAnonymousRisk
                                        ),
                                    };

                                    this.createAlert(alertCreate);
                                }
                            },
                            () => {}
                        );
                    }
                });
            } else {
                this.loaderSvc.toggleLoader(false);
                this.isPageLoading = false;
                const modalUserAnonymousRef = this.modalService.open(
                    ModalUserAnonymousCreateComponent
                );
                modalUserAnonymousRef.componentInstance.isCreationUserAnonymous =
                    true;

                modalUserAnonymousRef.result.then(
                    (userAnonymous: UserAnonymous) => {
                        if (userAnonymous) {
                            this.creationUserAnonymous = userAnonymous;

                            const params: UserParameters = {
                                identificationType:
                                    this.form.controls['identificationType']
                                        .value,
                                identification:
                                    this.form.controls['identification'].value,
                                includes: [
                                    {
                                        name: 'FavoritePlaces',
                                        children: [],
                                    },
                                ],
                            };

                            this.userSvc
                                .getAllFilter(params)
                                .subscribe((users: User[]) => {
                                    if (users.length > 0) {
                                        this.isPageLoading = false;
                                        this.loaderSvc.toggleLoader(false);

                                        const modalAlertUserRef =
                                            this.modalService.open(
                                                ModalAlertUserComponent,
                                                {
                                                    backdrop: 'static',
                                                    keyboard: false,
                                                    size: 'lg',
                                                }
                                            );
                                        modalAlertUserRef.componentInstance.user =
                                            users[0];

                                        modalAlertUserRef.result.then(
                                            (idPlace: number) => {
                                                if (idPlace) {
                                                    const destinationLocation =
                                                        users[0].favoritePlaces.find(
                                                            (x) =>
                                                                x.id === idPlace
                                                        );
                                                    if (destinationLocation) {
                                                        const alertCreate: AlertCreate =
                                                            {
                                                                currentLocationLatitude:
                                                                    this.lat,
                                                                currentLocationLongitude:
                                                                    this.lon,
                                                                destinationLocationLatitude:
                                                                    destinationLocation.latitude,
                                                                destinationLocationLongitude:
                                                                    destinationLocation.longitude,
                                                                alertUsers:
                                                                    this.buildAlertUserCreate(
                                                                        users[0],
                                                                        null
                                                                    ),
                                                            };

                                                        this.createAlert(
                                                            alertCreate
                                                        );
                                                    }
                                                } else {
                                                    const alertCreate: AlertCreate =
                                                        {
                                                            currentLocationLatitude:
                                                                this.lat,
                                                            currentLocationLongitude:
                                                                this.lon,
                                                            destinationLocationLatitude:
                                                                this
                                                                    .destinationSelectedCoordinates
                                                                    .lat,
                                                            destinationLocationLongitude:
                                                                this
                                                                    .destinationSelectedCoordinates
                                                                    .lon,
                                                            alertUsers:
                                                                this.buildAlertUserCreate(
                                                                    users[0],
                                                                    null
                                                                ),
                                                        };

                                                    this.createAlert(
                                                        alertCreate
                                                    );
                                                }
                                            },
                                            () => {}
                                        );
                                    } else {
                                        // emergency user is anonymous
                                        const modalUserAnonymousRef =
                                            this.modalService.open(
                                                ModalUserAnonymousCreateComponent
                                            );
                                        modalUserAnonymousRef.componentInstance.isCreationUserAnonymous =
                                            false;

                                        modalUserAnonymousRef.result.then(
                                            (
                                                userAnonymousRisk: UserAnonymous
                                            ) => {
                                                if (userAnonymousRisk) {
                                                    const alertCreate: AlertCreate =
                                                        {
                                                            currentLocationLatitude:
                                                                this.lat,
                                                            currentLocationLongitude:
                                                                this.lon,
                                                            destinationLocationLatitude:
                                                                this
                                                                    .destinationSelectedCoordinates
                                                                    .lat,
                                                            destinationLocationLongitude:
                                                                this
                                                                    .destinationSelectedCoordinates
                                                                    .lon,
                                                            alertUsers:
                                                                this.buildAlertUserCreate(
                                                                    null,
                                                                    userAnonymousRisk
                                                                ),
                                                        };

                                                    this.createAlert(
                                                        alertCreate
                                                    );
                                                }
                                            },
                                            () => {}
                                        );
                                    }
                                });
                        }
                    },
                    () => {}
                );
            }
        }
    }

    onClickMapHome(): void {
        this.fitMapView();
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

    private buildAlertUserCreate(
        userToHelp: User | null,
        userAnonymousToHelp: UserAnonymous | null
    ): AlertUserCreate[] {
        let alertUserCreate: AlertUserCreate[] = [];

        if (userToHelp != null) {
            alertUserCreate.push({
                id_User: userToHelp.id,
                userAnonymous: null,
                id_AlertUserType: 2,
            });
        } else {
            alertUserCreate.push({
                id_User: null,
                userAnonymous: userAnonymousToHelp,
                id_AlertUserType: 2,
            });
        }

        if (this.creationUserAnonymous) {
            alertUserCreate.push({
                userAnonymous: this.creationUserAnonymous,
                id_User: null,
                id_AlertUserType: 1,
            });
        } else {
            this.authSvc.getUserLogged$.subscribe({
                next: (user: User | null) => {
                    if (user) {
                        alertUserCreate.push({
                            id_User: user.id,
                            userAnonymous: null,
                            id_AlertUserType: 1,
                        });
                    }
                },
            });
        }

        return alertUserCreate;
    }

    private initMap(): void {
        this.map = L.map('map', {
            center: [this.lat, this.lon],
            attributionControl: false,
            zoom: this.zoom,
        });

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

        const tiles = L.tileLayer(
            'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
            {
                minZoom: 12.5,
                maxZoom: 18,
            }
        );

        tiles.addTo(this.map);

        const marker = L.marker([this.lat, this.lon]).bindPopup(
            'Ubicación Actual',
            {
                keepInView: false,
                closeButton: false,
                closeOnClick: false,
                autoClose: false,
            }
        );
        marker.addTo(this.map);
        marker.openPopup();

        const mark = L.circleMarker([this.lat, this.lon]).addTo(this.map);
        mark.addTo(this.map);

        var group = L.featureGroup([marker]);
        this.map.fitBounds(group.getBounds().pad(0.5));
    }

    onSelectDestination(event: any): void {
        const mapDestination: MapSearchLocation = event.item;

        this.isDestinationSelected = true;

        this.destinationSelectedCoordinates = {
            lat: Number(mapDestination.lat),
            lon: Number(mapDestination.lon),
        };

        const marker = L.marker([
            Number(mapDestination.lat),
            Number(mapDestination.lon),
        ]).bindPopup('Destino', {
            keepInView: false,
            closeButton: false,
            closeOnClick: false,
            autoClose: false,
        });

        marker.addTo(this.map);
        marker.openPopup();

        const mark = L.circleMarker([
            Number(mapDestination.lat),
            Number(mapDestination.lon),
        ]).addTo(this.map);
        mark.addTo(this.map);

        this.fitMapView();
    }

    search = (text$: Observable<string>) =>
        text$.pipe(
            debounceTime(500),
            distinctUntilChanged(),
            tap(() => (this.searchingTextField = true)),
            switchMap((term) =>
                this._mapSearchLocationSvc.searchLocationByQuery(term).pipe(
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

    private createAlert(alertCreate: AlertCreate): void {
        this.alertSvc.create(alertCreate).subscribe({
            next: (x: Alert) => {
                const modalAlertCreatedRef = this.modalService.open(
                    ModalAlertCreatedComponent,
                    {
                        backdrop: 'static',
                        keyboard: false,
                    }
                );
                modalAlertCreatedRef.componentInstance.idAlert = x.id;
                console.log('check returned');
                console.log(x);
            },
            error: (err) => {
                console.log('err');
                console.log(err);
            },
        });
    }

    private fitMapView(): void {
        let markerList: L.Layer[] = [];
        let circleMarkerList: L.CircleMarker[] = [];
        this.map.eachLayer((layer: any) => {
            if (layer instanceof L.Marker) {
                markerList.push(layer);
            }

            if (layer instanceof L.CircleMarker) {
                circleMarkerList.push(layer);
            }
        });

        if (markerList.length > 2) {
            this.map.removeLayer(markerList[1]);
        }

        if (circleMarkerList.length > 2) {
            this.map.removeLayer(circleMarkerList[1]);
        }

        let group = L.featureGroup(markerList);
        this.map.fitBounds(group.getBounds());
    }
}
