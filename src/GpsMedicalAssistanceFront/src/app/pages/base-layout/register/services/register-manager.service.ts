import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthenticationRegister } from '../interfaces/authentication-register.interface';
import { FamilyCreate } from '../interfaces/family-create.interface';
import { FavoritePlaceCreate } from '../interfaces/favorite-place-create.interface';
import { UserCreate } from '../interfaces/user-create.interface';

@Injectable({
    providedIn: 'root',
})
export class RegisterManagerService {
    private authData!: AuthenticationRegister;

    constructor() {}

    getPersonalInfo(): AuthenticationRegister {
        return this.authData;
    }

    getUserImageFace(): string | null {
        return (this.authData) ? this.authData.user.imagePath : null;
    }

    getFamilies(): FamilyCreate[] {
        return this.authData.user.families;
    }

    getFavoritePlaces(): FavoritePlaceCreate[] {
        return this.authData.user.favoritePlaces;
    }

    updateUserImageFace(base64Image: string): void {
        if (!this.authData) this.authData = this.createEmptyData();
        this.authData.user.imagePath = base64Image;
    }

    updatePersonalInfo(auth: AuthenticationRegister): void {
        if (!this.authData) this.authData = this.createEmptyData();

        this.authData.user.name = auth.user.name;
        this.authData.user.lastName = auth.user.lastName;
        this.authData.user.email = auth.user.email;
        this.authData.user.identification = auth.user.identification;
        this.authData.user.phone = auth.user.phone;
        this.authData.user.birthDate = auth.user.birthDate;
        this.authData.password = auth.password;
    }

    updateFamilies(families: FamilyCreate[]): void {
        if (!this.authData) this.authData = this.createEmptyData();

      this.authData.user.families = families;
    }

    updateFavoritePlaces(favoritePlaces: FavoritePlaceCreate[]): void {
        if (!this.authData) this.authData = this.createEmptyData();

      this.authData.user.favoritePlaces = favoritePlaces;
    }

    private createEmptyData(): AuthenticationRegister {
      return {
          user: {
              name: '',
              lastName: '',
              email: '',
              identification: '',
              phone: '',
              birthDate: null,
              imagePath: '',
              families: [],
              favoritePlaces: [],
          },
          password: '',
      };
    }
}
