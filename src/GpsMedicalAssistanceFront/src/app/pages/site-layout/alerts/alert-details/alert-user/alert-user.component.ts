import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/shared/interfaces/user.interface';
import * as dayjs from 'dayjs';
import { UserAnonymous } from '../../interfaces/user-anonymous.interface';

@Component({
    selector: 'app-alert-user',
    templateUrl: './alert-user.component.html',
    styleUrls: ['./alert-user.component.scss'],
})
export class AlertUserComponent implements OnInit {
    @Input() user!: User | null;
    @Input() userAnonymous!: UserAnonymous | null;
    @Input() isCreatorUser: boolean = false;

    isUserAnonymous: boolean = false;

    constructor() {}

    ngOnInit(): void {
        this.isUserAnonymous = this.userAnonymous ? true : false;
    }

    getUserName(): string {
        if (this.isUserAnonymous)
            return this.userAnonymous?.name
                ? this.userAnonymous.name
                : 'Usuario Anónimo';

        return `${this.user?.name} ${this.user?.lastName}`;
    }

    getUserIdentification(): string {
        if (this.isUserAnonymous)
            return this.userAnonymous?.identification
                ? this.userAnonymous.identification
                : '-';

        return `${this.user?.identification}`;
    }

    getUserPhone(): string {
        if (this.isUserAnonymous)
            return this.userAnonymous?.phone ? this.userAnonymous.phone : '-';

        return `${this.user?.phone}`;
    }

    getUserYears(birthDate: Date | undefined): string {
        if (this.isUserAnonymous)
            return this.userAnonymous?.age
                ? `${this.userAnonymous.age} años`
                : '-';

        const date1 = dayjs(Date());
        const date2 = dayjs(birthDate);

        return `${date1.diff(date2, 'year').toString()} años`;
    }

    getUserGender(): string {
        if (!this.userAnonymous?.gender) return '-';

        return this.userAnonymous?.gender?.toUpperCase() === 'M'
            ? 'Masculino'
            : 'Femenino';
    }

    getUserHeight(): string {
        if (!this.userAnonymous?.height) return '-';

        return `${this.userAnonymous?.height} metros`;
    }
}
