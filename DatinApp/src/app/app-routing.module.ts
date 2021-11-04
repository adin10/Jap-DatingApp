import { componentFactoryName } from '@angular/compiler';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MembersComponent } from './members/members.component';
import { MessagesComponent } from './messages/messages.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UsersComponent } from './user/user.component';

const routes: Routes = [
  {path:'user',component:UsersComponent},
  {path:'nav',component:NavMenuComponent},
  {path:'messages',component:MessagesComponent},
  {path:'lists',component:ListsComponent},
  {path:'members',component:MembersComponent},
  {path:'member/:username',component:MemberDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
