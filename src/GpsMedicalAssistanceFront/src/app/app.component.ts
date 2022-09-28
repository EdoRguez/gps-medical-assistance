import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './shared/services/authentication/authentication.service';
import { LoaderService } from './shared/services/general/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'GpsMedicalAssistanceFront';
  showLoader: boolean = false;
  loaderMessage!: string;

  constructor(private loaderSvc: LoaderService,
            private authSvc: AuthenticationService) {  }

  ngOnInit(): void {
    this.authSvc.firstLoadValidation();

    this.loaderSvc.isLoading.subscribe(
      (showLoader: boolean) => {
        this.loaderMessage = this.loaderSvc.loaderMessage;
        this.showLoader = showLoader;
      }
    );
  }
}
