import { Component, OnInit, Output } from '@angular/core';
import {
    AbstractControl,
    FormControl,
    FormGroup,
    Validators,
} from '@angular/forms';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Subject, tap } from 'rxjs';
import { ModalDeleteConfirmComponent } from 'src/app/shared/components/modal-delete-confirm/modal-delete-confirm.component';
import { FamilyType } from 'src/app/shared/interfaces/family-type.interface';
import { FormMode } from 'src/app/shared/models/form-mode';
import { FamilyTypeService } from 'src/app/shared/services/family-type/family-type.service';
import { FamilyCreate } from '../interfaces/family-create.interface';
import { RegisterManagerService } from '../services/register-manager.service';

@Component({
    selector: 'app-register-family',
    templateUrl: './register-family.component.html',
    styleUrls: ['./register-family.component.scss'],
})
export class RegisterFamilyComponent implements OnInit {
    @Output() changeStepClick = new Subject<boolean>();

    familyTypes: FamilyType[] = [];
    families: FamilyCreate[] = [];
    isFormSubmitted: boolean = false;
    modalFamily!: NgbModalRef;
    familyEditIndex: number = -1;
    formMode: string = FormMode.CreationMode;

    form: FormGroup = new FormGroup({
        id_FamilyType: new FormControl("", [Validators.required]),
        name: new FormControl(null, [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(20),
            Validators.pattern(/^[a-zA-Z\s]*$/),
        ]),
        lastName: new FormControl(null, [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(20),
            Validators.pattern(/^[a-zA-Z\s]*$/),
        ]),
        identification: new FormControl(null, [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(9),
            Validators.pattern(/^[0-9]*$/),
        ]),
        identificationType: new FormControl("", [Validators.required]),
        phone: new FormControl(null, [
            Validators.required,
            Validators.minLength(7),
            Validators.maxLength(7),
            Validators.pattern(/^[0-9]*$/),
        ]),
        phoneType: new FormControl("", [Validators.required]),
    });

    constructor(private modalService: NgbModal, 
                private familyTypeSvc: FamilyTypeService,
                private registerManagerSvc: RegisterManagerService) {}

    ngOnInit(): void {
        this.getFamilyTypes();
        this.getTemporalSavedFamilies();
    }

    open(modalContent: any): void {
        this.formMode = FormMode.CreationMode;
        this.isFormSubmitted = false;
        this.form.reset();

        this.modalFamily = this.modalService.open(modalContent, {
            ariaLabelledBy: 'modal-basic-title',
        });
    }

    goBack(): void {
        this.changeStepClick.next(false);
    }

    nextSetp(): void {
        this.registerManagerSvc.updateFamilies(this.families);
        this.changeStepClick.next(true);
    }

    onSubmitModalForm(): void {
        this.isFormSubmitted = true;

        if (this.form.valid) {
            const formattedIdentification: string = `${this.form.controls['identificationType'].value}-${this.form.controls['identification'].value}`;
            const formattedPhone: string = `${this.form.controls['phoneType'].value}-${this.form.controls['phone'].value}`;

            const family: FamilyCreate = {
                id_FamilyType: this.form.controls['id_FamilyType'].value,
                name: this.form.controls['name'].value,
                lastName: this.form.controls['lastName'].value,
                identification: formattedIdentification,
                phone: formattedPhone,
            };

            if (this.formMode === FormMode.CreationMode) {
                this.families.push(family);
            } else {
                this.families[this.familyEditIndex] = family;
            }

            this.modalFamily.close();
        }
    }

    onEditFamily(index: number, modalContent: any): void {
        this.formMode = FormMode.EditMode;
        this.familyEditIndex = index;

        const family = this.families[index];

        const identificationSplitted = family.identification.split('-');
        const phoneSplitted = family.phone.split('-');

        this.isFormSubmitted = false;
        this.form.reset();

        this.form.setValue({
            id_FamilyType: family.id_FamilyType,
            name: family.name,
            lastName: family.lastName,
            identification: identificationSplitted[1],
            identificationType: identificationSplitted[0],
            phone: phoneSplitted[1],
            phoneType: phoneSplitted[0],
        });

        this.modalFamily = this.modalService.open(modalContent, {
            ariaLabelledBy: 'modal-basic-title',
        });
    }

    get formModeCreation(): string {
        return FormMode.CreationMode;
    }

    onDeleteFamily(familyIndex: number): void {
        const modalDeleteConfirmRef = this.modalService.open(
            ModalDeleteConfirmComponent
        );

        modalDeleteConfirmRef.componentInstance.title = 'Eliminar Familiar';
        modalDeleteConfirmRef.componentInstance.description =
            '¿Está seguro que desea eliminar este familiar?';

        modalDeleteConfirmRef.result.then(
            (shouldDelete: boolean) => {
                if (shouldDelete) {
                    this.families.splice(familyIndex, 1);
                }
            },
            () => {}
        );
    }

    getFamilyTypeNameById(id: number): string {
        const familyType: FamilyType | undefined = this.familyTypes.find(x => x.id === +id);
        return (familyType) ? familyType.name : '-';

    }

    private getFamilyTypes(): void {
        this.familyTypeSvc.getFamilyTypes().pipe(
            tap(
                (x: FamilyType[]) => {this.familyTypes = x; console.log(x)}
            )
        ).subscribe();
    }

    private getTemporalSavedFamilies(): void {
        const familiesSaved: FamilyCreate[] = this.registerManagerSvc.getFamilies();
        if(familiesSaved) {
            this.families = familiesSaved;
        } 
    }
}
