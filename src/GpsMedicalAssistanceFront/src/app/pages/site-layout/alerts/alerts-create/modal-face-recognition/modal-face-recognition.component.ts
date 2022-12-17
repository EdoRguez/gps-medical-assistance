import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable, Subject } from 'rxjs';
import { User } from 'src/app/shared/interfaces/user.interface';
import { CameraRecognitionComponent } from './camera-recognition/camera-recognition.component';

@Component({
    selector: 'app-modal-face-recognition',
    templateUrl: './modal-face-recognition.component.html',
    styleUrls: ['./modal-face-recognition.component.scss'],
})
export class ModalFaceRecognitionComponent implements OnInit {
    @ViewChild(CameraRecognitionComponent)
    cameraRecognitionRef!: CameraRecognitionComponent;

    modalContentType: number = 1;
    userFound = new Subject<User | null>();
    user: User | null = null;

    constructor(public activeModal: NgbActiveModal) {}

    ngOnInit(): void {}

    showUserFound(user: User | null): void {
        this.modalContentType = 2;
        this.user = user;
        this.userFound.next(user);
    }

    processResultStatus(statusId: number): void {
        this.modalContentType = 1;

        if (statusId === 1) {
            // Success get user
            this.activeModal.close(this.user);
        } else if (statusId === 2) {
            // Repeat process
            this.cameraRecognitionRef.resetComponent();
        } else {
            // Close modal
            this.activeModal.close(null);
        }
    }
}
