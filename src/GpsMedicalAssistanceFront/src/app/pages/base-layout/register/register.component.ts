import { Component, OnInit } from '@angular/core';
import { RegisterManagerService } from './services/register-manager.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
    formStep: number = 0;

    constructor(
        private registerManagerSvc: RegisterManagerService,
    ) {}

    ngOnInit(): void {
        this.registerManagerSvc.clearFields();
    }

    changeStepManager(value: boolean): void {
        if (value) this.formStep++;
        else this.formStep--;
    }
}
