import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CoreService } from '../core/core.service';
import { EmployeeService } from '../services/employee-api.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DesignationApiService } from '../services/designation-api.service';
import { DesignationMst } from '../../Models/designation.model';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrl: './employee-edit.component.scss'
})

export class EmployeeEditComponent {

  empForm: FormGroup;
  designation: DesignationMst[] = [];
  constructor(private _fb: FormBuilder,
    private _empService: EmployeeService,
    private _desgService: DesignationApiService,
    private _dialogref: MatDialogRef<EmployeeEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService) {
    this.empForm = this._fb.group({
      id:'0',
      firstName: '',
      lastName: '',
      emailAddress: '',
      dob: '',
      designation: '',
      address: '',
      city: '',
      postalCode: '',
      phoneNumber: '',
      gender: '',

    });
  }
  
  ngOnInit(): void {
    this._desgService.getDesignationList().subscribe(
      (data: DesignationMst[]) => {
        this.designation = data;
      },
      (error) => {
        console.error('Error fetching designations:', error);
      }
    );

    this.empForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.empForm.valid) {
      if (this.data) {
        this._empService
          .updateEmployee(this.data.id, this.empForm.value)
          .subscribe({
            next: (val: any) => {
              this._coreService.openSnackBar('Employee detail updated!');
              this._dialogref.close(true);
            },
            error: (err: any) => {
              console.error(err);
            },
          });
      } else {
        this._empService.addEmployee(this.empForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Employee added successfully');
            this._dialogref.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }
}
