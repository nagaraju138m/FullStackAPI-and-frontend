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
import { DataShare } from 'src/app/Services/SharedDataObS.service';
declare var bootstrap: any; 
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
  booksData: any[] = [];
  selectedStudent:any;
  selectedBooks: any[] = [];
  studentBooks: any[] = [];
  alreadyBooks:any[]=[];

  StuRegister : boolean = false;
  Main:boolean=true;

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
    private dataShare: DataShare,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private fb: FormBuilder,
    private toast: ToasterService,
    private apiService: CommonApiService, private route: Router) { }

    hello(){
      debugger;
    }
  ngOnInit(): void {


    const popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    popoverTriggerList.map(function (popoverTriggerEl) {
      return new bootstrap.Popover(popoverTriggerEl);
    });




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
    this.selectedStudent = student;
    const { getBooksById, getByStuId } = ConstansUrlService;
    debugger;
    const updateUrl = `${getBooksById}${student.groupId.toString()}`
    const stubooksurl = `${getByStuId}${student.id.toString()}`
    this.apiService.getData(stubooksurl)
        .subscribe((res:any) => {
          if (res) {
            this.selectedBooks = res;
            this.apiService.getData(updateUrl)
            .subscribe((res:any) => {
              if (res) {
                console.log(res);
                this.booksData = res;
              }
            });
          }
        });
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
  isBookSelected(book: any): boolean {
    if (typeof book === 'object' && 'bookId' in book) {
      return this.selectedBooks.some(selectedBook => selectedBook.bookId === book.bookId);
    }
    return false;
  } 
  submitstubooks(){
    debugger
    const { StudentBooksAdd } = ConstansUrlService;
    this.apiService.postData(StudentBooksAdd,this.studentBooks).subscribe(res=>{
      this.studentBooks = [];
      this.booksData = [];
    })
  }
  toggleSelection(book:any): void {
    debugger;
    book.selected = !book.selected;

    if (book.selected) {
      // If the book is selected, create a student book object and add it to the array
      const studentBook = {
        studentId: this.selectedStudent.id, // Replace with the actual studentId
        bookId: book.bookId,
        hasBook : true
      };
      this.studentBooks.push(studentBook);
    } else {
      // If the book is deselected, find and remove the corresponding student book object from the array
      const index = this.studentBooks.findIndex(studentBook => studentBook.bookId === book.bookId);
      if (index !== -1) {
        this.studentBooks.splice(index, 1);
      }
    }
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
          this.editStudent = false;
          this.getStudents();
        });
    }
  }
  PaymentScreen(student:any){
    this.dataShare.updateStudentData(student);
    this.route.navigate(['/StuPayments']);
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
