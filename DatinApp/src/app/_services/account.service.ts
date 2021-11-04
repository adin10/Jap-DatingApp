import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReplaySubject } from "rxjs";
import { User } from "../_shared/user.model";
import { map } from 'rxjs/operators';
@Injectable({providedIn:'root'})
export class AccountService{
constructor(public http:HttpClient){}

baseUrl='https://localhost:5001/api/';
private currentUserSource=new ReplaySubject<User>(1);
currentUser$=this.currentUserSource.asObservable();
    

    login(model: any){
        return this.http.post<User>('https://localhost:5001/api/Account/login', model).pipe(
          map((response: User)=>{
            const user = response as User;
            if(user){
              localStorage.setItem('user', JSON.stringify(user));
              this.currentUserSource.next(user);
            }
          })
        )
      }

setCurrentUser(user:User){
    this.currentUserSource.next(user);
}

    logout(){
        localStorage.removeItem('user');
        this.currentUserSource.next(null!);
      }
}