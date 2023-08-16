import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './MainPage/main/main.component';
import { StudentRegisterComponent } from './Student/student-register/student-register.component';

const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'MainComponent', component: MainComponent },
  
  { path: 'registerStu',
   component: StudentRegisterComponent
   } // Add this line
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
