import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { DataService } from 'src/app/Services/data.service';
import CommonApiService from 'src/app/Urls/CommonApiServices';
import { ConstansUrlService } from 'src/app/Urls/ConstansUrlService';
import { DialogService } from 'primeng/dynamicdialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToasterService } from 'src/app/Services/toaster.service';
import { ConfirmationService, MessageService, ConfirmEventType } from 'primeng/api';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  items!: MenuItem[];
  editStudent: boolean = false;
  editStudentform!: FormGroup;
  workStudent: any;
  students: any[] = [];
  first = 0;
  deletedNum!: number;
  studentForm!: FormGroup;

  groupNames: { [key: number]: string } = {
    1: 'MPC',
    2: 'PIBC',
    3: 'CEC',
    4: 'MEC',
    5: 'MPC',
    6: 'BIPC'
  };
  rows = 10;
  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private fb: FormBuilder,
    private toast: ToasterService,
    private apiService: CommonApiService, private route: Router) { }

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      name: [''],
      id: [''],
      city: [''],
      mobile: [''],
      group: ['']
      // Add more form controls for other student properties
    });

    this.getStudents();
    this.menuitems();
    this.loadedit();
  }
  addStuBooks(student: any) {
    debugger;
    if (student) {
      this.studentForm.patchValue({
        name: student.name,
        id: student.id,
        city: student.city,
        mobile: student.mobile,
        group: this.groupNames[student.groupId]
      });
    }
  }
  submitstubooks(){
    debugger
    this.studentForm.value;
  }


  loadedit() {
    this.editStudentform = this.fb.group({
      Name: ['', Validators.required],
      City: ['', Validators.required],
      Mobile: ['', Validators.required],
      GroupId: ['', Validators.required]
    });
  }
  menuitems() {
    this.items = [
      {
        label: 'Edit',
        icon: 'pi pi-fw pi-file',
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-pencil',
      }]
  }
  getStudents(): void {
    const { getStudents } = ConstansUrlService;
    this.apiService.getData(getStudents).subscribe((students: any) => {
      this.students = students;
      console.log(students);
    });
  }

  registr() {
    this.route.navigate(['/registerStu']);
  }
  edit(student: any) {
    this.workStudent = student;
    this.editStudent = true;
    this.editStudentform.patchValue({
      Name: student.name,
      City: student.city,
      Mobile: student.mobile,
      GroupId: student.groupId
    });
  }
  submitEditForm() {
    if (this.editStudentform.valid) {
      const { updateStudent } = ConstansUrlService;
      const updateUrl = `${updateStudent}/${this.workStudent.id.toString()}`;

      const requestData = {
        id: this.workStudent.id,
        name: this.editStudentform.get('Name')!.value,
        city: this.editStudentform.get('City')!.value,
        mobile: this.editStudentform.get('Mobile')!.value,
        groupId: this.editStudentform.get('GroupId')!.value
      };

      this.apiService.updateData(updateUrl, requestData)
        .subscribe((response) => {
          const editedStudentData = requestData;
          this.toast.showWarn("Deleted Success fully" + response);
        });
    }
  }

  deleteNumner(id: number) {
    this.deletedNum = id;
  }

  delete() {
    if (this.deletedNum != null) {
      const { deleteStudent } = ConstansUrlService;
      const updateUrl = `${deleteStudent}/${this.deletedNum.toString()}`
      this.apiService.deleteData(updateUrl, this.deletedNum)
        .subscribe((res) => {
          if (res) {
            console.log(res);
            this.getStudents();
          }
        });
    }
  }

  next() {
    this.first = this.first + this.rows;
  }
  prev() {
    this.first = this.first - this.rows;
  }
  reset() {
    this.first = 0;
  }
  isLastPage(): boolean {
    return this.students ? this.first === this.students.length - this.rows : true;
  }
  isFirstPage(): boolean {
    return this.students ? this.first === 0 : true;
  }
}
