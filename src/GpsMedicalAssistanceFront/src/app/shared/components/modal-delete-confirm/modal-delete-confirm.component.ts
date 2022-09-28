import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-modal-delete-confirm',
    templateUrl: './modal-delete-confirm.component.html',
    styleUrls: ['./modal-delete-confirm.component.scss'],
})
export class ModalDeleteConfirmComponent implements OnInit {
    @Input() title!: string;
    @Input() description!: string;

    constructor(public activeModal: NgbActiveModal) {}

    ngOnInit(): void {}
}
