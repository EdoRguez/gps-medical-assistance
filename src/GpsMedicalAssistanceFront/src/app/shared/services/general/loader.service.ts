import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  isLoading: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  loaderMessage!: string;

  constructor() { }

  toggleLoader(show: boolean, message: string = 'Cargando..'): void {
    this.loaderMessage = message;
    this.isLoading.next(show);
  }
}
