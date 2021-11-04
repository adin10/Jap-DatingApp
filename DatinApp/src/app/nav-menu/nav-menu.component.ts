import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  model: any = {};

  constructor(public accountService:AccountService, private router: Router, 
              private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login(){
   this.accountService.login(this.model).subscribe(response=>{
    this.router.navigateByUrl('/members');
   });
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }


}