import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlertDetailsComponent } from './alert-details/alert-details.component';
import { AlertsCreateComponent } from './alerts-create/alerts-create.component';
import { AlertsComponent } from './alerts.component';

const routes: Routes = [
  { path: '', component: AlertsComponent },
  { path: 'create', component: AlertsCreateComponent },
  { path: ':id', component: AlertDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlertsRoutingModule { }
