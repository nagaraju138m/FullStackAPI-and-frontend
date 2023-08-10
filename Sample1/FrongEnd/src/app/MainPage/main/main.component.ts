import { Component } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  students: any[] = [];

  constructor(private studentService: DataService) { }

  ngOnInit(): void {
    debugger;
    this.getStudents();
  }

  getStudents(): void {
    this.studentService.getStudents()
      .subscribe(students => {
        this.students = students;
      });
  }
}
