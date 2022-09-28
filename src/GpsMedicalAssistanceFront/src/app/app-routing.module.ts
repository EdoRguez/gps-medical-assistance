import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BaseLayoutComponent } from './pages/base-layout/base-layout.component';
import { SiteLayoutComponent } from './pages/site-layout/site-layout.component';
import { IsAuthenticatedGuard } from './shared/guards/is-authenticated.guard';

const routes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            {
                path: '',
                loadChildren: () =>
                    import('./pages/site-layout/home/home.module').then(
                        (m) => m.HomeModule
                    ),
            },
            {
                path: 'alerts',
                loadChildren: () =>
                    import('./pages/site-layout/alerts/alerts.module').then(
                        (m) => m.AlertsModule
                    ),
            },
        ]
    },
    {
        path: '',
        component: BaseLayoutComponent,
        children: [
            {
                path: 'register',
                loadChildren: () =>
                    import('./pages/base-layout/register/register.module').then(
                        (m) => m.RegisterModule
                    ),
            },
            {
                path: 'login',
                loadChildren: () =>
                    import('./pages/base-layout/login/login.module').then(
                        (m) => m.LoginModule
                    ),
            },
        ],
        canActivate: [IsAuthenticatedGuard]
    },
    { path: '**', pathMatch: 'full', redirectTo: '' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
