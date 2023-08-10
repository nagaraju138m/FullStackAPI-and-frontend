

import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";



@Injectable({
  providedIn: "root",
})

export class UrlServices {

    public apiUrl = 'https://localhost:7083/api/Student';
}