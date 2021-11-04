import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Member } from "../_shared/member";
import { UpdateMemberRequest } from "../_shared/Requests/UpdateMemberRequest.model";

@Injectable({providedIn:'root'})
export class MemberService{
    baseUrl=environment.apiUrl;

    constructor(public http:HttpClient){}

    getMembers(){
        return this.http.get<Member[]>(this.baseUrl+'users');
    }

    getMember(username: string){
        return this.http.get(this.baseUrl + 'users/' + username);
      }
     updateMember(username:string,memberupdateRequest:UpdateMemberRequest){
         return this.http.put(this.baseUrl + 'users/' + username,memberupdateRequest);
     }
}