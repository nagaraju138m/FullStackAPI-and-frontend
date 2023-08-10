import { HttpClient } from "@angular/common/http";
import { UrlServices } from "./UrlsConstants";


export default class CommonApiService{

    constructor(
        private appSettings: UrlServices,
        private http: HttpClient
      ){}


}