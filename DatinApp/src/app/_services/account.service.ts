import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({providedIn:'root'})
export class AccountService{
constructor(public http:HttpClient){}

baseUrl='https://localhost:5001/api/'
    login(model:any){
        return this.http.post('https://localhost:5001/api/Account/login',model);
    }
}