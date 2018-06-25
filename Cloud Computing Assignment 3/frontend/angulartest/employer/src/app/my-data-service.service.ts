import { Injectable } from '@angular/core';

@Injectable()
export class MyDataServiceService {

  constructor() { }
  success (){
    return "Successful.";
  }

  obj = {
    id: "1",
    name: "yaser",
    rollno: "1234"
  }

}
