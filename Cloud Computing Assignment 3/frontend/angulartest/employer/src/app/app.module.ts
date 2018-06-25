import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { SignInFormComponent } from './sign-in-form/sign-in-form.component';
import { HttpClientModule } from '@angular/common/http';
import {HttpModule} from '@angular/http';
import {HttpService} from './http.service';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { ReleaseInfoFormComponent } from './release-info-form/release-info-form.component';



const appRoutes: Routes = [
  { path: 'signin', component: SignInFormComponent },
  { path: 'add', component: AddEmployeeComponent },
  { path: 'accept',component: ReleaseInfoFormComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    SignInFormComponent,
    AddEmployeeComponent,
    ReleaseInfoFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    HttpModule,
    AppRoutingModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [HttpClientModule, HttpService],
  bootstrap: [AppComponent]
})


export class AppModule { }
