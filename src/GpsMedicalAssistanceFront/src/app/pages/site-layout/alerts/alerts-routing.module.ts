import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlertsCreateComponent } from './alerts-create/alerts-create.component';
import { AlertsComponent } from './alerts.component';

const routes: Routes = [
  { path: '', component: AlertsComponent },
  { path: 'create', component: AlertsCreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlertsRoutingModule { }
