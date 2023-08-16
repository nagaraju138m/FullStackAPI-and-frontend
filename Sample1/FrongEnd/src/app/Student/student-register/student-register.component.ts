import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ToasterService } from 'src/app/Services/toaster.service';
import CommonApiService from 'src/app/Urls/CommonApiServices';
import { ConstansUrlService } from 'src/app/Urls/ConstansUrlService';

@Component({
  selector: 'app-student-register',
  templateUrl: './student-register.component.html',
  styleUrls: ['./student-register.component.scss']
})
export class StudentRegisterComponent implements OnInit {

  registrationForm!: FormGroup;

  constructor(
    private messageService: MessageService,
    private fb :FormBuilder,
    private toast:ToasterService,
    private apiService:CommonApiService,
    ){

  }
  ngOnInit():void{
    this.registrationForm = this.fb.group({
      Name : ['', Validators.required],
      City : ['', Validators.required],
      Mobile :['', Validators.required],
      GroupId:['', Validators.required]
    });
  }
  onSubmit(){
   
    const {createStudents} = ConstansUrlService;
    this.apiService.postData(createStudents,this.registrationForm.value).subscribe(res=>{
      console.log(res);
      debugger;
      this.toast.showInfo("Student Create Successfully");
    });
  }
}
