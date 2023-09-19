import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './MainPage/main/main.component';
import { StudentRegisterComponent } from './Student/student-register/student-register.component';
import { StudentPaymentsComponent } from './Student/student-payments/student-payments.component';


const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'MainComponent', component: MainComponent },
  
  { path: 'registerStu',
   component: StudentRegisterComponent
   }, // Add this line
  //  { path: 'Admin',
  //  component: AdminDashBoardComponent
  //  } // Add this line
  {
    path:'StuPayments',
    component:StudentPaymentsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
