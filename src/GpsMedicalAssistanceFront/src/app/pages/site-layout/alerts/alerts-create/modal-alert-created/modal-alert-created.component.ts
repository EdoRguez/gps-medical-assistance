import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-alert-created',
  templateUrl: './modal-alert-created.component.html',
  styleUrls: ['./modal-alert-created.component.scss']
})
export class ModalAlertCreatedComponent implements OnInit {

  @Input() idAlert!: number;

  constructor(public activeModal: NgbActiveModal,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  goToCreatedAlert(): void {
    this.activeModal.dismiss();
    this.router.navigateByUrl(`/alerts/${this.idAlert}`);
  }

}
