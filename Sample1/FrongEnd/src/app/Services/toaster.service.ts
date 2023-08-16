import { Injectable } from '@angular/core';
import { PrimeNGConfig ,MessageService} from 'primeng/api';
import { Toast } from 'primeng/toast';


@Injectable({
  providedIn: 'root'
})
export class ToasterService {
  constructor(private messageService: MessageService, private primengConfig: PrimeNGConfig) { }

showInfo(message:any) {
    this.messageService.add({severity:'success', summary: 'Success', detail: message});
}

showWarn(message:any) {
    this.messageService.add({severity:'warn', summary: 'Warn', detail: message});
}

showError(message:any) {
    this.messageService.add({severity:'error', summary: 'Error', detail: message});
}

}
