import { Component, OnInit } from '@angular/core';
import { User } from '../../interfaces/user.interface';
import { AuthenticationService } from '../../services/authentication/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  toggleNavbar: boolean = true;
  isUserLogged: boolean = false;
  user!: User | null;

  constructor(private authSvc: AuthenticationService) { }

  ngOnInit(): void {
    this.authSvc.isUserLogged$.subscribe({
      next: (value: boolean) => {
        this.isUserLogged = value;
      }
    });

    this.authSvc.getUserLogged$.subscribe({
        next: (user: User | null) => {
            this.user = user;
        }
    });
  }

  onLogout(): void {
    this.authSvc.logout();
  }

}
