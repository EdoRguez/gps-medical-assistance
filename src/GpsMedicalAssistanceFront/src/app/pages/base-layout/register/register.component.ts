import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
    formStep: number = 0;

    constructor() {}

    ngOnInit(): void {}

    changeStepManager(value: boolean): void {
        if (value) 
            this.formStep++;
        else 
            this.formStep--;
    }
}
