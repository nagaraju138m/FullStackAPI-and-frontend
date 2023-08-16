import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { DataService } from 'src/app/Services/data.service';
import CommonApiService from 'src/app/Urls/CommonApiServices';
import { ConstansUrlService } from 'src/app/Urls/ConstansUrlService';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  items!: MenuItem[] ;
    
  students: any[] = [];
  first = 0;

  rows = 10;
  constructor(
    private apiService:CommonApiService, private route:Router) { }

  ngOnInit(): void {
    this.getStudents();
    this.menuitems();
  }
  menuitems(){
    this.items = [
      {
          label: 'File',
          icon: 'pi pi-fw pi-file',
          items: [
              {
                  label: 'New',
                  icon: 'pi pi-fw pi-plus',
                  items: [
                      {
                          label: 'Bookmark',
                          icon: 'pi pi-fw pi-bookmark'
                      },
                      {
                          label: 'Video',
                          icon: 'pi pi-fw pi-video'
                      }
                  ]
              },
              {
                  label: 'Delete',
                  icon: 'pi pi-fw pi-trash'
              },
              {
                  separator: true
              },
              {
                  label: 'Export',
                  icon: 'pi pi-fw pi-external-link'
              }
          ]
      },
      {
          label: 'Edit',
          icon: 'pi pi-fw pi-pencil',
          items: [
              {
                  label: 'Left',
                  icon: 'pi pi-fw pi-align-left'
              },
              {
                  label: 'Right',
                  icon: 'pi pi-fw pi-align-right'
              },
              {
                  label: 'Center',
                  icon: 'pi pi-fw pi-align-center'
              },
              {
                  label: 'Justify',
                  icon: 'pi pi-fw pi-align-justify'
              }
          ]
      }]
  }
  getStudents(): void {
    debugger;
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
}
