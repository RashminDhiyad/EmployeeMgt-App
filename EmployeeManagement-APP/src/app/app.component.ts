import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeEditComponent } from './employee-edit/employee-edit.component';
import { CoreService } from './core/core.service';
import { EmployeeService } from './services/employee-api.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'emailAddress', 'dob', 'gender', 'designation', 'phoneNumber', 'address', 'city', 'postalCode', 'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public dialog: MatDialog, private _empService: EmployeeService, private _coreService: CoreService) { }

  ngOnInit(): void {
    this.getEmployeeList();
  }

  openAddEditForm(enterAnimationDuration: string, exitAnimationDuration: string) {
    const dialogRef = this.dialog.open(EmployeeEditComponent, {
      enterAnimationDuration,
      exitAnimationDuration,
    });
    dialogRef.afterClosed().subscribe({
      next: (val: any) => {
        if (val) {
          this.getEmployeeList();
        }
      },
    });
  }

  getEmployeeList() {
    this._empService.getEmployeeList().subscribe({
      next: (res: any[] | undefined) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err: any) => {
        console.log(err);
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteEmployee(id: number) {
    this._empService.deleteEmployee(id).subscribe({
      next: (res: any) => {
        this._coreService.openSnackBar('Employee deleted!', 'done');
        this.getEmployeeList();
      },
      error: console.log,
    });
  }

  openEditForm(data: any) {
    const dialogRef = this.dialog.open(EmployeeEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val: any) => {
        if (val) {
          this.getEmployeeList();
        }
      },
    });
  }
}
