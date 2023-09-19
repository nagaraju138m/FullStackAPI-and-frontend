import { BehaviorSubject } from "rxjs";


export class DataShare {
    private studentDataSubject = new BehaviorSubject<any>(null);

    studentData$ = this.studentDataSubject.asObservable();

    
    updateStudentData(student: any) {
        this.studentDataSubject.next(student);
    }
}