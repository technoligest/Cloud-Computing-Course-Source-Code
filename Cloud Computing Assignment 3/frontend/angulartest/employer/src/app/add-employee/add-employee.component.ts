import { Component, OnInit } from '@angular/core';
import {HttpService} from '../http.service';
import {Employee} from '../employee';


@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  model = new Employee("12345","Yaser","Engineer",120,20);
  constructor(private newService:HttpService) { }
  onSubmit(){}
  ngOnInit() {}

}
