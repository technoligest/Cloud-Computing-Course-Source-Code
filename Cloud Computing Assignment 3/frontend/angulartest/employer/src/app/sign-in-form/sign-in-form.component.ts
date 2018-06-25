import { Component} from '@angular/core';
import {Employee} from '../employee';
import {HttpService} from '../http.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.css']
})
export class SignInFormComponent {
  model = new Employee("12345","Yaser","Engineer",120,20);
  submitted =false;
  onSubmit(){
    this.submitted = true;
    // if(this.newService.signIn(12345)){
    // }

    this.router.navigate(['/add'])
    
  }
  get diagnostic() {return JSON.stringify(this.model);}
  constructor(private newService:HttpService, private router: Router){}
  ngOnInit(){
    console.log();
  }
}

