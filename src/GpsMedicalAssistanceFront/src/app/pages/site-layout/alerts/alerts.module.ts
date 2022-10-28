import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlertsRoutingModule } from './alerts-routing.module';
import { AlertsComponent } from './alerts.component';
import { AlertsFilterComponent } from './alerts-filter/alerts-filter.component';
import { AlertsListComponent } from './alerts-list/alerts-list.component';

import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import localeEsExtra from '@angular/common/locales/extra/es';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AlertsCreateComponent } from './alerts-create/alerts-create.component';
import { RouterModule } from '@angular/router';
import { LoaderModule } from 'src/app/shared/components/loader/loader.module';
import { ModalAlertUserComponent } from './alerts-create/modal-alert-user/modal-alert-user.component';
import { ModalAlertCreatedComponent } from './alerts-create/modal-alert-created/modal-alert-created.component';
import { AlertDetailsComponent } from './alert-details/alert-details.component';

registerLocaleData(localeEs, 'es', localeEsExtra);

@NgModule({
  declarations: [
    AlertsComponent,
    AlertsFilterComponent,
    AlertsListComponent,
    AlertsCreateComponent,
    ModalAlertUserComponent,
    ModalAlertCreatedComponent,
    AlertDetailsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    AlertsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    LoaderModule
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'es-ES' }],
})
export class AlertsModule { }
