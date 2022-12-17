import { NgModule, LOCALE_ID } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterRoutingModule } from './register-routing.module';
import { RegisterComponent } from './register.component';
import { RegisterPersonalInfoComponent } from './register-personal-info/register-personal-info.component';
import { RegisterFamilyComponent } from './register-family/register-family.component';
import { NgbModalModule, NgbModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { RegisterSuccessComponent } from './register-success/register-success.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import localeEsExtra from '@angular/common/locales/extra/es';
import { ModalDeleteConfirmModule } from 'src/app/shared/components/modal-delete-confirm/modal-delete-confirm.module';
import { RegisterFaceImageComponent } from './register-face-image/register-face-image.component';
import { RegisterFavoritePlacesComponent } from './register-favorite-places/register-favorite-places.component';
import { ModalMessageModule } from 'src/app/shared/components/modal-message/modal-message.module';

registerLocaleData(localeEs, 'es', localeEsExtra);

@NgModule({
    declarations: [
        RegisterComponent,
        RegisterPersonalInfoComponent,
        RegisterFamilyComponent,
        RegisterSuccessComponent,
        RegisterFaceImageComponent,
        RegisterFavoritePlacesComponent,
    ],
    imports: [
        CommonModule,
        RegisterRoutingModule,
        RouterModule,
        NgbModalModule,
        FormsModule,
        ReactiveFormsModule,
        NgbModule,
        NgbNavModule,
        ModalDeleteConfirmModule,
        ModalMessageModule
    ],
    providers: [{ provide: LOCALE_ID, useValue: 'es-ES' }],
})
export class RegisterModule {}
