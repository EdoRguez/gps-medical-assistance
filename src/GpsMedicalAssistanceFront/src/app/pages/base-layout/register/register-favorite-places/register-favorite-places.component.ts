import {
    Component,
    ElementRef,
    OnDestroy,
    OnInit,
    Output,
    ViewChild,
} from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
    catchError,
    debounceTime,
    distinctUntilChanged,
    Observable,
    of,
    Subject,
    switchMap,
    tap,
} from 'rxjs';
import { ModalDeleteConfirmComponent } from 'src/app/shared/components/modal-delete-confirm/modal-delete-confirm.component';
import { ModalMessageComponent } from 'src/app/shared/components/modal-message/modal-message.component';
import { MapSearchLocation } from 'src/app/shared/interfaces/mapSearchLocation.interface';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { MapSearchLocationService } from 'src/app/shared/services/map/map-search-location.service';
import { AuthenticationRegister } from '../interfaces/authentication-register.interface';
import { FavoritePlaceCreate } from '../interfaces/favorite-place-create.interface';
import { RegisterManagerService } from '../services/register-manager.service';

@Component({
    selector: 'app-register-favorite-places',
    templateUrl: './register-favorite-places.component.html',
    styleUrls: ['./register-favorite-places.component.scss'],
})
export class RegisterFavoritePlacesComponent implements OnInit, OnDestroy {
    @Output() changeStepClick = new Subject<boolean>();

    favoritePlaces: FavoritePlaceCreate[] = [];

    model: any;
    searchingTextField = false;
    searchFailedTextField = false;
    isPlaceAlreadyAdded: boolean = false;

    constructor(
        private _mapSearchLocationService: MapSearchLocationService,
        private modalService: NgbModal,
        private authSvc: AuthenticationService,
        private registerManagerSvc: RegisterManagerService,
        private loaderSvc: LoaderService
    ) {}

    ngOnInit(): void {
        const favoritePlacesSaved: FavoritePlaceCreate[] =
            this.registerManagerSvc.getFavoritePlaces();
        if (favoritePlacesSaved) {
            this.favoritePlaces = favoritePlacesSaved;
        }
    }

    ngOnDestroy(): void {
        this.modalService.dismissAll();
    }

    onSelectDestination(event: any, inputSearch: any): void {
        const searchLocation: MapSearchLocation = event.item;

        const favoritePlace: FavoritePlaceCreate = {
            name: searchLocation.display_name,
            latitude: searchLocation.lat,
            longitude: searchLocation.lon,
        };

        this.isPlaceAlreadyAdded = this.favoritePlaces.some(
            (x) =>
                x.latitude === favoritePlace.latitude &&
                x.longitude === favoritePlace.longitude
        );

        if (!this.isPlaceAlreadyAdded) {
            this.favoritePlaces.push(favoritePlace);
        }

        event.preventDefault();
        inputSearch.value = '';
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

    onDeleteFavoritePlace(placeIndex: number): void {
        const modalDeleteConfirmRef = this.modalService.open(
            ModalDeleteConfirmComponent
        );

        modalDeleteConfirmRef.componentInstance.title =
            'Eliminar lugar de preferencia';
        modalDeleteConfirmRef.componentInstance.description =
            '¿Está seguro que este lugar de preferencia?';

        modalDeleteConfirmRef.result.then(
            (shouldDelete: boolean) => {
                if (shouldDelete) {
                    this.favoritePlaces.splice(placeIndex, 1);
                }
            },
            () => {}
        );
    }

    goBack(): void {
        this.changeStepClick.next(false);
    }

    nextSetp(): void {
        this.registerManagerSvc.updateFavoritePlaces(this.favoritePlaces);

        if (this.favoritePlaces.length > 0) {
            this.loaderSvc.toggleLoader(true);

            const auth: AuthenticationRegister =
                this.registerManagerSvc.getPersonalInfo();

            this.authSvc.registerUser(auth).subscribe({
                next: () => {
                    this.loaderSvc.toggleLoader(false);
                    this.changeStepClick.next(true);
                },
                error: (err: any) => {
                    let messageError =
                        'Hubo un error guardando los campos, por favor valida los datos ingresados';

                    if (err.error.Email)
                        messageError = 'El correo ingresado ya está en uso, por favor ingresa uno distinto';
                    if (err.error.Families)
                        messageError =
                            'Error con las familias ingresaas, por favor valida los datos';
                    if (err.error.ImagePath)
                        messageError =
                            'Error con la imagen ingresada, por favor valida la imagen';

                    const modalMessageRef = this.modalService.open(
                        ModalMessageComponent
                    );

                    modalMessageRef.componentInstance.title = 'Error';
                    modalMessageRef.componentInstance.description =
                        messageError;

                    this.loaderSvc.toggleLoader(false);
                },
            });
        }
    }
}
