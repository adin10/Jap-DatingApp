import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../_shared/user.model";

@Injectable({providedIn:'root'})
export class UsersService{
    constructor(public http:HttpClient){}

    getUsers(){
        return this.http.get<User[]>('https://localhost:5001/api/Users');
    }
   
}