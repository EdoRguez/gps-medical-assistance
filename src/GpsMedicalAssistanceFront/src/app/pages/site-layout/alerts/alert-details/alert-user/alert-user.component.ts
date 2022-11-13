import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/shared/interfaces/user.interface';
import * as dayjs from 'dayjs';

@Component({
    selector: 'app-alert-user',
    templateUrl: './alert-user.component.html',
    styleUrls: ['./alert-user.component.scss'],
})
export class AlertUserComponent implements OnInit {
    @Input() user!: User | null;
    @Input() isCreatorUser: boolean = false;

    constructor() {}

    ngOnInit(): void {}

    getUserYears(birthDate: Date | undefined): string {
        const date1 = dayjs(Date());
        const date2 = dayjs(birthDate);

        return date1.diff(date2, 'year').toString();
    }
}
