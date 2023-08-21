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
  items!: MenuItem[] ;
  editStudent:boolean = false;
  editStudentform!: FormGroup;
  workStudent:any;
  students: any[] = [];
  first = 0;

  rows = 10;
  constructor(
    private confirmationService: ConfirmationService,
     private messageService: MessageService,
    private fb: FormBuilder,
    private toast:ToasterService,
    private apiService:CommonApiService, private route:Router) { }

  ngOnInit(): void {
    this.getStudents();
    this.menuitems();
    this.loadedit();
  }
  loadedit(){
    this.editStudentform = this.fb.group({
      Name: ['', Validators.required],
      City: ['', Validators.required],
      Mobile: ['', Validators.required],
      GroupId: ['', Validators.required]
    });
  }
  menuitems(){
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
    debugger;
    const {getStudents} = ConstansUrlService;
    this.apiService.getData(getStudents).subscribe((students:any )=> {
      this.students = students;
      console.log(students);
    });
  }

registr(){
this.route.navigate(['/registerStu']);
}
edit(student:any){
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
    debugger;
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
        this.toast.showWarn("Deleted Success fully"+response);
      });
  }
}

// delete(studentId: number) {
//   debugger;
//  if(studentId != null){
//   const {deleteStudent} = ConstansUrlService;
//   const updateUrl= `${deleteStudent}/${studentId.toString()}`
//   this.apiService.deleteData(updateUrl,studentId)
//   .subscribe((res)=>{
//     if(res){
//       console.log(res);
//       this.getStudents();
//     }
//   });
//  }
// }

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

delete(studentId: number) {
  debugger;
  this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        // if(studentId != null){
        //     const {deleteStudent} = ConstansUrlService;
        //     const updateUrl= `${deleteStudent}/${studentId.toString()}`
        //     this.apiService.deleteData(updateUrl,studentId)
        //     .subscribe((res)=>{
        //       if(res){
        //         console.log(res);
        //         this.getStudents();
        //       }
        //     });
        //    }
           this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
      },
      reject: (type:any) => {
          switch (type) { // Corrected syntax here
              case ConfirmEventType.REJECT:
                  this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
                  break;
              case ConfirmEventType.CANCEL:
                  this.messageService.add({ severity: 'warn', summary: 'Cancelled', detail: 'You have cancelled' });
                  break;
          }
      }
  });
}

confirm2() {
  debugger;
  this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
          this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
      },
      reject: (type:any) => {
          switch (type) { // Corrected syntax here
              case ConfirmEventType.REJECT:
                  this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
                  break;
              case ConfirmEventType.CANCEL:
                  this.messageService.add({ severity: 'warn', summary: 'Cancelled', detail: 'You have cancelled' });
                  break;
          }
      }
  });
}
}
