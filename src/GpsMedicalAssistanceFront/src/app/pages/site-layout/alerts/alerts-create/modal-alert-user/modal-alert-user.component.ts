import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/shared/interfaces/user.interface';
import * as dayjs from 'dayjs';

@Component({
  selector: 'app-modal-alert-user',
  templateUrl: './modal-alert-user.component.html',
  styleUrls: ['./modal-alert-user.component.scss']
})
export class ModalAlertUserComponent implements OnInit {

  @Input() user!: User;
  userAge!: number;

  constructor(public activeModal: NgbActiveModal,
              private domSanitizer: DomSanitizer) { }

  ngOnInit(): void {
    if(this.user) {
      const date1 = dayjs(this.user.birthDate);
      const date2 = dayjs(new Date());
      this.userAge = date2.diff(date1, 'year');
    }
  }
}
