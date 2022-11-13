import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { AlertsFilter } from '../interfaces/alerts-filter.interface';

@Injectable({
    providedIn: 'root',
})
export class AlertManagerService {
    private alertFilterSubject = new BehaviorSubject<AlertsFilter | null>(null);

    constructor() {}

    get alertFilterAction$(): Observable<AlertsFilter | null> {
        return this.alertFilterSubject.asObservable();
    }

    emitAlertFilter(alertFilter: AlertsFilter): void {
        this.alertFilterSubject.next(alertFilter);
    }
}
