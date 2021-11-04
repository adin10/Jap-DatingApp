import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MemberService } from '../_services/member.service';
import { Member } from '../_shared/member';
import { UpdateMemberRequest } from '../_shared/Requests/UpdateMemberRequest.model';
import { User } from '../_shared/user.model';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') editForm:NgForm;
  member:Member;
  user:User;

  memberUpdateRequest:UpdateMemberRequest;

  @HostListener('window:beforeunload',['event']) unloadNotification($event:any){
    // hostListener nam sluzi kao provjera da li smo sigurni da zelimo napustiti stranicu van aplikacije
    if(this.editForm.dirty){
      $event.returnValue=true;
    }
  }

  constructor(public memberService:MemberService,public route:ActivatedRoute,private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){
    this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe((member: Member)=>
    {
      this.member = member;
    })
  }

  updateMember(){
    
    // this.memberService.updateMember(this.route.snapshot.paramMap.get('username'),this.editForm.value());
    console.log(this.member);
    this.toastrService.success("Profile updated successfuly");
    this.editForm.reset(this.member);
  }
}

