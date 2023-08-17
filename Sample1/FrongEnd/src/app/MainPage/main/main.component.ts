import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { DataService } from 'src/app/Services/data.service';
import CommonApiService from 'src/app/Urls/CommonApiServices';
import { ConstansUrlService } from 'src/app/Urls/ConstansUrlService';
import { DialogService } from 'primeng/dynamicdialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  items!: MenuItem[] ;
  editStudent:boolean = false;
  editStudentform!: FormGroup;
  
  students: any[] = [];
  first = 0;

  rows = 10;
  constructor(
    private fb: FormBuilder,
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
    const {getStudents} = ConstansUrlService;
    this.apiService.getData(getStudents).subscribe((students:any )=> {
      this.students = students;
      console.log(students);
    });
    // this.studentService.getStudents()
    //   .subscribe(students => {
    //     this.students = students;
    //   });
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
registr(){
this.route.navigate(['/registerStu']);
}
edit(student:any){
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
    const editedStudentData = this.editStudentform.value;
    console.log('Edited student:', editedStudentData);
  }
}
delete(studentId: number) {
  console.log(`Deleting student with ID: ${studentId}`);
}

}
