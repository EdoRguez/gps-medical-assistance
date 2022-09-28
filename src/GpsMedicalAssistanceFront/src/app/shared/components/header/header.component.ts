import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  toggleNavbar: boolean = true;
  isUserLogged: boolean = false;

  constructor(private authSvc: AuthenticationService) { }

  ngOnInit(): void {
    this.authSvc.isUserLogged$.subscribe({
      next: (value: boolean) => {
        this.isUserLogged = value;
      }
    });
  }

  onLogout(): void {
    this.authSvc.logout();
  }

}
