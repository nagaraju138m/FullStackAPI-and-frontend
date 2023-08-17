import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MainComponent } from './MainPage/main/main.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http'
import { ButtonModule } from 'primeng/button';
import { StudentRegisterComponent } from './Student/student-register/student-register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CardModule } from 'primeng/card';
import CommonApiService from './Urls/CommonApiServices';
import { ToastModule } from 'primeng/toast';
import { ToasterService } from './Services/toaster.service';
import { MessageService} from 'primeng/api';
import { TieredMenuModule } from 'primeng/tieredmenu';
import {SlideMenuModule} from 'primeng/slidemenu';
import { MenuModule } from 'primeng/menu';
import { DialogModule } from 'primeng/dialog';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    StudentRegisterComponent,

  ],
  imports: [
    DialogModule,
    MenuModule,
    SlideMenuModule,
    ToastModule,
    CardModule,
    InputTextModule,
    ReactiveFormsModule,
    ButtonModule,
    HttpClientModule,
    TableModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    TieredMenuModule,
  ],
  providers: [
    // provide: CommonApiService,
    // useClass: CommonApiService
    ToasterService,
    MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
