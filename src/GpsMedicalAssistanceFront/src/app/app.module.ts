import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeModule } from './pages/site-layout/home/home.module';
import { HeaderModule } from './shared/components/header/header.module';
import { RegisterModule } from './pages/base-layout/register/register.module';
import { BaseLayoutComponent } from './pages/base-layout/base-layout.component';
import { SiteLayoutComponent } from './pages/site-layout/site-layout.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginModule } from './pages/base-layout/login/login.module';
import { AlertsModule } from './pages/site-layout/alerts/alerts.module';
import { LoaderModule } from './shared/components/loader/loader.module';
import { ModalDeleteConfirmModule } from './shared/components/modal-delete-confirm/modal-delete-confirm.module';
import { ModalMessageModule } from './shared/components/modal-message/modal-message.module';

@NgModule({
  declarations: [
    AppComponent,
    BaseLayoutComponent,
    SiteLayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HomeModule,
    HeaderModule,
    RegisterModule,
    NgbModule,
    LoginModule,
    AlertsModule,
    LoaderModule,
    ModalDeleteConfirmModule,
    ModalMessageModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
