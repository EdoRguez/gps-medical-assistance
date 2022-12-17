import {
    Component,
    ElementRef,
    OnInit,
    Output,
    ViewChild,
} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from 'rxjs';
import { User } from 'src/app/shared/interfaces/user.interface';
import { LoaderService } from 'src/app/shared/services/general/loader.service';
import { FaceRecognitionParameters } from 'src/app/shared/services/request-features/face-recognition-parameters.interface';
import { UserService } from 'src/app/shared/services/user/user.service';

@Component({
    selector: 'app-camera-recognition',
    templateUrl: './camera-recognition.component.html',
    styleUrls: ['./camera-recognition.component.scss'],
})
export class CameraRecognitionComponent implements OnInit {
    @Output() userFound = new Subject<User | null>();

    @ViewChild('CameraVideoRef') cameraVideoRef!: ElementRef;
    @ViewChild('CameraPhotoRef') cameraPhotoRef!: ElementRef;

    imageSrc: string = '';
    isCameraRunning: boolean = false;
    showCameraBlockedError: boolean = false;

    constructor(
        public activeModal: NgbActiveModal,
        private usersSvc: UserService,
        private loaderSvc: LoaderService
    ) {}

    ngOnInit(): void {}

    resetComponent(): void {
        this.imageSrc = '';
        this.isCameraRunning = true;
        this.showCameraBlockedError = false;
    }

    async onStartCamera(): Promise<void> {
        this.imageSrc = '';
        this.isCameraRunning = true;
        this.showCameraBlockedError = false;
        let stream = await navigator.mediaDevices
            .getUserMedia({
                video: true,
                audio: false,
            })
            .catch((err) => {
                this.imageSrc = '';
                this.isCameraRunning = false;
                this.showCameraBlockedError = true;
            });
        this.cameraVideoRef.nativeElement.srcObject = stream;
    }

    onTakePhoto(): void {
        this.loaderSvc.toggleLoader(true, 'Buscando Usuario..');

        this.isCameraRunning = false;
        this.cameraPhotoRef.nativeElement
            .getContext('2d')
            .drawImage(
                this.cameraVideoRef.nativeElement,
                0,
                0,
                this.cameraPhotoRef.nativeElement.width,
                this.cameraPhotoRef.nativeElement.height
            );

        this.imageSrc =
            this.cameraPhotoRef.nativeElement.toDataURL('image/jpeg');

        const faceRecognitionParameters: FaceRecognitionParameters = {
            imagePath: this.imageSrc,
        };
        this.usersSvc.getByFace(faceRecognitionParameters).subscribe({
            next: (user: User) => {
                this.userFound.next(user);
                this.loaderSvc.toggleLoader(false);
            },
            error: () => {
                this.userFound.next(null);
                this.loaderSvc.toggleLoader(false);
            },
        });
    }
}
