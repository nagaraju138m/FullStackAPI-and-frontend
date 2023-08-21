import { HttpClient } from "@angular/common/http";
import { UrlServices } from "./UrlsConstants";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})

export default class CommonApiService{

    public apiUrl = 'https://localhost:7083/api';

    constructor(
        private http: HttpClient
      ){}

      getData(url:any){
        const path:string = this.apiUrl + url
        return this.http.get(path);
      }

      postData(url:string, data:any){
        const path:string = this.apiUrl + url;
        return this.http.post(path, data);
      }

      updateData(url:string, data:any){
        const path:string = this.apiUrl + url;
        return this.http.put(path,data);
      }
      deleteData(url:string,id:any){
        const parth: string = this.apiUrl + url;
        return this.http.delete(parth);
      }

}