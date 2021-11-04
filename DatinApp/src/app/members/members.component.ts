import { Component, OnInit } from '@angular/core';
import { MemberService } from '../_services/member.service';
import { Member } from '../_shared/member';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {

  members:Member[]=[];
  constructor(public _memberService:MemberService) { }

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers(){
    this._memberService.getMembers().subscribe((members:Member[])=>{
      this.members=members;
    })
  }
}
