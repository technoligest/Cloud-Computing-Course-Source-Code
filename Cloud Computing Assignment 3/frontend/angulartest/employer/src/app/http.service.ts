import { Injectable } from '@angular/core';
import{Http} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class HttpService {
  constructor(private http:Http) { }
  API_HOME = "HOME";
  fetchData(){
    this.http.get("http://todolist2018.azurewebsites.net/v1/getpics/qwe").subscribe((data)=>console.log(data));
  }
  signIn(id:number){
    var url = this.API_HOME+"/signin/"+id;
    console.log(url);
    url = "http://todolist2018.azurewebsites.net/v1/getpics/qwe";
    this.http.get(url).map((res)=>res.json()).subscribe((data)=>console.log(data));
  }
  success(){
    return "Success";
  }
}
