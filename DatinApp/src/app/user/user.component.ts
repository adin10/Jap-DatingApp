import { Component, OnInit } from '@angular/core';
import { UsersService } from '../_services/user.service';
import { User } from '../_shared/user.model';

@Component({
  selector: 'app-users',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UsersComponent implements OnInit {

  usersList:User[]=[];
  constructor(public service:UsersService) { }

  ngOnInit(){
      this.service.getUsers().subscribe(data=>{
        this.usersList=data;
      })
  }

}
