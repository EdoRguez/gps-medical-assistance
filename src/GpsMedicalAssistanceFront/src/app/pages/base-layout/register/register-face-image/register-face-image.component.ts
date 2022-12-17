import {
    Component,
    ElementRef,
    OnInit,
    Output,
    ViewChild,
} from '@angular/core';
import { Subject } from 'rxjs';
import { RegisterManagerService } from '../services/register-manager.service';

@Component({
    selector: 'app-register-face-image',
    templateUrl: './register-face-image.component.html',
    styleUrls: ['./register-face-image.component.scss'],
})
export class RegisterFaceImageComponent implements OnInit {
    @Output() changeStepClick = new Subject<boolean>();

    @ViewChild('CameraVideoRef') cameraVideoRef!: ElementRef;
    @ViewChild('CameraPhotoRef') cameraPhotoRef!: ElementRef;

    activeTabId: number = 1;
    dragging: boolean = false;
    loaded: boolean = false;
    imageLoaded: boolean = false;
    imageSrc: string = '';
    showImageFormatError: boolean = false;
    isSubmittedPage: boolean = false;
    isCameraRunning: boolean = false;
    showCameraBlockedError: boolean = false;

    constructor(private registerManagerSvc: RegisterManagerService) {}

    ngOnInit(): void {
        const userImage: string | null =
            this.registerManagerSvc.getUserImageFace();

        if (userImage) this.imageSrc = userImage;
    }

    handleDragEnter() {
        this.dragging = true;
    }

    handleDragLeave() {
        this.dragging = false;
    }

    handleDrop(e: any) {
        e.preventDefault();
        this.dragging = false;
        this.handleInputChange(e);
    }

    handleImageLoad() {
        this.imageLoaded = true;
    }

    handleInputChange(e: any) {
        this.showImageFormatError = false;
        this.isSubmittedPage = false;

        let file = e.dataTransfer ? e.dataTransfer.files[0] : e.target.files[0];

        let reader = new FileReader();

        if (file.type !== 'image/png' && file.type !== 'image/jpeg') {
            this.showImageFormatError = true;
            return;
        }

        this.loaded = false;

        reader.onload = this._handleReaderLoaded.bind(this);
        reader.readAsDataURL(file);
    }

    getImageBoxColor(): string {
        let color: string = '#ccc';

        if (this.dragging) color = 'rgb(9, 25, 255)';

        if (this.isSubmittedPage && !this.imageSrc) color = '#dc3545';

        return color;
    }

    private _handleReaderLoaded(e: any) {
        let reader = e.target;
        this.imageSrc = reader.result;
        this.loaded = true;
    }

    nextStep(): void {
        this.isSubmittedPage = true;
        this.showImageFormatError = false;

        if (this.imageSrc) {
            this.registerManagerSvc.updateUserImageFace(this.imageSrc);
            this.changeStepClick.next(true);
        }
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
                this.isSubmittedPage = false;
                this.showCameraBlockedError = true;
            });
        this.cameraVideoRef.nativeElement.srcObject = stream;
    }

    onTakePhoto(): void {
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
    }

    onChangeTab(): void {
        this.isCameraRunning = false;
        this.imageSrc = '';
    }
}
